using Midway.Gleybe.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midway.Gleybe.Domain.Entities
{
    public class PhoneNumber
    {
        [BsonElement("Number")]
        public string Number { get; private set; }

        [BsonElement("Classification")]
        public ClassificationEnum Classification { get; private set; }

        public PhoneNumber(string Number, ClassificationEnum Classification)
        {
            this.Number = Number;
            this.Classification = Classification;
        }

        public PhoneNumber()
        {
            
        }
    }
}
