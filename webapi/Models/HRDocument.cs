using System;
using System.ComponentModel.DataAnnotations;
using webapi.Models;

namespace webapi.Models
{
    public class HRDocument
    {
        public int Id { get; set; }
        [Required, MaxLength(100)] 
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime UploadDate { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public string FilePath { get; set; }
        public bool IsApproved { get; set; }
    }
}
