using Midway.Gleybe.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Midway.Gleybe.Application.Extensions;
using Midway.Gleybe.Domain.Constants;

namespace Midway.Gleybe.Application.DTOs
{
    public class AddressDTO
    {
        public string Street { get; set; }

        public string Number { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Uf { get; set; }

        public ClassificationEnum? Classification { get; set; }
        public string ClassificationDec => Classification.HasValue ? Classification.Value.GetDescription() : Messages.DefaultNotDefined;

        public AddressDTO(string Street, string Number, string City, string PostalCode, string Uf, ClassificationEnum Classification)
        {
            this.Number = Number;
            this.Street = Street;
            this.City = City;
            this.PostalCode = PostalCode;
            this.Uf = Uf;
            this.Classification = Classification;
        }

        public AddressDTO()
        {
            
        }
    }
}
