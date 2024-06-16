
using AletheiaSoft.Application.Common.Interfaces;

namespace AletheiaSoft.Application.Projects.Commands.CreateProject;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    private readonly IApplicationDbContext _context;
    public CreateProjectCommandValidator(IApplicationDbContext context)
    {

        _context = context;
        
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
        
        RuleFor(v => v.Description)
            .NotEmpty();
        
        RuleFor(v => v.Budget)
            .NotEmpty();

        RuleFor(v => v.StartDate)
            .NotEmpty();

        RuleFor(v => v.LastDate)
            .NotEmpty();
        
        RuleFor(v => v.Currency)
            .NotEmpty();
        
        RuleFor(v => v.ClientId)
            .NotEmpty()
            .MustAsync(async (id, cancellation) => await ShouldExist(id))
            .WithMessage("Project with the specified ID does not exist.");

    }
    
    private async Task<bool> ShouldExist(int? id)
    {
        return await _context.Clients.AnyAsync(i => i.Id == id!);
    }
    
}
