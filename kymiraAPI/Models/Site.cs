using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kymiraAPI.Models
{
    public class Site
    {
        // Each new site will contain an empty list of BinStatus "children"
        public Site()
        {
            this.binStatus = new List<BinStatus>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(1, int.MaxValue, ErrorMessage = "The siteID must be a valid integer")]
        public int siteID { get; set; }
        
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Address must be 1 to 200 characters")]
        public string address { get; set; }
        
        public List<BinStatus> binStatus { get; set; }

    }
}
