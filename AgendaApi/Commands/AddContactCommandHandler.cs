using AgendaApi.Models;
using AgendaApi.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AgendaApi.Commands
{
    public class AddContactCommandHandler : IRequestHandler<AddContactCommand, Contact>
    {
        private readonly IContactService _contactService;

        public AddContactCommandHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<Contact> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone
            };

            await _contactService.AddContactAsync(contact);
            return contact;
        }
    }
}
