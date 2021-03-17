using FluentValidation;

namespace SeenLive.Bands.Update
{
    public class UpdateBandCommandValidator
        : AbstractValidator<UpdateBandCommand> 
    {
        public UpdateBandCommandValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("Name should be filled!");
            RuleFor(b => b.Name).MaximumLength(100).WithMessage("Name is too long, limit is 100");
        }
    }
}