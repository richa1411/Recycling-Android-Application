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
        [Required(ErrorMessage = "Address cannot be an empty field")]
        [RegularExpression(@"^\d+\s[A-z]+\s[A-z]+", ErrorMessage = "Invalid Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Date is Required")]
        //Will Accept MM/DD/YYYY format
        [RegularExpression(@"^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$", ErrorMessage = "Invalid Date format")]
        public string collectionDate { get; set; }
    }
}