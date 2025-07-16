using FluentValidation;

namespace Worker.Application.Workers.Commands.CreateWorker;

public class CreateWorkerCommandValidator : AbstractValidator<CreateWorkerCommand>
{
    public CreateWorkerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required.");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Password must be at least 6 characters.");
        RuleFor(x => x.Registration).GreaterThan(0).WithMessage("Registration must be greater than zero.");
        RuleFor(x => x.PositionId).NotEmpty().WithMessage("PositionId is required.");
    }
}