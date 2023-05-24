using Midway.Gleybe.Domain.Entities;

namespace Midway.Gleybe.Domain.Interfaces.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContacts(bool withDeleted);
        Task<Contact> GetContactById(Guid contactId);
        Task<IEnumerable<Contact>> SearchContacts(string name = "", string phone = "", string email = "");
        Task AddContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task DeleteContact(Guid contactId);
    }
}
