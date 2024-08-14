using AgendaApi.Models;
using MediatR;

namespace AgendaApi.Commands
{
    public class AddContactCommand : IRequest<Contact>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public AddContactCommand(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}
