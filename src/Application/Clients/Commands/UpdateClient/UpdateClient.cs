using AletheiaSoft.Application.Common.Interfaces;

namespace AletheiaSoft.Application.Clients.Commands.UpdateClient;

public record UpdateClientCommand : IRequest
{
    public int Id { get; init; }

    public string? FullName { get; init; }
    public string? Email { get; init; }
    public string? Adress { get; init; }
    public string? Phone { get; init; }
    public string? Note { get; init; }
}

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateClientCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Clients
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.FullName = request.FullName;
        entity.Email = request.Email;
        entity.Adress = request.Adress;
        entity.Phone = request.Phone;
        entity.Note = request.Note;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
