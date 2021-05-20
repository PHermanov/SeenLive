using FluentValidation;
using System;

namespace SeenLive.Events.Create
{
    public class CreateEventCommandValidator
        : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Name should be filled!");
            RuleFor(e => e.Name).MaximumLength(100).WithMessage("Name is too long, limit is 100");
            RuleFor(e => e.Date).NotEmpty().WithMessage("Event date is required");
            RuleFor(e => e.Date).GreaterThan(new DateTime(1900, 1, 1)).WithMessage("Time travelers are not welcome");
            RuleFor(e => e.EventType).IsEnumName(typeof(EventType), false).WithMessage("Provide a valid EventType");
        }
    }
}
