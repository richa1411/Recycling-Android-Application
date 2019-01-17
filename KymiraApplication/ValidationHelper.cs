using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace KymiraApplication
{
    public class ValidationHelper
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