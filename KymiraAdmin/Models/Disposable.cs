using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KymiraAdmin.Models
{
    /**
     * This class is a disposable object used to store information to be displayed in an app, or stored in a database.
     * */
    public class Disposable
    {
        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int ID { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "name must be 50 characters or less.")]
        public string name { get; set; }


        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description must be 500 characters or less.")]
        public string description { get; set; }


        [Required(ErrorMessage = "PictureID is required")]
        [StringLength(90, ErrorMessage = "PictureID must be 90 characters or less")]
        public string imageURL { get; set; }


        [Required(ErrorMessage = "Disposable must have a recyclable/non-recyclable option")]
        public bool isRecyclable { get; set; }


        [Required(ErrorMessage = "Disposable must have a recyclable reason")]
        [StringLength(500, ErrorMessage = "Reason must be 500 characters or less.")]
        public string recycleReason { get; set; }


        [Required(ErrorMessage = "An end result is required")]
        [StringLength(500, ErrorMessage = "Result must be 500 characters or less.")]
        public string endResult { get; set; }


        [Required(ErrorMessage = "A qty recycled is required")]
        public int qtyRecycled { get; set; }

        [Required(ErrorMessage = "inactive cannot be null")]
        public bool inactive { get; set; }

    }
}
