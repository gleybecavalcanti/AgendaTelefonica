using AutoMapper;
using MediatR;
using Midway.Gleybe.Application.DTOs;
using Midway.Gleybe.Domain.Constants;
using Midway.Gleybe.Domain.Entities;
using Midway.Gleybe.Domain.Interfaces.Services;

namespace Midway.Gleybe.Application.CQRS.Commands.Contacts.Post
{
    public class PostContactHandler : IRequestHandler<PostContactCommand, HandlerResponse>
    {
        private readonly IContactService contactService;
        private readonly IMapper mapper;

        public PostContactHandler(IContactService contactService, IMapper mapper)
        {
            this.contactService = contactService;
            this.mapper = mapper;
        }

        public async Task<HandlerResponse> Handle(PostContactCommand request, CancellationToken cancellationToken)
        {

            var contact = mapper.Map<Contact>(request);
            await contactService.AddContact(contact);
            return new HandlerResponse() { Data = Messages.DefaultAddContact, HasError = false };
        }

    }
}
