using AgendaApi.Data;
using AgendaApi.Models;
using Microsoft.EntityFrameworkCore;

public class ContactRepository : IContactRepository
{
    private readonly AgendaDbContext _context;

    public ContactRepository(AgendaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contact>> GetAllContactsAsync()
    {
        return await _context.Contacts.ToListAsync();
    }

    public async Task<Contact?> GetContactByIdAsync(int id)
    {
        return await _context.Contacts.FindAsync(id);
    }

    public async Task AddContactAsync(Contact contact)
    {
        await _context.Contacts.AddAsync(contact);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateContactAsync(Contact contact)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteContactAsync(int id)
    {
        var contact = await GetContactByIdAsync(id);
        if (contact != null)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}
