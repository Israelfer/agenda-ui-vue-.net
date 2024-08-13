using AgendaApi.Models;
using AgendaApi.Repositories.Interfaces;
using AgendaApi.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _contactRepository.GetAllAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _contactRepository.GetByIdAsync(id);
        }

        public async Task AddContactAsync(Contact contact)
        {
            await _contactRepository.AddAsync(contact);
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            await _contactRepository.UpdateAsync(contact);
        }

        public async Task DeleteContactAsync(int id)
        {
            await _contactRepository.DeleteAsync(id);
        }

        public async Task<bool> ContactExists(int id)
        {
            return await _contactRepository.ExistsAsync(id);
        }
    }
}
