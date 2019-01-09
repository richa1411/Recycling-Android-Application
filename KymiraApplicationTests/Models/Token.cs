using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KymiraApplicationTests.Models
{
   public class Token
    {

        [Required(ErrorMessage = "Token can not be empty string")]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "token is not in proper GUID format")]
       
        
        public string token { get; set; }
    }
}
