using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace KymiraApplication.Models
{
    /**
     *  This class contains definitions for a BinStatus object that will be saved to the database.
     *  When an excel sheet is added by an admin/Ken with the bin statuses, there may be other statuses other than
     *  Collected (1), Inaccessible (2) or Contaminated (3) --> therefore, any other status will be counted as a Bin Status of Inaccessible
     */
    public class BinStatus
    {
        public enum CollectionStatus { Collected = 1, Inaccessible = 2, Contaminated = 3 }

        [Key] 
        public int pickupID { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "BinID must be between 1 and 20 characters")]
        [RegularExpression("^[A-Z0-9 -]*$", ErrorMessage = "BinID is not valid")] //to hold a Bin serial number/ID code
        public string binID { get; set; }

        //1 -> Collected, 2 -> Inaccessible, 3 -> Contaminated
        [Range(1, 3, ErrorMessage = "A status can only be the value of 1, 2, or 3")]
        [EnumDataType(typeof(CollectionStatus), ErrorMessage = "A status can only be the value of 1, 2, or 3")]
        public CollectionStatus status { get; set; }

        [ForeignKey("Site")] //BinStatus(siteID(FK)) references Site(siteID(PK))
        public int siteID { get; set; }

        [Required(ErrorMessage = "Collection date is required")]
        [RegularExpression("^([12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01]))", ErrorMessage = "Collection date must be a valid date")]
        public string collectionDate { get; set; }

        public bool inactive { get; set; } //holds whether or not the BinStatus is inactive/"deleted" or not
    }

}