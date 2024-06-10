namespace AletheiaSoft.Application.Clients.Commands.CreateClient;

public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{
    public CreateClientCommandValidator()
    {
        RuleFor(v => v.FullName)
            .MaximumLength(200)
            .NotEmpty();
        
        RuleFor(v => v.Email)
            .EmailAddress()
            .NotEmpty();
        
        RuleFor(v => v.Phone)
            .MaximumLength(200)
            .NotEmpty();
        
        RuleFor(v => v.Adress)
            .MaximumLength(200);
        
        RuleFor(x => x.Note)
            .Cascade(CascadeMode.Stop)
            .Must(BeNullOrWhitespace)
            .WithMessage("MyField must be null or comply with the other rules if not null.")
            .When(x => !string.IsNullOrWhiteSpace(x.Note), ApplyConditionTo.CurrentValidator)
            .EmailAddress()
            .WithMessage("MyField must be a valid email address if provided.");
    }

    private bool BeNullOrWhitespace(string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }
}
