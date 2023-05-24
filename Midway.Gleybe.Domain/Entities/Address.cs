using Midway.Gleybe.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Midway.Gleybe.Domain.Entities
{
    public class Address
    {
        [BsonElement("Street")]
        public string Street { get; private set; }

        [BsonElement("Number")]
        public string Number { get; private set; }

        [BsonElement("City")]
        public string City { get; private set; }

        [BsonElement("PostalCode")]
        public string PostalCode { get; private set;}

        [BsonElement("Uf")]
        public string Uf { get; private set; }

        [BsonElement("Classification")]
        public ClassificationEnum Classification { get; private set; }

        public Address(string Street, string Number, string City, string PostalCode, string Uf, ClassificationEnum Classification)
        {
            this.Number = Number;
            this.Street = Street;
            this.City = City;
            this.PostalCode = PostalCode;
            this.Uf = Uf;
            this.Classification = Classification;
        }

        public Address()
        {
            
        }
    }
}
