using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
        public UserRole Role { get; set; }

        // Additional properties related to user preferences, settings, etc.
        public string ProfileImage { get; set; }


        //Navigation properties for Entity Framework
        // Constructor
        public User() 
        {
            RegistrationDate = DateTime.UtcNow;
            IsActive = true;
        }

    }

    // User Roles
    public enum UserRole
    {
        Admin,
        Manager,
        Empolyee
        // ... Other Roles
    }
}
