using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using webapi.Data;
using webapi.Models;
using System.Security.Cryptography;
using System.Text;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _context.Users;
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost("Register")]
        public ActionResult<User> Register([FromBody] User user)
        {
            try
            {
                // Remove the id from the request body
                user.Id = 0;  // Or set it to some default value

                // Set registration date to now
                user.RegistrationDate = DateTime.Now;

                // Assuming some default values for simplicity
                user.IsActive = true;
                user.Role = UserRole.Employee;

                // Add the user to the context
                _context.Users.Add(user);

                // Save changes to generate the id
                _context.SaveChanges();

                // Return the registered user
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest("Registration failed: " + ex.Message);
            }
        }

        // Helper function to hash the password (you need to implement this)
        private string HashPassword(string password)
        {
            using (var sha256 = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // PUT: api/Users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
