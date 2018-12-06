using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace kymiraAPI.Models
{
    /**
     * This model represents the pickup date object which will be sent to the 
     * app for display when a user requests their next two pickup dates 
     * */
    public class PickupDate
    {
        [Key]
        public int binID { get; set; }

        //Validators:
        //Address is required. If it is empty an error message will be displayed.
        //Also uses a regular expression for input that will allow for addresses in the format '### Address Dr"
        //address is restricted to 300 characters
        [Required(ErrorMessage = "Address cannot be an empty field")]
        [RegularExpression(@"^[\d\sA-z]+$", ErrorMessage = "Invalid Address")]
        [StringLength(200, ErrorMessage = "Address must be 200 characters or less")]
        public string binAddress { get; set; }

        //Validators:
        //Collection date is required. If it is empty an error message will be displayed.
        //Will Accept MM/DD/YYYY format
        [Required(ErrorMessage = "Collection Date cannot be an empty field")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$", ErrorMessage = "Invalid Date format")]
        public string collectionDate { get; set; }


    }
}
