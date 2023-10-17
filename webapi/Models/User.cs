using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
        public UserRole Role { get; set; }
        public string AuthToken { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Manager,
        Employee
    }
}
