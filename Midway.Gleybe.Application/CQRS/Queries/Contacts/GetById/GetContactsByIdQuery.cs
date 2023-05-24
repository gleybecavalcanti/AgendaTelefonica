using MediatR;
using Midway.Gleybe.Application.DTOs;

namespace Midway.Gleybe.Application.CQRS.Queries.Contacts.GetById
{
    public class GetContactsByIdQuery : IRequest<HandlerResponse>
    {
        public Guid _Id { get; set; }
    }
}
