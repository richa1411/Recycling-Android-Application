using System;
using System.Collections.Generic;
using System.Text;

namespace kymiraApp
{
   public class Credentials
    {
        String phoneNumber;
        String password;
        public Credentials(String phoneNumber, String password)
        {
            this.phoneNumber = phoneNumber;
            this.password = password;
        }

       public String getPhone()
        {
            return this.phoneNumber;
        }
        public String getPass()
        {
            return this.password;
        }



    }
}
