using AletheiaSoft.Application.Common.Interfaces;

namespace AletheiaSoft.Application.Projects.Commands.UpdateProject;

public record UpdateProjectCommand : IRequest
{
    public int Id { get; init; }
    public string? Title { get; init; }                  
    public string? Description { get; init; }            
    public int? Budget { get; init; }                    
    public string? StartDate { get; init; }            
    public string? LastDate { get; init; }             
    public int? YearlyCost { get; init; }                
    public string? Currency { get; init; }               
    public string? YearlyPaymentDate { get; init; }    
}

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProjectCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Projects
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title;
        entity.Description = request.Description;
        entity.Budget = request.Budget;
        entity.StartDate = DateTime.Parse(request.StartDate!);  
        entity.LastDate = DateTime.Parse(request.LastDate!);  
        entity.Currency = request.Currency;
        entity.YearlyCost = request.YearlyCost;
        entity.YearlyPaymentDate = request.YearlyPaymentDate is not null ? DateTime.Parse(request.YearlyPaymentDate!) : null;  

        await _context.SaveChangesAsync(cancellationToken);
    }
}
