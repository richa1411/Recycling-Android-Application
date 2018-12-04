using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kymiraAPI.Models
{
    /**
     * This model represents the pickup date object which will be sent to the 
     * app for display when a user requests their next two pickup dates 
     * */
    public class PickupDate
    {
        public string binAddress;

        public string collectionDate;
    }
}
