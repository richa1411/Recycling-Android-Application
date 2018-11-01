using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace KymiraApplication.Model
{
    public class Registration
    {


        [Required(ErrorMessage = "An email address is required")]
        [StringLength(100, MinimumLength=10, ErrorMessage = "Email address must be between 1 and 100 characters")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email address is not in a valid format")]
        public String emailAddress { get; set; }

        [Required(ErrorMessage = "A password is required")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 50 characters")]
        public String password { get; set; }

        [Required(ErrorMessage = "A phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must contain 10 digits")]
        public String phoneNumber { get; set; }

        [Required(ErrorMessage = "A first name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First name must be between 1 and 50 characters")]
        public String firstName { get; set; }

        [Required(ErrorMessage = "A last name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name must be between 1 and 50 characters")]
        public String lastName { get; set; }

        [Required(ErrorMessage = "A birth date is required")]
        [RegularExpression("^([12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01]))", ErrorMessage = "Birth date must be a valid date.")]
        public String birthDate { get; set; }

        [Required(ErrorMessage = "An Address is required")]
        [StringLength (200, MinimumLength=10, ErrorMessage ="The address must be between 10 and 200 characters")]
        public String addressLine1 { get; set; }

        [StringLength(200, ErrorMessage ="Must be less than 200 characters")]
        public String addressLine2 { get; set; }

        [Required(ErrorMessage = "A City is required")]
        [StringLength(100, MinimumLength =1, ErrorMessage ="The city must be between 1 and 100 characters")]
        public String city { get; set; }

        [Required(ErrorMessage = "A province is required")]
        [StringLength(100, MinimumLength =1, ErrorMessage ="The province must be between 1 and 100 characters ")]
        public String province { get; set; }

        [Required(ErrorMessage = "A postal code is required")]
        [RegularExpression("^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$", ErrorMessage = "Postal code is required and must be 6 characters in the Canadian postal code format.")]
        public String postalCode { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the terms and conditions")]
        public bool termsCheckBox { get; set; }

        public Registration()
        {

        }

        //Constructor for Registration object when the user only fills out addressLine1
        public Registration(String emailAddress, String Password, String PhoneNumber, String firstName, String lastName,
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
            this.termsCheckBox = checkBox;

        }

        //Constructor for Registration object when the user fills out both addressLine1 and addressLine2
        public Registration(String emailAddress, String Password, String PhoneNumber, String firstName, String lastName,
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
            this.termsCheckBox = checkBox;
        }
    }
}