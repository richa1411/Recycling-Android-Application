using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
    }
}
