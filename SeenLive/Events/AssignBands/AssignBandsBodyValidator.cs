using FluentValidation;

namespace SeenLive.Events.AssignBands;

public class AssignBandsBodyValidator
    : AbstractValidator<AssignBandsBody>
{
    public AssignBandsBodyValidator()
    {
        RuleFor(x => x.BandIds).NotEmpty().WithMessage("BandIds must not be empty");
    }
}