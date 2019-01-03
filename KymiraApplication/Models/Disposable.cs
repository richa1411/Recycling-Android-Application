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
using System.ComponentModel.DataAnnotations;

namespace KymiraApplication

{
    public class Disposable
    {

        public Disposable()
        {

        }

        public Disposable(string name, string description, string imageURL, bool isRecyclable, string endResult, int qtyRecycled, string recycleReason )
        {
            this.name = name;
            this.description = description;
            this.endResult = endResult;
            this.isRecyclable = isRecyclable;
            this.qtyRecycled = qtyRecycled;
            this.recycleReason = recycleReason;
            this.imageURL = imageURL;
        }

        //The name is required to be a valid disposable 
        //The name must be at least 3 characters long and cannot exceed 15
        [Required(ErrorMessage = "No name is present")]
        [MinLength(3)]
        [MaxLength(15)]
        public string name { get; set; }

        //Desriptions are optional
        public string description { get; set; }

        //An image is required to be displayed on the button
        //if an image does not exist, set it to a placeholder
        [Required]
        public string imageURL { get; set; }

        //isRecyclable is a boolean in a disposable object that
        //states whether the item is disposable or not. it is 
        //required because that is what is used to query for 
        //the list in the application.
        [Required]
        public bool isRecyclable { get; set; }

        //The end result is optional
        public string endResult { get; set; }
        //the quanity recycled is optinal 
        public int qtyRecycled { get; set; }
        //the reason it is or isn't recycalbe is optional 
        public string recycleReason { get; set; }
    }
}