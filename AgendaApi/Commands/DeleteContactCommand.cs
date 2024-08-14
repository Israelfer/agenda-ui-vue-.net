using MediatR;

namespace AgendaApi.Commands
{
    public class DeleteContactCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteContactCommand(int id)
        {
            Id = id;
        }
    }
}
