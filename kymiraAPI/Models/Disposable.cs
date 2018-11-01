using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kymiraAPI.Models
{
    public class Disposable
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string picture { get; set; }
        public bool isRecyclable { get; set; }
        public string recyclableReason { get; set; }
        public string endResult { get; set; }
        public int qtyRecycled { get; set; }
    }
}
