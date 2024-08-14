using AgendaApi.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AgendaApi.Commands
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, bool>
    {
        private readonly IContactService _contactService;

        public DeleteContactCommandHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactService.GetContactByIdAsync(request.Id);
            if (contact == null)
            {
                return false;
            }

            await _contactService.DeleteContactAsync(request.Id);
            return true;
        }
    }
}
