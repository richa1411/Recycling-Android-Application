using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KymiraAdmin.Models
{
    public class Site
    {
        /**
         * A Site object is associated with many BinStatus objects.
         **/

        // Each new site will contain an empty list of BinStatus "children"
        public Site()
        {
            this.binStatus = new List<BinStatus>();
        }

        [Key]  //the primary key for a Site object, the decoration below makes it so that this is not auto-incrementing
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(1, int.MaxValue, ErrorMessage = "The siteID must be a valid integer")]
        public int siteID { get; set; }

        [StringLength(200, MinimumLength = 1, ErrorMessage = "Address must be 1 to 200 characters")]
        public string address { get; set; }

        //a list of the associated bin status objects
        public List<BinStatus> binStatus { get; set; }



        // This is how often a bin is collected 'Weekly', 'Bi-Weekly', etc.
        public string frequency { get; set; }

        // This is the "Address Number" of the place on the street. i.e. '1160' 33rd St.
        public string stNumber { get; set; }

        // This is the street name i.e. '33rd', 'Idylwyld"
        public string stName { get; set; }

        // This is the Street Suffix, i.e. St, Ave, Dr, etc.
        public string stSuffix { get; set; }

        // This is the 'direction' of the street i.e. The 'W' in 33rd St. W
        public string stDirection { get; set; }

        // The 4 digit number (1004, 2003) that shows week and the day of the week
        // that a bin is collected.
        public string collection1 { get; set; }
        public string collection2 { get; set; }
        public string collection3 { get; set; }
        public string collection4 { get; set; }
    }
}
