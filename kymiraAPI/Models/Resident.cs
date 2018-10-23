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
        [StringLength(50, ErrorMessage = "First name must be 50 characters or less.")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be 50 characters or less.")]
        public string lastName { get; set; }

        [Required]
        [RegularExpression("^([12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01]))",ErrorMessage = "Birth date must be a valid date.")]
        public string birthDate { get; set; }

        [MaxLength(100, ErrorMessage = "Email must be 100 characters or less.")]
        [EmailAddress(ErrorMessage = "Email must be in email address format.")]
        [Required(ErrorMessage = "Email is required.")]
        public string email { get; set; }

        [RegularExpression("[0-9]{10}", ErrorMessage = "Phone number must be in phone number format.")]
        [Required(ErrorMessage = "Phone number is required.")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "Address line 1 is required.")]
        [MaxLength(200, ErrorMessage = "Address line 1 must be 200 characters or less.")]
        public string addressLine1 { get; set; }

        [MaxLength(200, ErrorMessage = "Address line 2 must be 200 characters or less.")]
        public string addressLine2 { get; set; }

        [Required(ErrorMessage = "Postal code is required and must be 6 characters.")]
        [RegularExpression("^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$", ErrorMessage = "Postal code is required and must be 6 characters in the Canadian postal code format.")]
        public string postalCode { get; set; }

        [Required(ErrorMessage = "Province is required.")]
        [StringLength(100, ErrorMessage = "Province must be 100 characters or less.")]
        public string province { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [MaxLength(100, ErrorMessage = "City must be 100 characters or less.")]
        public string city { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be 50 characters or less.")]
        public string password { get; set; }

    }
}
