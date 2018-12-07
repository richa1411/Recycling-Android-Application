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
   public class BinCollectionDate
    {
        //add comments


        [Key]
        public int id { get; set; }
        //Validators:
        //Address must be required. If it is empty an error message will be displayed.
        //Also uses a regular expression for input that will allow for addresses in the format '### Address Dr"
        [Required(ErrorMessage = "Address cannot be an empty field")]
        [RegularExpression(@"^\d+\s[A-z]+\s[A-z]+", ErrorMessage = "Invalid Address")]
        public string Address { get; set; }

        //Validators:
        //Date must be required. If it is empty an error message will be displayed.
        //Also uses a regular expression for input that will allow for a date in the format MM/DD/YYYY format;
        //[Required(ErrorMessage = "Date is Required")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$", ErrorMessage = "Invalid Date format")]
        public string collectionDate1 { get; set; }
        //public string collectionDate{ get; set; }


        // [Required(ErrorMessage = "Date is Required")]
        //Will Accept MM/DD/YYYY format
        [RegularExpression(@"^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$", ErrorMessage = "Invalid Date format")]
       public string collectionDate2 { get; set; }


    }
}