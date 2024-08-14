using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaApi.Data;
using AgendaApi.Models;
using AgendaApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AgendaContext _context;

        public ContactRepository(AgendaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task AddAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contact contact)
        {
            var existingContact = await _context
                .Contacts.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == contact.Id);

            if (existingContact == null)
            {
                throw new InvalidOperationException("Contact not found");
            }

            // Desanexa o contato existente
            _context.Entry(existingContact).State = EntityState.Detached;

            // Define o estado da entidade para 'Modified'
            _context.Entry(contact).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Contacts.AnyAsync(e => e.Id == id);
        }
    }
}
