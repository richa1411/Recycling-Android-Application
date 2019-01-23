using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KymiraApplication.Models
{
    public class FAQ
    {
        //ID is extra for now but could prove to be beneficial if needing to pinpoint FAQ objects in the future
        //Perhaps we could use the ID to link the appropriate question and answer together
        public int ID { get; set; }

        //Set required for the question field so the question MUST be populated, if the question field is empty
        //an error message will be displayed
        [Required(ErrorMessage = "Question cannot be empty")]
        //Create a required range of 15 - 255 characters
        [StringLength(255, MinimumLength = 15, ErrorMessage = "Question must be between 15 - 255 characters")]
        public string question { get; set; }

        //answer field is used to authenticate whether the answer exists in the database
        [Required(ErrorMessage = "Answer cannot be empty")]
        public string answer { get; set; }

    }
}