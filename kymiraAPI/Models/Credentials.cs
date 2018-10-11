using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kymiraAPI.Models
{
    public class Credentials
    {
        public int ID { get; set; }
        public string phoneNumber { get; set; }

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