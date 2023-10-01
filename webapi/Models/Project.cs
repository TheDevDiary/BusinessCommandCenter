using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } // Nullable DateTime
        public ProjectStatus Status { get; set; } = ProjectStatus.Active;
        public int ManagerId { get; set; }
        public User Manager { get; set; }

        public Project()        {
            Status = ProjectStatus.Active;
        }
    }

    public enum ProjectStatus
    {
        Active,
        InProgress,
        Completed,
        OnHold,
        Canceled
    }
}
