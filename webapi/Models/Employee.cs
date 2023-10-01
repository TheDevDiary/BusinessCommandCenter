using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        // public Department Department { get; set; }
        public int ManagerId { get; set; }
        public Employee Manager { get; set; }
        public ICollection<PerformanceReview> PerformanceReviews { get; set; }
    }
}
