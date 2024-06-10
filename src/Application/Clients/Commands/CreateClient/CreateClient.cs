using AletheiaSoft.Application.Common.Interfaces;
using AletheiaSoft.Domain.Entities;

namespace AletheiaSoft.Application.Clients.Commands.CreateClient;

public record CreateClientCommand : IRequest<int>
{
    public string? FullName { get; init; }
    public string? Email { get; init; }
    public string? Phone { get; init; }
    public string? Adress { get; init; }
    public string? Note { get; init; }
}

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateClientCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var entity = new Client
        {
            FullName = request.FullName,
            Email = request.Email,
            Adress = request.Adress,
            Phone = request.Phone,
            Note = request.Note,
        };

        /*entity.AddDomainEvent(new TodoItemCreatedEvent(entity));*/

        _context.Clients.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
