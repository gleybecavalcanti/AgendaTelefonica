using AutoMapper;
using MediatR;
using Midway.Gleybe.Application.CQRS.Queries.Contacts.GetAll;
using Midway.Gleybe.Application.DTOs;
using Midway.Gleybe.Domain.Interfaces.Services;

namespace Midway.Gleybe.Application.CQRS.Queries.GetAll
{
    public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, HandlerResponse>
    {
        private readonly IContactService contactService;
        private readonly IMapper mapper;

        public GetAllContactsHandler(IContactService contactService, IMapper mapper)
        {
            this.contactService = contactService;
            this.mapper = mapper;
        }

        public async Task<HandlerResponse> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contactDocuments = await contactService.GetAllContacts(request.withDeleted ?? false);
            var dto = mapper.Map<List<ContactDTO>>(contactDocuments);
            return new HandlerResponse() { Data = dto };
        }
    }
}
