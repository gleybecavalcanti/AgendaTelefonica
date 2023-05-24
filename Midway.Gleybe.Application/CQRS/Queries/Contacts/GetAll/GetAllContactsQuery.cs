using MediatR;
using Midway.Gleybe.Application.DTOs;

namespace Midway.Gleybe.Application.CQRS.Queries.Contacts.GetAll
{
    public class GetAllContactsQuery : IRequest<HandlerResponse>
    {
        public bool? withDeleted { get; set; }
    }
}
