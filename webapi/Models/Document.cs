using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Document
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime UploadDate { get; set; }
        public string FilePath { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
