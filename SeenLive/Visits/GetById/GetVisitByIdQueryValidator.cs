using FluentValidation;

namespace SeenLive.Visits.GetById;

public class GetVisitByIdQueryValidator : AbstractValidator<GetVisitByIdQuery>
{
    public GetVisitByIdQueryValidator()
    {
        RuleFor(v => v.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
    }
}