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
        [StringLength(10)] // Maybe redundant
        [Range(10, 10)]
        [RegularExpression(@"\d{10}")]
        public string phoneNumber { get; set; }

        [Required]
        [Range(6, 12)]
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