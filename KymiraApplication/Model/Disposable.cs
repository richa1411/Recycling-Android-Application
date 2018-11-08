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
    public class Disposable //change name MaterialInfo
    {

        public Disposable()
        {

        }


        [Required(ErrorMessage = "No name is present")]
        [MinLength(3)]
        [MaxLength(15)]
        public string name { get; set; }

        public string description { get; set; }

        public string imageURL { get; set; }

        [Required]
        public bool isRecyclable { get; set; }
        public string endResult { get; set; }
        public int qtyRecycled { get; set; }
        public string recycleReason { get; set; }
    }
}