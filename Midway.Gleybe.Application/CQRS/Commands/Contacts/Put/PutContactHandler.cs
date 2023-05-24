using AutoMapper;
using MediatR;
using Midway.Gleybe.Application.DTOs;
using Midway.Gleybe.Domain.Constants;
using Midway.Gleybe.Domain.Entities;
using Midway.Gleybe.Domain.Interfaces.Services;

namespace Midway.Gleybe.Application.CQRS.Commands.Contacts.Put
{
    public class PutContactHandler : IRequestHandler<PutContactCommand, HandlerResponse>
    {
        private readonly IMapper mapper;    
        private readonly IContactService contactService;

        public PutContactHandler(IMapper mapper, IContactService contactService)
        {
            this.mapper = mapper;
            this.contactService = contactService;
        }

        public async Task<HandlerResponse> Handle(PutContactCommand request, CancellationToken cancellationToken)
        {
            
            var document = mapper.Map<Contact>(request);
            await contactService.UpdateContact(document);

            return new HandlerResponse() { Data = Messages.DefaultUpdateContact, HasError = false };

        }
    }
}
