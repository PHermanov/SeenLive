using FluentValidation;

namespace SeenLive.Bands
{
    public class BandValidator 
        : AbstractValidator<BandResourceCreate> 
    {
        public BandValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("Name should be filled!");
            RuleFor(b => b.Name).MaximumLength(100).WithMessage("Name is too long, limit is 100");
        }
    }
}
