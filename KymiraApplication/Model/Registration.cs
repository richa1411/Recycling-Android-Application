using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace KymiraApplication.Model
{
    public class Registration : IValidatableObject
    {


        [Required(ErrorMessage = "An email address is required")]
        [StringLength(10, MinimumLength=10, ErrorMessage = "Email address must be between 1 and 100 characters")]
        public String emailAddress { get; }
        [Required(ErrorMessage = "A password is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Email address must be between 1 and 100 characters")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "]
        public String password { get; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number can only contain digits")]
        public String phoneNumber { get; }
        public String firstName { get; }
        public String lastName { get; }
        public String birthDate { get; }
        public String addressLine1 { get; }
        public String addressLine2 { get; }
        public String city { get; }
        public String province { get; }
        public String postalCode { get; }
        public bool checkBox { get; }


        public Registration()
        {

        }
        public Registration(String EmailAdress, String Password, String PhoneNumber, String firstName, String lastName,
                                    String birthDate, String addressLine1, String addressLine2, String City, String province, String postalCode,
                                     bool checkBox)
        {

            this.emailAddress = emailAddress;
            this.password = Password;
            this.phoneNumber = PhoneNumber;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.addressLine1 = addressLine1;
            this.addressLine2 = addressLine2;
            this.city = City;
            this.province = province;
            this.postalCode = postalCode;
            this.checkBox = checkBox;

        }
        public Registration(String EmailAdress, String Password, String PhoneNumber, String firstName, String lastName,
                                    String birthDate, String addressLine1, String City, String province, String postalCode,
                                     bool checkBox)
        {
            this.emailAddress = emailAddress;
            this.password = Password;
            this.phoneNumber = PhoneNumber;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.addressLine1 = addressLine1;
            this.city = City;
            this.province = province;
            this.postalCode = postalCode;
            this.checkBox = checkBox;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}