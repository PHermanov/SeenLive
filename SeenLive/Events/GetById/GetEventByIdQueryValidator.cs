using FluentValidation;

namespace SeenLive.Events.GetById;

public class GetEventByIdQueryValidator : AbstractValidator<GetEventByIdQuery>
{
    public GetEventByIdQueryValidator()
    {
        RuleFor(b => b.Id).GreaterThan(0).WithMessage("Id must be greater then 0");
    }
}