using AutoMapper;
using MediatR;
using Midway.Gleybe.Application.CQRS.Queries.Contacts.GetById;
using Midway.Gleybe.Application.DTOs;
using Midway.Gleybe.Domain.Interfaces.Services;

namespace Midway.Gleybe.Application.CQRS.Queries.GetById
{
    public class GetContactsByIdHandler : IRequestHandler<GetContactsByIdQuery, HandlerResponse>
    {
        private readonly IMapper mapper;
        private readonly IContactService contactService;

        public GetContactsByIdHandler(IMapper mapper, IContactService contactService)
        {
            this.mapper = mapper;
            this.contactService = contactService;
        }

        public async Task<HandlerResponse> Handle(GetContactsByIdQuery request, CancellationToken cancellationToken)
        {
            var document = await contactService.GetContactById(request._Id);

            var Dto = mapper.Map<ContactDTO>(document);

            return new HandlerResponse() { Data = Dto, HasError = false };
        }
    }
}
