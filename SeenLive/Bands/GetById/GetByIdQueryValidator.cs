using FluentValidation;

namespace SeenLive.Bands.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetBandByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(b => b.Id).GreaterThan(0).WithMessage("Id should be greater then 0");
        }
    }
}
