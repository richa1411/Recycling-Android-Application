using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KymiraApplication.Models
{
    public class Site
    {
        [Key]
        [Range(1, int.MaxValue, ErrorMessage = "The siteID must be a valid integer")]
        public int siteID { get; set; }

        [StringLength(200, MinimumLength = 1, ErrorMessage = "Address must be 1 to 200 characters")]
        public string address { get; set; }
        
        public ICollection<BinStatus> binStatus { get; set; }

    }
}
