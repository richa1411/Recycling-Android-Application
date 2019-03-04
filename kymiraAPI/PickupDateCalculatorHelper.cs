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

            if(site.frequency.Equals(Site.PickupFrequency.Invalid) || site.sitePickupDays.Equals(Site.PickupDays.Invalid))
            {
                return new List<string>();
            }

            double daysToAdd = 7 - (currentDate - lastPickupDate).TotalDays;

            //Problems: Multiple pickup days and the fact that the pickup days may be out of sync.

            //find how many days till the next day of the week.
            DateTime nextPickupDay = new DateTime();

            if(days == Site.PickupDays.Monday)
            {
                nextPickupDay = currentDate.AddDays(((int)currentDate.DayOfWeek + daysToAdd));
            }
            else if(days == Site.PickupDays.Tuesday)
            {
                nextPickupDay = currentDate.AddDays(((int)currentDate.DayOfWeek - (int)DayOfWeek.Tuesday) + daysToAdd);
            }
            else if (days == Site.PickupDays.Wednesday)
            {
                nextPickupDay = currentDate.AddDays(((int)currentDate.DayOfWeek - (int)DayOfWeek.Wednesday) + daysToAdd);
            }
            else if (days == Site.PickupDays.Thursday)
            {
                nextPickupDay = currentDate.AddDays(((int)currentDate.DayOfWeek - (int)DayOfWeek.Thursday) + daysToAdd);
            }
            else if (days == Site.PickupDays.Friday)
            {
                nextPickupDay = currentDate.AddDays(((int)currentDate.DayOfWeek - (int)DayOfWeek.Friday) + daysToAdd);
            }
            else if (days == Site.PickupDays.Saturday)
            {
                nextPickupDay = currentDate.AddDays(((int)currentDate.DayOfWeek - (int)DayOfWeek.Saturday) + daysToAdd);
            }
            else if (days == Site.PickupDays.Sunday)
            {
                nextPickupDay = currentDate.AddDays(((int)currentDate.DayOfWeek - (int)DayOfWeek.Sunday) + daysToAdd);
            }
            else
            {
                return new List<string>();
            }

            List<string> nextDates = new List<string>();

            //make the first item in the list equal the first date that came back
            nextDates.Add(nextPickupDay.ToShortDateString());

            //if it is a weekly pickup, add 7 days, if it is a biweekly pickup then add 14 days to the second date we will return
            if(site.frequency.Equals(Site.PickupFrequency.Weekly))
            {
                nextDates.Add(nextPickupDay.AddDays(7).ToShortDateString());
            }
            else
            {
                nextDates[0] = nextPickupDay.AddDays(15).ToShortDateString();
                nextDates.Add(nextPickupDay.AddDays(29).ToShortDateString());
            }
            return nextDates;
        }
    }
}
