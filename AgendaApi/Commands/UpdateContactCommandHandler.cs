using AgendaApi.Models;
using AgendaApi.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AgendaApi.Commands
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Contact>
    {
        private readonly IContactService _contactService;

        public UpdateContactCommandHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<Contact> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var existingContact = await _contactService.GetContactByIdAsync(request.Id);
            if (existingContact == null)
            {
                return null;
            }

            existingContact.Name = request.Name;
            existingContact.Email = request.Email;
            existingContact.Phone = request.Phone;

            await _contactService.UpdateContactAsync(existingContact);

            return existingContact;
        }
    }
}
