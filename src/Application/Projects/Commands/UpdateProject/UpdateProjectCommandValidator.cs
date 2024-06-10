namespace AletheiaSoft.Application.Projects.Commands.UpdateProject;

public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator()
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
