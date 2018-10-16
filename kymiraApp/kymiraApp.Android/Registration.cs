using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace kymiraApp.Droid
{
    public class Registration
    {


        public String emailAddress { get; }
        public String password { get; }
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


    }
}