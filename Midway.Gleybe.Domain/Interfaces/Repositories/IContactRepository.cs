using Midway.Gleybe.Domain.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midway.Gleybe.Domain.Interfaces.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContacts(bool withDeleted);

        Task<Contact> GetContactById(Guid contactId);

        Task<IEnumerable<Contact>> SearchContacts(string name = "", string phone = "", string email = "");

        Task AddContact(Contact contact);

        Task UpdateContact(Contact contact);

        Task DeleteContact(Guid contactId);
    }
}
