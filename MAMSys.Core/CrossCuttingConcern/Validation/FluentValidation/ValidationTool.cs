﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAMSys.Core.CrossCuttingConcern.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {

            var result = validator.Validate(entity);
            if (!result.IsValid)
            {
                throw  new ValidationException(result.Errors);
            }
        }
    }
}
