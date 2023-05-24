using MediatR;
using Midway.Gleybe.Application.DTOs;

namespace Midway.Gleybe.Application.CQRS.Commands.Contacts.Delete
{
    public class DeleteContactCommand : IRequest<HandlerResponse>
    {
        public Guid _Id { get; set; }
    }
}
