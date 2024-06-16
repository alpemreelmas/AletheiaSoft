using AletheiaSoft.Application.Common.Interfaces;
using AletheiaSoft.Domain.Entities;

namespace AletheiaSoft.Application.Projects.Commands.CreateProject;

public record CreateProjectCommand : IRequest<int>
{
        public string? Title { get; init; }
        public string? Description { get; init; }
        public int? Budget { get; init; }
        public string? StartDate { get; init; }
        public string? LastDate { get; init; }
        public int? YearlyCost { get; init; }
        public string? Currency { get; init; }
        public string? YearlyPaymentDate { get; init; }
        public int? ClientId { get; init; }
}

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProjectCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var entity = new Project
        {
            Title = request.Title,
            Description = request.Description,
            Budget = request.Budget,
            StartDate = DateTime.Parse(request.StartDate!),
            LastDate = DateTime.Parse(request.LastDate!),
            Currency = request.Currency,
            YearlyCost = request.YearlyCost,
            ClientId = request.ClientId,
            YearlyPaymentDate =  request.YearlyPaymentDate is not null ? DateTime.Parse(request.YearlyPaymentDate!) : null
        };

        /*entity.AddDomainEvent(new TodoItemCreatedEvent(entity));*/

        _context.Projects.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
