﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace kymiraAPI.Models
{
    public class Credentials
    {
        public int ID { get; set; }

        //Set required for the phone number so the phone number MUST be populated, if the phone number field is empty
        //an error message of "Phone number is empty" will be displayed
        [Required (ErrorMessage = "Phone number is empty")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number is not 10 digits")]
        public string phoneNumber { get; set; }

        //Password field is used to authenticate whether the password exists in the database
        [Required (ErrorMessage ="Password is empty")]
        [StringLength(50,MinimumLength = 6, ErrorMessage = "Password must be between 6 - 50 characters")]
        public string password { get; set; }
    }
}