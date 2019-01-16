﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace kymiraAPITest
{
   public class APIValidationHelper
    {
        
            public static List<ValidationResult> Validate(object model)
            {
                var results = new List<ValidationResult>();

                var validationContext = new ValidationContext(model, null, null);

                Validator.TryValidateObject(model, validationContext, results, true);

                if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);

                return results;
            }
        }
    
}
