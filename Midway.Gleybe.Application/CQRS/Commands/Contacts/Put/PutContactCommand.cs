using MediatR;
using Midway.Gleybe.Application.DTOs;
using System.Text.Json.Serialization;

namespace Midway.Gleybe.Application.CQRS.Commands.Contacts.Put
{
    public class PutContactCommand : IRequest<HandlerResponse>
    {
        [JsonIgnore]
        public Guid _Id { get; set; }
        public string? Name { get; set; }
        public List<PhoneNumberDTO>? PhoneNumbers { get; set; }
        public List<string>? Emails { get; set; }
        public string? Company { get; set; }
        public List<AddressDTO>? Address { get; set; }
        public bool IsDeleted { get; private set; } = false;

    }
}
