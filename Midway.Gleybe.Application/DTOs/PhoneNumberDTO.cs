using Midway.Gleybe.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;
using Midway.Gleybe.Application.Extensions;
using Midway.Gleybe.Domain.Constants;

namespace Midway.Gleybe.Application.DTOs
{
    public class PhoneNumberDTO
    {
        public string Number { get; set; }

        public ClassificationEnum? Classification { get; set; }

        public string ClassificationDec => Classification.HasValue ? Classification.Value.GetDescription() : Messages.DefaultNotDefined;

        public PhoneNumberDTO(string Number, ClassificationEnum Classification)
        {
            this.Number = Number;
            this.Classification = Classification;
        }

        public PhoneNumberDTO()
        {
            
        }
    }
}
