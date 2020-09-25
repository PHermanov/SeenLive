using FluentValidation;
using SeenLive.Models;
using SeenLive.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeenLive.Services.Validation
{
    public class BandValidator 
        : AbstractValidator<BandResourceCreate> 
    {
        public BandValidator()
        {
            RuleFor(b => b.AlternativeNames).NotEmpty().WithMessage("Иди нахуй");
        }
    }
}
