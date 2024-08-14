using AgendaApi.Models;
using AgendaApi.Services.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AgendaApi.Queries
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<Contact>>
    {
        private readonly IContactService _contactService;

        public GetAllContactsQueryHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IEnumerable<Contact>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            return await _contactService.GetAllContactsAsync();
        }
    }
}
