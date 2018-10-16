using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kymiraAPI.Models
{
    public class Resident
    {
        [Range(1, 999999)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        private string firstName { get; }

        [Required]
        [StringLength(50)]
        private string lastName { get; }

        [Required]
        [DataType(DataType.Date)]
        private DateTime dateOfBirth { get; }

        [MaxLength(100)]
        [MinLength(6)]
        [EmailAddress]
        private string email { get; }

        [StringLength(10)]
        [Phone]
        private string phoneNumber { get; }

        [Required]
        [MaxLength(200)]
        [MinLength(1)]        
        private string address1 { get; }

        [MaxLength(200)]
        private string address2 { get; }

        [Required]
        [StringLength(6)]
        private string postalCode { get; }

        [Required]
        [StringLength(100)]
        [MinLength(1)]
        private string province { get; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        private string city { get; }

        [Required]
        [MaxLength(50)]
        [MinLength(8)]
        private string password { get; }

    }
}
