using AgendaApi.Models;
using MediatR;
using System.Collections.Generic;

namespace AgendaApi.Queries
{
    public class GetAllContactsQuery : IRequest<IEnumerable<Contact>>
    {
    }
}
