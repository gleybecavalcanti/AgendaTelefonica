using MediatR;
using Midway.Gleybe.Application.DTOs;

namespace Midway.Gleybe.Application.CQRS.Queries.GetByFilters
{
    public class GetContactsByFiltersQuery : IRequest<HandlerResponse>
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
