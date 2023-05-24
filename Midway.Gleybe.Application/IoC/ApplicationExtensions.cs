using AutoMapper;
using Confluent.Kafka;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Midway.Gleybe.Application.Pipelines;
using Midway.Gleybe.Application.Services.Contacts;
using Midway.Gleybe.Domain.Interfaces.Repositories;
using Midway.Gleybe.Domain.Interfaces.Services;
using Midway.Gleybe.Infrastructure.Repositories;
using NetCore.AutoRegisterDi;

namespace Midway.Gleybe.Application.IoC
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AppRegister(this IServiceCollection services, IConfiguration configuration)
        {
            /* Automapper */
            var mapper = new MapperConfiguration(config => {
                config.AddMaps(typeof(ApplicationExtensions).Assembly);
            });
            mapper.AssertConfigurationIsValid();
            var map = mapper.CreateMapper();
            services.AddSingleton(map);

            /* 
             - Kafka - Configurações do produtor
            */

            var kafkaConfig = new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:Broker"],
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = configuration["Kafka:UserName"],
                SaslPassword = configuration["Kafka:Password"]
            };
            services.AddSingleton<IProducer<string, string>>(_ => new ProducerBuilder<string, string>(kafkaConfig).Build());

            /* MediatR */
            services.AddMediatR(typeof(ApplicationExtensions).Assembly);

            /* Dependency Injection */
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IContactService, ContactService>();

            services.AddValidatorsFromAssembly(typeof(ApplicationExtensions).Assembly);
            services.RegisterAssemblyPublicNonGenericClasses(typeof(ApplicationExtensions).Assembly)
                .Where(e => e.Name.EndsWith("ExceptionHandler"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Transient);

            return services;
        }
    }
}
