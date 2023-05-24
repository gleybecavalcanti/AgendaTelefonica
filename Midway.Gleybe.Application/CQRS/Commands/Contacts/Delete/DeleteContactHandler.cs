using MediatR;
using Midway.Gleybe.Application.DTOs;
using Midway.Gleybe.Domain.Constants;
using Midway.Gleybe.Domain.Interfaces.Services;

namespace Midway.Gleybe.Application.CQRS.Commands.Contacts.Delete
{
    public class DeleteContactHandler : IRequestHandler<DeleteContactCommand, HandlerResponse>
    {
        private readonly IContactService contactService;

        public DeleteContactHandler(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public async Task<HandlerResponse> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            await contactService.DeleteContact(request._Id);
            return new HandlerResponse() { Data = Messages.DefaultDeleteContact, HasError = false };
        }
    }
}
