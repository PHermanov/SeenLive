using FluentValidation;

namespace SeenLive.Events.GetByBandId;

public class GetEventByBandIdQueryValidator : AbstractValidator<GetEventByBandIdQuery>
{
    public GetEventByBandIdQueryValidator()
    {
        RuleFor(b => b.Id).GreaterThan(0).WithMessage("Id should be greater then 0");
    }
}