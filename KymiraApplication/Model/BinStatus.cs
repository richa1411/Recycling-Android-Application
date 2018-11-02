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

namespace KymiraApplication.Model
{
    public class BinStatus
    {

        [Required(ErrorMessage = "ID is invalid")]
        public int binID;

        [Required(ErrorMessage = "addressName is invalid")]
        public string binAddress;

        [Required(ErrorMessage = "status is invalid")]
        public int status; //1 -> good, 2 -> blocked, 3 -> Contaminated
        
     
    }
}