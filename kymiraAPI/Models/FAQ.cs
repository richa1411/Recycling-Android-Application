using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kymiraAPI.Models
{
    public class FAQ
    {
        public int ID { get; set; }
        //Set required for the question field so the question MUST be populated, if the question field is empty
        //an error message of "Qustion is Required" will be displayed
        [Required(ErrorMessage = "Question cannot be empty")]
        public string question { get; set; }
        //answer field is used to authenticate whether the answer exists in the database
        [Required(ErrorMessage = "Answer cannot be empty")]
        public string answer { get; set; }
    }
}
