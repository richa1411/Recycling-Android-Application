using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace kymiraAPI.Models
{
    public class Credentials
    {
        public int ID { get; set; }

        [Required (ErrorMessage = "Phone number is empty")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number is not 10 digits")]
        public string phoneNumber { get; set; }

        [Required (ErrorMessage ="Password is empty")]
        [StringLength(50,MinimumLength = 6, ErrorMessage = "Password must be between 6 - 50 characters")]
        public string password { get; set; }
    }
}