using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KymiraApplication.Model
{
    public class PropertyStats
    {
        public int id { get; set; }

        //Validators:
        //Address must be required. If it is empty an error message will be displayed.
        //Also uses a regular expression for input that will allow for addresses in the format '### Address Dr"
        [Required(ErrorMessage = "Address cannot be an empty field")]
        [RegularExpression(@"^\d+\s[A-z]+\s[A-z]+", ErrorMessage = "Invalid Address")]
        public string Address { get; set; }

        //Will display the properties current points. Must be an integer
        [RegularExpression(@"^\d+$")]
        public int PropertyPoints { get; set; }



    }
}