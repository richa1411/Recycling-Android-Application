using System;

namespace KymiraAdmin.Models
{
    //this class helps to handle exceptions it has id that will bereturned with error sttaus code
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}