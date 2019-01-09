using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KymiraApplicationTests.Models
{
    /*
     * This Token class will hold the authentication token given by the backend once the credentials have passed
     * all the forms of validation and the user is cleared to login.
     * 
     * The token class will store the authentication token throughout the app while the user is logged in, and the other
     * app fragments will be able to verify that the users session has this token with them, that will guarantee to the 
     * other fragments that the user is properly logged in.
     */
   public class Token
    {
        //The token is required and must follow this format as created by the built in GUID function:
        //56f32541-8082-41e2-91a7-c2103859ff1c

        [Required(ErrorMessage = "Token can not be empty string")]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "token is not in proper GUID format")]
        public string token { get; set; }
    }
}
