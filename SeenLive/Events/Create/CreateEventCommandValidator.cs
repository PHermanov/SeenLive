using FluentValidation;
using System;

namespace SeenLive.Events.Create;

public class CreateEventCommandValidator
    : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(e => e.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Name should be filled")
            .MaximumLength(100).WithMessage("Name is too long, limit is 100");
        
        RuleFor(e => e.Date)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Event date is required")
            .GreaterThan(new DateTime(1900, 1, 1)).WithMessage("Time travelers are not welcome");
           
        RuleFor(e => e.EventType)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Event type is required")
            .IsEnumName(typeof(EventType), false).WithMessage("Provide a valid EventType");
        
        RuleFor(e => e.LocationId).GreaterThan(0).WithMessage("Location is required");
    }
}