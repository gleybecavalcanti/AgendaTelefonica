using Confluent.Kafka;
using MediatR;
using Midway.Gleybe.Application.DTOs;
using Midway.Gleybe.Domain.Constants;
using Midway.Gleybe.Domain.Entities;
using Midway.Gleybe.Domain.Interfaces.Services;
using System.Text.Json;

namespace Midway.Gleybe.Application.CQRS.Commands.Contacts.Call
{
    public class CallContactHandler : IRequestHandler<CallContactCommand, HandlerResponse>
    {
        private readonly IContactService contactService;
        private readonly IProducer<string, string> _kafkaProducer;

        public CallContactHandler(IContactService contactService, IProducer<string, string> kafkaProducer)
        {
            this.contactService = contactService;
            this._kafkaProducer = kafkaProducer;
        }

        public async Task<HandlerResponse> Handle(CallContactCommand request, CancellationToken cancellationToken)
        {
            // Recuperando os dados do contato com base no ID fornecido
            var contact = await contactService.GetContactById(request._Id);

            // Simulação da chamada de 5 minutos
            string callerName = "Gleybe Cavalcanti";
            string callerNumber = "+5581999167564";
            TimeSpan callDuration = TimeSpan.FromMinutes(5);
            DateTime callDateTime = DateTime.Now;

            // Gerando registro de chamada com detalhes
            var callLog = new
            {
                CallerName = callerName,
                CallerNumber = callerNumber,
                ContactName = contact.Name,
                ContactNumber = contact.PhoneNumbers.FirstOrDefault()?.Number,
                Duration = callDuration,
                DateTime = callDateTime
            };

            // Convertendo o objeto dinâmico para uma string JSON
            string callLogJson = JsonSerializer.Serialize(callLog);

            // Configurando a mensagem para envio para o tópico no Kafka
            var message = new Message<string, string>
            {
                Key = string.Empty,
                Value = callLogJson
            };

            // Enviando a mensagem para o tópico no Kafka
            var deliveryReport = await _kafkaProducer.ProduceAsync(request.Topic, message);

            // Verificando o resultado do envio da mensagem
            if (deliveryReport.Status == PersistenceStatus.Persisted)
            {
                return new HandlerResponse() { Data = deliveryReport, HasError = false };   
            }
            else
            {
                return new HandlerResponse() { Data = Messages.KafkaStreamError };
            }
        }
    }
}
