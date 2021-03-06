﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kymiraAPI.Models
{
    public class Site
    {

        // This enum represents the pickup frequency,
        // either weekly or bi-weekly
        public enum PickupFrequency { Weekly = 1, BiWeekly = 2, Invalid = 0 }

        // This enum represents the collection days
        // This can be Sunday-Saturday
        [Flags]
        public enum PickupDays
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 4,
            Thursday = 8,
            Friday = 16,
            Saturday = 32,
            Sunday = 64,
            Invalid = 0
        }


        /**
         * A Site object is associated with many BinStatus objects.
         **/

        // Each new site will contain an empty list of BinStatus "children"
        public Site()
        {
            this.binStatus = new List<BinStatus>();
        }

        [Key]  //the primary key for a Site object, the decoration below makes it so that this is not auto-incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(1, int.MaxValue, ErrorMessage = "The siteID must be a valid integer")]
        public int siteID { get; set; }

        [StringLength(200, MinimumLength = 1, ErrorMessage = "Address must be 1 to 200 characters")]
        public string address { get; set; }

        //a list of the associated bin status objects
        public List<BinStatus> binStatus { get; set; }

        // This is how often a bin is collected 'Weekly', 'Bi-Weekly', etc.
        [Required(ErrorMessage = "Frequency is required")]
        [EnumDataType(typeof(PickupFrequency), ErrorMessage = "Pickup Frequency must be Weekly or BiWeekly")]
        [Range(1, 2, ErrorMessage = "Pickup Frequency must be Weekly or BiWeekly")]
        public PickupFrequency frequency { get; set; }

        // The 4 digit number (1004, 2003) that shows week and the day of the week
        // that a bin is collected.
        [Required(ErrorMessage = "At least one collection date must be specified")]
        [Range(1, 31, ErrorMessage = "Specified Pickup Days are invalid")]
        public PickupDays sitePickupDays { get; set; }

    }
}

