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
    public class RecyclablesList
    {

        public RecyclablesList()
        {

        }


        [Required]
        public string name { get; set; }

        public string description { get; set; }

        public string imageURL { get; set; }

        public string turnedInto { get; set; }
        public string itemQuantity { get; set; }
        public string recycleReason { get; set; }
    }
}