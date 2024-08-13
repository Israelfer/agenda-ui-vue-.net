using FluentValidation;

public class ContactValidator : AbstractValidator<Contact>
{
    public ContactValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email format.");
        RuleFor(x => x.Phone).Matches(@"^\d{10,15}$").WithMessage("Phone number should be between 10 and 15 digits.");
    }
}
