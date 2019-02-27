using kymiraAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kymiraAPI
{
    //Class responsible for calculating the next pick up dates given a Site object and the current date
    public static class PickupDateCalculatorHelper
    {
        //Function that takes a site and the current date and will output an array of DateTimes (dates) of the site's next two collection dates
        //based on pickup days during the week and frequency
        public static DateTime[] CalculateNextPickupDates(Site site, DateTime currentDate)
        {

            return null;
        }
    }
}
