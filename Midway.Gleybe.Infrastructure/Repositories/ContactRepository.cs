using Midway.Gleybe.Domain.Entities;
using Midway.Gleybe.Domain.Interfaces.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Midway.Gleybe.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IMongoCollection<Contact> _contactCollection;

        public ContactRepository(IMongoDatabase database)
        {
            _contactCollection = database.GetCollection<Contact>("contacts");
        }

        public async Task<IEnumerable<Contact>> GetAllContacts(bool withDeleted)
        {
            var filter = withDeleted ? Builders<Contact>.Filter.Empty : Builders<Contact>.Filter.Eq(c => c.IsDeleted, false);
            var sort = Builders<Contact>.Sort.Ascending(c => c.Name);

            return await _contactCollection.Find(filter).Sort(sort).ToListAsync();
        }

        public async Task<Contact> GetContactById(Guid contactId)
        {
            var filter = Builders<Contact>.Filter.Eq(c => c._Id, contactId) & Builders<Contact>.Filter.Eq(c => c.IsDeleted, false);

            return await _contactCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contact>> SearchContacts(string name, string phone, string email)
        {
            var filters = new List<FilterDefinition<Contact>>();

            if (!string.IsNullOrWhiteSpace(name))
            {
                var nameFilter = Builders<Contact>.Filter.Regex(c => c.Name, new BsonRegularExpression(name, "i"));
                filters.Add(nameFilter);
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                var emailFilter = Builders<Contact>.Filter.Regex(c => c.Emails, new BsonRegularExpression(email, "i"));
                filters.Add(emailFilter);
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                var phoneFilter = Builders<Contact>.Filter.Regex("PhoneNumbers.Number", new BsonRegularExpression(phone, "i"));
                filters.Add(phoneFilter);
            }

            var filter = filters.Any() ? Builders<Contact>.Filter.And(filters) : Builders<Contact>.Filter.Empty;
            var sort = Builders<Contact>.Sort.Ascending(c => c.Name);

            return await _contactCollection.Find(filter).Sort(sort).ToListAsync();
        }

        public async Task AddContact(Contact contact)
        {
            await _contactCollection.InsertOneAsync(contact);
        }

        public async Task UpdateContact(Contact contact)
        {
            var filter = Builders<Contact>.Filter.Eq(c => c._Id, contact._Id);

            await _contactCollection.ReplaceOneAsync(filter, contact);
        }

        public async Task DeleteContact(Guid contactId)
        {
            var filter = Builders<Contact>.Filter.Eq(c => c._Id, contactId);

            var update = Builders<Contact>.Update.Set(c => c.IsDeleted, true);

            await _contactCollection.UpdateOneAsync(filter, update);
        }
    }
}
