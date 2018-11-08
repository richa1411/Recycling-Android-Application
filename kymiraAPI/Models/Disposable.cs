using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace kymiraAPI.Models
{
    public class Disposable
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="")]
        [StringLength(50, ErrorMessage = "name must be 50 characters or less.")]
        public string name { get; set; }


        [Required(ErrorMessage = "")]
        [StringLength(500, ErrorMessage = "Description must be 500 characters or less.")]
        public string description { get; set; }

        public string picture { get; set; }
        [Required(ErrorMessage = "")]
        public bool isRecyclable { get; set; }


        [Required(ErrorMessage = "")]
        public string recyclableReason { get; set; }


        [Required(ErrorMessage = "")]
        public string endResult { get; set; }


        [Required(ErrorMessage = "")]
        public int qtyRecycled { get; set; }

    }
}
