using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Midway.Gleybe.Domain.Entities
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid _Id { get; private set; }

        [BsonElement("Name")]
        public string Name { get; private set; }

        [BsonElement("Address")]
        public IEnumerable<Address> Address { get; set; }

        [BsonElement("IsDeleted")]
        public bool IsDeleted { get; private set; }

        [BsonElement("Emails")]
        public IEnumerable<string> Emails { get; private set; }

        [BsonElement("PhoneNumbers")]
        public IEnumerable<PhoneNumber> PhoneNumbers { get; private set; }

        [BsonElement("Company")]
        public string Company { get; set; }

        public Contact(Guid _Id, string Name, IEnumerable<Address> Address, List<PhoneNumber> PhoneNumbers, IEnumerable<string> Emails, string Company, bool IsDeleted)
        {
            this._Id = _Id;
            this.Name = Name;
            this.Address = Address;
            this.PhoneNumbers = PhoneNumbers;
            this.IsDeleted = IsDeleted;
            this.Emails = Emails;
            this.Company = Company; 
        }

        public Contact()
        {
            
        }
    }
}
