using FluentValidation;
using SeenLive.Bands.CreateOrUpdate;

namespace SeenLive.Bands.Create;

public class CreateOrUpdateBandBodyValidator 
    : AbstractValidator<CreateOrUpdateBandBody> 
{
    public CreateOrUpdateBandBodyValidator()
    {
        RuleFor(b => b.Name).NotEmpty().WithMessage("Name should be filled!");
        RuleFor(b => b.Name).MaximumLength(100).WithMessage("Name is too long, limit is 100");
    }
}