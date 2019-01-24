using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace KymiraApplicationTests
{
    //this validation helper class has a method called validate that will accept Model class's object,
    //and stores results of validating objects (error messages) in a list
    public class TestValidationHelper
    {
        public static List<ValidationResult> Validate(object model)
        {
            var results = new List<ValidationResult>();//variable that will store a list
            //initializing validationcontext class, that will check against two objects,
                //in this case data annotations in Model class
            var validationContext = new ValidationContext(model, null, null);
            //validates object of Model
            Validator.TryValidateObject(model, validationContext, results, true);
            //stores all validation results in result variable
            if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);

            return results;
        }
    }
}
