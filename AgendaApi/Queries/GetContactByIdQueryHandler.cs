using AgendaApi.Models;
using AgendaApi.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AgendaApi.Queries
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, Contact>
    {
        private readonly IContactService _contactService;

        public GetContactByIdQueryHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<Contact> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            return await _contactService.GetContactByIdAsync(request.Id);
        }
    }
}

