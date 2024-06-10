
namespace AletheiaSoft.Application.Projects.Commands.CreateProject;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
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

    }
    
}
