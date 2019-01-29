using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KymiraAdmin.Models
{
    public class BinStatus
    {
        [Key]
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
