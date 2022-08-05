using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImagesValidator : AbstractValidator<CarImage>
    {
        public CarImagesValidator()
        {
            RuleFor(c => c.CarId).NotNull();
        }
    }

}
