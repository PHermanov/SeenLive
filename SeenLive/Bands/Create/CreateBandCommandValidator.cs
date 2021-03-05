using FluentValidation;

namespace SeenLive.Bands.Create
{
    public class CreateBandCommandValidator 
        : AbstractValidator<CreateBandCommand> 
    {
        public CreateBandCommandValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("Name should be filled!");
            RuleFor(b => b.Name).MaximumLength(100).WithMessage("Name is too long, limit is 100");
        }
    }
}
