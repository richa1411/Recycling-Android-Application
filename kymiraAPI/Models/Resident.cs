using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kymiraAPI.Models
{
    public class Resident
    {
        [Range(1, 999999)]
        public int id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50,ErrorMessage = "First name must less then 50 characters.")]
        public string firstName { get; set; }

        [Required]
        [StringLength(50)]
        public string lastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime dateOfBirth { get; set; }

        [MaxLength(100)]
        [MinLength(6)]
        [EmailAddress]
        public string email { get; set; }

        [StringLength(10)]
        [Phone]
        public string phoneNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string address1 { get; set; }

        [MaxLength(200)]
        public string address2 { get; set; }

        [Required]
        [RegularExpression("^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$")]
        public string postalCode { get; set; }

        [Required]
        [StringLength(100)]
        public string province { get; set; }

        [Required]
        [MaxLength(100)]
        public string city { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(8)]
        public string password { get; set; }

    }
}
