using AgendaApi.Models;
using MediatR;

namespace AgendaApi.Queries
{
    public class GetContactByIdQuery : IRequest<Contact>
    {
        public int Id { get; }

        public GetContactByIdQuery(int id)
        {
            Id = id;
        }
    }
}
