using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KymiraApplication.Models
{
    public class Site
    {
        /**
         * A Site object is associated with many BinStatus objects.
         **/

        [Key] //the primary key for a Site object, the decoration below makes it so that this is not auto-incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(1, int.MaxValue, ErrorMessage = "The siteID must be a valid integer")]
        public int siteID { get; set; }

        [StringLength(200, MinimumLength = 1, ErrorMessage = "Address must be 1 to 200 characters")]
        public string address { get; set; }
        
        //a list of the associated bin status objects
        public List<BinStatus> binStatus { get; set; }

    }
}
