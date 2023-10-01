using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        [Required , MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required, MaxLength(100)]
        public string ContactPerson { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
