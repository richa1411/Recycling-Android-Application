using System;
using System.Collections.Generic;
using System.Text;

namespace kymiraApp
{
   public class Credentials
    {
        private string phoneNumber;
        private string password;

        public Credentials(string v1, string v2)
        {
            this.phoneNumber = v1;
            this.password = v2;
        }

        

        public String getPhone()
        {
            return this.phoneNumber;
        }
        public string getPassword()
        {
            return this.password;
        }
    }
}
