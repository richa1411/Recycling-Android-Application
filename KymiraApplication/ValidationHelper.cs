using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace KymiraApplication
{
    //Helper class that works with Data Annotation Validation to validate the Registration object that is sent by the application
    public class ValidationHelper
    {
        //Validate function that actually handles the validation
        public static List<ValidationResult> Validate(object model)
        {
            //Create a list for the validation results
            var results = new List<ValidationResult>();

            //Give the validator a validation context
            var validationContext = new ValidationContext(model, null, null);

            //Run the data annotation validation on the object
            Validator.TryValidateObject(model, validationContext, results, true);

            if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);

            //Return the list of validation results
            return results;
        }
    }
}