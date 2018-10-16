using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace kymiraAppTest
{
   public class Credentials : IValidatableObject
    {
        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(10,MinimumLength =10, ErrorMessage = "Phonenumber Should be of 10 characters")]
        [DataType(DataType.PhoneNumber)]
        public string phoneNumber;


        [Required(ErrorMessage = "Password is required")]
        [StringLength(50,MinimumLength =6,ErrorMessage ="Password must be in between 6 and 50 charcaters")]
        public string password;

      


        public string getPhone()
        {
            return this.phoneNumber;
        }
        public string getPassword()
        {
            return this.password;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           if (password.Length < 6 )
            {
                yield return new ValidationResult("Invalid password", new List<string> { "password" });
            }
        }
    }
}
