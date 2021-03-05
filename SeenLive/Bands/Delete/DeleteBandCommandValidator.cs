using FluentValidation;

namespace SeenLive.Bands.Delete
{
    public class DeleteBandCommandValidator : AbstractValidator<DeleteBandCommand>
    {
        public DeleteBandCommandValidator()
        {
            RuleFor(b => b.Id).GreaterThan(0).WithMessage("Id should be greater then 0");
        }
    }
}
