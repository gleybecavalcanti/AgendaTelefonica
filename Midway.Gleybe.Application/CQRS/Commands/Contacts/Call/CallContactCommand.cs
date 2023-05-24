using MediatR;
using Midway.Gleybe.Application.DTOs;

namespace Midway.Gleybe.Application.CQRS.Commands.Contacts.Call
{
    public class CallContactCommand : IRequest<HandlerResponse>
    {
        public Guid _Id { get; set; }
        public string Topic { get; set; }

    }
}
