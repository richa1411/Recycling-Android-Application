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
        public static List<string> CalculateNextPickupDates(Site site, DateTime currentDate, DateTime lastPickupDate)
        {
            var days = site.sitePickupDays;
            var freq = site.frequency;

            if(days.ToString().Count() > 9)
            {
                //find the next 
            }
            else
            {

            }

            if(site.frequency.Equals(Site.PickupFrequency.Invalid) || site.sitePickupDays.Equals(Site.PickupDays.Invalid))
            {
                return new List<string>();
            }

            double daysToAdd = 7 - (currentDate - lastPickupDate).TotalDays;

            //find how many days till the next day of the week.
            DateTime nextPickupDay = new DateTime();

    
            nextPickupDay = currentDate.AddDays(daysToAdd);      

            List<string> nextDates = new List<string>();

           
            //if it is a weekly pickup, add 7 days, if it is a biweekly pickup then add 14 days to the second date we will return
            if(site.frequency.Equals(Site.PickupFrequency.Weekly))
            {
                nextDates.Add(nextPickupDay.ToShortDateString());
                nextDates.Add(nextPickupDay.AddDays(7).ToShortDateString());
            }
            else
            {
                nextPickupDay = nextPickupDay.AddDays(7);
                nextDates.Add(nextPickupDay.ToShortDateString());
                nextPickupDay = nextPickupDay.AddDays(14);
                nextDates.Add(nextPickupDay.ToShortDateString());
                
            }
            return nextDates;
        }
    }
}
