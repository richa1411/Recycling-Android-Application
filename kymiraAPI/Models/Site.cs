using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kymiraAPI.Models
{
    public class Site
    {
        [Key]
        [Required(ErrorMessage = "Sorry something went wrong, please try again in a few minutes")]
        [Range(0, int.MaxValue, ErrorMessage = "Sorry something went wrong, please try again in a few minutes")]
        public int siteID { get; set; }

        [Required(ErrorMessage = "")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Address must be 1 to 200 characters")]
        public string address { get; set; }

        
        public BinStatus binStatus { get; set; }

    }
}
