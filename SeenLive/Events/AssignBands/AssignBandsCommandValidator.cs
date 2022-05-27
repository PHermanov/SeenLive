using FluentValidation;

namespace SeenLive.Events.AssignBands;

public class AssignBandsCommandValidator
    : AbstractValidator<AssignBandsCommand>
{
    public AssignBandsCommandValidator()
    {
        RuleFor(x => x.EventId).GreaterThan(0).WithMessage("EventId must be greater than 0");
        RuleFor(x => x.BandIds).NotEmpty().WithMessage("BandIds must not be empty");
    }
}