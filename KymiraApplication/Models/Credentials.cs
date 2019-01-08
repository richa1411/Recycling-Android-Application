using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace KymiraApplication.Models
{
    /* Model class
     * Properties: String Phonenumber, string Password
     */
   public class Credentials 
    {
        //default constructor
      public Credentials()
      {

      }
        //Data annotation for Required field
        [Required(ErrorMessage = "Please Enter your Phone Number")]
        //data annoatation with Regular expression that checks if phone number has all digits 
                //and its 10 digits in length
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Incorrect Username or Password")]
        public string phoneNumber { get; set; } //getter and setter for phone number field

        //Data annoatation for Required field with error message
        [Required(ErrorMessage = "Please Enter your Password")]
        //Data annotation that checks string length for password string wheteher its 6 to 50 characters length
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Incorrect Username or Password")]
        public string password { get; set; } ////getter and setter for password field
    }
}
