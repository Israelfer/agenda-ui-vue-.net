using AgendaApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaApi.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task AddAsync(Contact contact);
        Task UpdateAsync(Contact contact);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
