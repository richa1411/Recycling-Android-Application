using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kymiraAPI.Models
{
    public class Resident
    {
        public int id { get; set; }
        private string firstName { get; }
        private string lastName { get; }
        private string dateOfBirth { get; }
        private string email { get; }
        private string phoneNumber { get; }
        private string address1 { get; }
        private string address2 { get; }
        private string postalCode { get; }
        private string province { get; }
        private string city { get; }
        private string password { get; }

        /**
         * Public constructor of a Resident object. All attributes are required -- email OR phoneNumber is required.
         */
        public Resident(string firstName,string lastName, string dateOfBirth, string email, string phoneNumber, string address1, string address2, string postalCode, string province, string city, string password)
        {
            //create a new id - start with 0000001
        }

        public override string ToString()
        {
            return "";  //can return id padded with 0s if desired
        }

    }
}
