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
        [Required(ErrorMessage = "Phone number is required")]
    
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone Number is not 10 digits")]
        public string phoneNumber { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be in between 6 and 50 charcaters")]
        public string password { get; set; }

     

       
    }
}
