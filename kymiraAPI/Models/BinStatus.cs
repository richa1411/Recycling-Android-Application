using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kymiraAPI.Models
{
    public class BinStatus
    {
        [Key]
        [Required(ErrorMessage = "No bin was registered to that address")]
        [Range(0, int.MaxValue, ErrorMessage = "Sorry something went wrong, please try again in a few minutes")]
        public int binID { get; set; }

        [StringLength(200, MinimumLength = 1, ErrorMessage = "Address must be 1 to 200 characters")]
        public string binAddress { get; set; }

        [Range(1, 3, ErrorMessage = "Sorry something went wrong, please try again in a few minutes")]
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
