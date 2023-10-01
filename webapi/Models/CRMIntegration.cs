using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class CRMIntegration
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string ApiKey { get; set; }
        public string EndPointUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        // Navigation Properties
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
