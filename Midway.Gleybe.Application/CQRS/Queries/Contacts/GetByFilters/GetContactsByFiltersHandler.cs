using AutoMapper;
using MediatR;
using Midway.Gleybe.Application.DTOs;
using Midway.Gleybe.Domain.Interfaces.Services;

namespace Midway.Gleybe.Application.CQRS.Queries.GetByFilters
{
    public class GetContactsByFiltersHandler : IRequestHandler<GetContactsByFiltersQuery, HandlerResponse>
    {
        private readonly IMapper mapper;
        private readonly IContactService contactService;

        public GetContactsByFiltersHandler(IMapper mapper, IContactService contactService)
        {
            this.mapper = mapper;
            this.contactService = contactService;
        }

        public async Task<HandlerResponse> Handle(GetContactsByFiltersQuery request, CancellationToken cancellationToken)
        {
            var documents = await contactService.SearchContacts(request.Name ?? string.Empty, 
                request.PhoneNumber ?? string.Empty, request.Email ?? string.Empty);

            var Dto = mapper.Map<List<ContactDTO>>(documents);
            return new HandlerResponse() { Data = Dto, HasError = false };
        }
    }
}
