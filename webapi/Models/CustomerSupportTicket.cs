using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class CustomerSupportTicket
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? ResolvedDate { get; set; }

        [Required]
        public int UserId { get; set; }

        // Additional properties related to customer support tickets
        public string AssignedTo { get; set; }
        public bool IsResolved { get; set; }
    }
}
