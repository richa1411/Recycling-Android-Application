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
    public class RegistrationObject
    {


        private String EmailAddress { get; }
        private String password { get; }
        private String PhoneNumber { get; }
        private String firstName { get; }
        private String lastName { get; }
        private String birthDate { get; }
        private String addressLine1 { get; }
        private String addressLine2 { get; }
        private String City { get; }
        private String province { get; }
        private String postalCode { get; }
        private bool checkBox { get; }



        public RegistrationObject(String EmailAdress, String Password, String PhoneNumber, String firstName, String lastName,
                                    String birthDate, String addressLine1, String addressLine2, String City, String province, String postalCode,
                                     bool checkBox)
        {

            this.EmailAddress = EmailAddress;

        }
        public RegistrationObject(String EmailAdress, String Password, String PhoneNumber, String firstName, String lastName,
                                    String birthDate, String addressLine1, String City, String province, String postalCode,
                                     bool checkBox){}


        public Boolean testStuff()
        {
            return true;
        }





        
    }
}