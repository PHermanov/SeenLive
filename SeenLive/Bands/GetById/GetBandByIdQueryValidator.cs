using FluentValidation;

namespace SeenLive.Bands.GetById;

public class GetBandByIdQueryValidator : AbstractValidator<GetBandByIdQuery>
{
    public GetBandByIdQueryValidator()
    {
        RuleFor(b => b.Id).GreaterThan(0).WithMessage("Id should be greater then 0");
    }
}