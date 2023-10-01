using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class PerformanceReview
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public DateTime ReviewDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }  
        public int ReviewId { get; set; }
        public Employee Reviewer { get; set; }
    }
}
