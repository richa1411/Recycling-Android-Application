using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace KymiraApplication
{
    public class ValidationHelper
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