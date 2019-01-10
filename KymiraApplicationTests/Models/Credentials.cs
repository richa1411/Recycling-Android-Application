using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KymiraApplicationTests.Models
{
    public class Credentials
    {
        public int ID { get; set; }

        //Set required for the phone number so the phone number MUST be populated, if the phone number field is empty
        //an error message of "Phone number is empty" will be displayed
        [Required(ErrorMessage = "Please Enter your Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must be 10 digits")]
        public string phoneNumber { get; set; }

        //Password field is used to authenticate whether the password exists in the database
        [Required(ErrorMessage = "Please Enter your Password")] //TODO: Change password length to 8 character min
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be between 6 - 50 characters")]
        public string password { get; set; }


    }
}
