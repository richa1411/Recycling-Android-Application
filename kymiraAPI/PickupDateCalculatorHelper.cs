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
        public static List<string> CalculateNextPickupDates(Site site, DateTime currentDate)
        {
            var days = site.sitePickupDays;
            var freq = site.frequency;

            if(site.frequency.Equals(Site.PickupFrequency.Invalid) || site.sitePickupDays.Equals(Site.PickupDays.Invalid))
            {
                return new List<string>();
            }

            //Problems: Multiple pickup days and the fact that the pickup days may be out of sync.

            //find how many days till the next day of the week.
            DateTime nextPickupDay = new DateTime();

            if(days == Site.PickupDays.Monday)
            {
                nextPickupDay = DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Monday) - 1 );
            }
            else if(days == Site.PickupDays.Tuesday)
            {
                nextPickupDay = DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Tuesday) - 1 );
            }
            else if (days == Site.PickupDays.Wednesday)
            {
                nextPickupDay = DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Wednesday) - 1 );
            }
            else if (days == Site.PickupDays.Thursday)
            {
                nextPickupDay = DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Thursday) - 1 );
            }
            else if (days == Site.PickupDays.Friday)
            {
                nextPickupDay = DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Friday) - 1 );
            }
            else if (days == Site.PickupDays.Saturday)
            {
                nextPickupDay = DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Saturday) - 1 );
            }
            else if (days == Site.PickupDays.Sunday)
            {
                nextPickupDay = DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Sunday) - 1 );
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
