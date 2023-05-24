using Midway.Gleybe.Domain.Entities;
using Midway.Gleybe.Domain.Interfaces.Repositories;
using Midway.Gleybe.Domain.Interfaces.Services;

namespace Midway.Gleybe.Application.Services.Contacts
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<Contact>> GetAllContacts(bool withDeleted)
        {
            return await _contactRepository.GetAllContacts(withDeleted);
        }

        public async Task<Contact> GetContactById(Guid contactId)
        {
            return await _contactRepository.GetContactById(contactId);
        }

        public async Task<IEnumerable<Contact>> SearchContacts(string name = "", string phone = "", string email = "")
        {
            return await _contactRepository.SearchContacts(name, phone, email);
        }

        public async Task AddContact(Contact contact)
        {
            await _contactRepository.AddContact(contact);
        }

        public async Task UpdateContact(Contact contact)
        {
            await _contactRepository.UpdateContact(contact);
        }

        public async Task DeleteContact(Guid contactId)
        {
            await _contactRepository.DeleteContact(contactId);
        }
    }
}
