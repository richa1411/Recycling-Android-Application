using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace KymiraApplication.Model
{

   public class Credentials 
    {

      public Credentials()
      {

      }
        [Required(ErrorMessage = "Please Enter your Phone Number")]
    
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Incorrect Username or Password")]
        public string phoneNumber { get; set; }


        [Required(ErrorMessage = "Please Enter your Password")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Incorrect Username or Password")]
        public string password { get; set; }
    }
}
