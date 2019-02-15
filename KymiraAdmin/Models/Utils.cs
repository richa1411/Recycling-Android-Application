using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KymiraAdmin.Models
{
    public class Utils
    {
        public static string shortAddress(string address, int maxLen)
        {
            if (address.Length > maxLen)
            {
                return address.Substring(0, maxLen) + "...";
            }
            return address;
        }

    }
}
