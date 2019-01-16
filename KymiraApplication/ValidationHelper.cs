using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace KymiraApplication
{
    /*
     * Validation helper class
     * it takes model class object as parameter
     * it returns list of errors basically it creates new list
     * it validates properties from model class and checks whether it matches with data annotation that we have put
     * 
     */
    class ValidationHelper
    {
        public static IList<ValidationResult> Validate(object model)
        {
            var results = new List<ValidationResult>(); //makes a new List

            var validationContext = new ValidationContext(model, null, null);
            // Validation context class describes the type or member on which validation is performed

            Validator.TryValidateObject(model, validationContext, results, true); //validates object of model class taking it as parameter

            if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);

            return results; //returns list of validations 
        }
    }
}