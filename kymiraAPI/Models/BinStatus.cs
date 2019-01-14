using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kymiraAPI.Models
{
    /**
     *  This class contains definitions for a BinStatus object that will be saved to the database.
     *  When an excel sheet is added by an admin/Ken with the bin statuses, there may be other statuses other than
     *  Collected (1), Inaccessible (2) or Contaminated (3) --> therefore, any other status will be counted as a Bin Status of Inaccessible
     */
    public class BinStatus
    {
        [Key]
        [Required(ErrorMessage = "No bin was registered to that address")]
        [Range(0, int.MaxValue, ErrorMessage = "BinID must be a valid number")]
        public int binID { get; set; }

        
        [Range(1, 3, ErrorMessage = "A status can only be the value of 1, 2, or 3")]
        public int status { get; set; } //1 -> good, 2 -> blocked, 3 -> Contaminated

        public override string ToString()
        {
            return "";// "Bin ID: " + this.binID + "\t" + "Status: " + convertBinStatusToString(this.status); ;
        }

        [ForeignKey("Site")]
        public int siteID { get; set; }

        [Required(ErrorMessage = "Collection date is required")]
        [RegularExpression("^([12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01]))", ErrorMessage = "Collection date must be a valid date")]
        public string collectionDate { get; set; }
    }
}
