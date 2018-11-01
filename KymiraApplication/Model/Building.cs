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
    public class Building
    {
        [Required(ErrorMessage = "addressID is invalid")]
        public int addressID; //addressID number


        [Required(ErrorMessage = "addressName is invalid")]
        [StringLength(1, ErrorMessage = "Must be a string")]
        public string addressName; //to be compared to AddressLine1 and AddressLine2 in Resident


        [Required(ErrorMessage = "NbhdID is invalid")]
        public int NbhdID; // neighbourhood number 



        public Building()
        {

        }
    }
}