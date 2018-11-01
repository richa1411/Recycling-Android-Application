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
    public class Bin
    {

        [Required(ErrorMessage = "ID is invalid")]
        public int binID;


        [Required(ErrorMessage = "Name is Invalid")]
        public string binName; //user friendly bin name, something like: '[AddressName] Bin 1'

        [Required(ErrorMessage = "addressID is invalid")]
        public int addressID;

        [Required(ErrorMessage = "binStatus is invalid")]
        public int binStatus; //1 -> good, 2 -> blocked, 3 -> Contaminated

        [Required(ErrorMessage = "pickupFrequency is invalid")]
        public int pickupFrequency; //weekly, bi-weekly, etc. (How many times a week it is picked up)(1/2 = every second week)

        [Required(ErrorMessage = "pickupDay is invalid")]
        public int[] pickupDay; //number (1-5) (Monday-Friday)





     
    }
}