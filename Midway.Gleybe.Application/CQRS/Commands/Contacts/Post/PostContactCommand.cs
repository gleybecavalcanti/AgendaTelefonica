using MediatR;
using Midway.Gleybe.Application.DTOs;

namespace Midway.Gleybe.Application.CQRS.Commands.Contacts.Post
{
    public class PostContactCommand : IRequest<HandlerResponse>
    {
        public string? Name { get; set; }
        public List<PhoneNumberDTO>? PhoneNumbers { get; set; }
        public List<string>? Emails { get; set; }
        public string? Company { get; set; }
        public List<AddressDTO>? Address { get; set; }
        public bool IsDeleted { get; private set; } = false;

    }
}
