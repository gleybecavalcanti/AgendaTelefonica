using AutoMapper;
using Midway.Gleybe.Application.CQRS.Commands.Contacts.Post;
using Midway.Gleybe.Application.CQRS.Commands.Contacts.Put;
using Midway.Gleybe.Application.DTOs;
using Midway.Gleybe.Domain.Entities;

namespace Midway.Gleybe.Application.Automapper
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<ContactDTO, Contact>()
                .ReverseMap();

            CreateMap<PostContactCommand, Contact>()
                .ForMember(q => q._Id, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<AddressDTO, Address>()
                .ReverseMap();

            CreateMap<PhoneNumberDTO, PhoneNumber>()
                .ReverseMap();

            CreateMap<PutContactCommand, Contact>()
                .ReverseMap();
                

        }
    }
}
