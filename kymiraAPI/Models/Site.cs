using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kymiraAPI.Models
{
    public class Site
    {
        [Key] //check to see nonautoincrementing id 
        [Required(ErrorMessage = "The siteID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The siteID must be a valid integer")]
        public int siteID { get; set; }

        [Required(ErrorMessage = "An address is required")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Address must be 1 to 200 characters")]
        public string address { get; set; }
        
        public List<BinStatus> binStatus { get; set; }

    }
}
