using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KymiraAdmin.Models
{
    public class FAQ
    {
        [Key] //auto-incrementing primary key
        public int id { get; set; }

        //Set required for the question field so the question MUST be populated, if the question field is empty
        //an error message of "Question is Required" will be displayed -- also must be in the range of 15-255 characters
        [Required(ErrorMessage = "Question cannot be empty")]
        [StringLength(255, MinimumLength = 15, ErrorMessage = "Question must be between 15 - 255 characters")]
        public string question { get; set; }

        //answer field is used to authenticate whether the answer exists in the database (is required for a valid FAQ object)
        [Required(ErrorMessage = "Answer cannot be empty")]
        public string answer { get; set; }

        //the status of the answer whether it has been deleted and is no longer visible to users
        public bool inactive { get; set; }

    }
}
