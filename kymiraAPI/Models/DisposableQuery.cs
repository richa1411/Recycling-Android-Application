using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace kymiraAPI.Models
{
    public class DisposableQuery
    {
        public int ID { get; set; }

        [Required]
        public string name { get; set; }

        public string description { get; set; }

        public string picture { get; set; }

        [Required]
        public bool isRecyclable { get; set; }

        public string recyclableReason { get; set; }

        public string endResult { get; set; }

        public int qtyRecycled { get; set; }

    }
}
