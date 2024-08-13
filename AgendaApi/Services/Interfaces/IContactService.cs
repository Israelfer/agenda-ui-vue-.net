using AgendaApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaApi.Services.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(int id);
        Task AddContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(int id);
        Task<bool> ContactExists(int id);
    }
}
