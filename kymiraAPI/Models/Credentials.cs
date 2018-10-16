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

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number is not 10 digits")]
        public string phoneNumber { get; set; }

        [Required]
        [RegularExpression("")] // TODO
        public string password { get; set; }

        public string validatePhoneNumber(string phoneNum)
        {
            throw new NotImplementedException();
        }

        public string validatePassword(string password)
        {
            throw new NotImplementedException();
        }
    }
}