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

namespace KymiraApplication.Models
{
    /**
     *  This class defines a BinStatus object that will be returned from the backend of the application 
     *  (upon searching for matching Bins at a certain location/address)
     */
    public class BinStatus
    {
        [Required(ErrorMessage = "No bin was registered to that address")]
        [Range(0, int.MaxValue, ErrorMessage = "Sorry something went wrong, please try again in a few minutes")]
        public int binID { get; set; }

        [StringLength(200, MinimumLength = 1, ErrorMessage = "Address must be 1 to 200 characters")]
        public string binAddress { get; set; }

        [Range(1, 3, ErrorMessage = "Sorry something went wrong, please try again in a few minutes")]
        public int status { get; set; } //1 -> good, 2 -> blocked, 3 -> Contaminated

        //add site id
    }

}