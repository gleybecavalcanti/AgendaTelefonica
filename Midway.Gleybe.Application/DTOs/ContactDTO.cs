using Midway.Gleybe.Domain.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midway.Gleybe.Application.DTOs
{
    public class ContactDTO
    {
        public Guid _Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<AddressDTO> Address { get; set; }

        public bool IsDeleted { get; private set; }

        public IEnumerable<string> Emails { get; private set; }

        public IEnumerable<PhoneNumberDTO> PhoneNumbers { get; private set; }

        public string Company { get; set; }

        public ContactDTO(Guid _Id, string Name, IEnumerable<AddressDTO> Address, List<PhoneNumberDTO> PhoneNumbers, IEnumerable<string> Emails, string Company, bool IsDeleted)
        {
            this._Id = _Id;
            this.Name = Name;
            this.Address = Address;
            this.PhoneNumbers = PhoneNumbers;
            this.IsDeleted = IsDeleted;
            this.Emails = Emails;
            this.Company = Company;
        }

        public ContactDTO()
        {

        }
    }
}
