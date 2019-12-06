using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using MAMSys.Entites.Concrete;

namespace MAMSys.Business.ValidationRules.FluentValidation
{
   public class CanliValidator:AbstractValidator<Canli>
    {
        public CanliValidator()
        {
            RuleFor(x => x.Adi).NotEmpty().WithMessage("Adi alanı boş olamaz.");

        }
    }
}
