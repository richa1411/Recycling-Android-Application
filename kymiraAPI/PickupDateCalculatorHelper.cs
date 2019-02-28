﻿using kymiraAPI.Models;
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

            //find how many days till the next day of the week.
            DateTime nextPickupDay = new DateTime();

            if(days == Site.PickupDays.Monday)
            {
                nextPickupDay = DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Monday) + 7);
            }
            else if(days == Site.PickupDays.Tuesday)
            {
                nextPickupDay = DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Tuesday) + 7);
            }
            else if (days == Site.PickupDays.Wednesday)
            {
                nextPickupDay = DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Wednesday) + 7);
            }
            else if (days == Site.PickupDays.Thursday)
            {
                nextPickupDay = DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Tuesday) + 7);
            }
            else if (days == Site.PickupDays.Friday)
            {
                nextPickupDay = DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Friday) + 7);
            }
            else if (days == Site.PickupDays.Saturday)
            {
                nextPickupDay = DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Saturday) + 7);
            }
            else if (days == Site.PickupDays.Sunday)
            {
                nextPickupDay = DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Sunday) + 7);
            }
            else
            {

            }

            List<string> nextDates = new List<string>();

            

            if(freq == Site.PickupFrequency.BiWeekly)
            {
                nextDates.Add(nextPickupDay.AddDays(14).ToShortDateString());
            }

            nextDates.Add();

            return null;
        }
    }
}
