using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kymiraAPI.Models
{
    /**
     *  This class contains definitions for a BinStatus object.
     *  When an excel sheet is added by an admin/Ken with the bin statuses, there may be other statuses other than
     *  Collected (1), Inaccessible (2) or Contaminated (3) --> therefore, any other status will be counted as a Bin Status of Inaccessible
     */
    public class BinStatus
    {
        [Key] //this is auto-incrementing -- need this because a single bin may have many records with different collectionDates
        public int pickupID { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "BinID must be a valid number")] //to hold a Bin serial number/ID code
        public int binID { get; set; }
        
        //1 -> Collected, 2 -> Inaccessible, 3 -> Contaminated
        [Range(1, 3, ErrorMessage = "A status can only be the value of 1, 2, or 3")]
        public int status { get; set; }
        
        [ForeignKey("Site")] //BinStatus(siteID(FK)) references Site(siteID(PK))
        public int siteID { get; set; }

        [Required(ErrorMessage = "Collection date is required")]
        [RegularExpression("^([12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01]))", ErrorMessage = "Collection date must be a valid date")]
        public string collectionDate { get; set; }
    }
}
