using AletheiaSoft.Application.Common.Interfaces;
using AletheiaSoft.Domain.Events;

namespace AletheiaSoft.Application.Clients.Commands.DeleteClient;

public record DeleteClientCommand(int Id) : IRequest;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteClientCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Clients
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Clients.Remove(entity);

        /*entity.AddDomainEvent(new TodoItemDeletedEvent(entity));*/

        await _context.SaveChangesAsync(cancellationToken);
    }

}
