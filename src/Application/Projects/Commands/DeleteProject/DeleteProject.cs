using AletheiaSoft.Application.Common.Interfaces;
using AletheiaSoft.Domain.Events;

namespace AletheiaSoft.Application.Projects.Commands.DeleteProject;

public record DeleteProjectCommand(int Id) : IRequest;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProjectCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Clients
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Clients.Remove(entity);

        /*entity.AddDomainEvent(new TodoItemDeletedEvent(entity));*/

        await _context.SaveChangesAsync(cancellationToken);
    }

}
