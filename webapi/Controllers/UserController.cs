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
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace webapi.Controllers

{

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

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
        public async Task<IActionResult> Register([FromForm] User user)
        {
            try
            {
                // Validate the incoming user data
                if (user == null)
                {
                    return BadRequest("Invalid user data.");
                }


                // Check if the user already exists
                var existingUser = _context.Users.FirstOrDefault(u => u.Username == user.Username);
                if (existingUser != null)
                {
                    return BadRequest("Username is already taken. Please choose a different username or redirect to login");
                }

                // Hash the password for security
                user.Password = HashPassword(user.Password);

                // Save the user to the database
                _context.Users.Add(user);
                await _context.SaveChangesAsync(); // Save changes asynchronously

                // Return a success message or other relevant information
                return Ok("User registered successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Registration failed: " + ex.Message);
            }
        }

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


        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var user = _context.Users.FirstOrDefault(u =>
        u.Username == loginRequest.Username && u.Password == HashPassword(loginRequest.Password));

            if (user == null)
                return BadRequest("Invalid username or password.");

            // Generate a new authentication token
            user.AuthToken = Guid.NewGuid().ToString();

            // Save the updated user (including the new authentication token)
            _context.SaveChanges();

            // Return the token and user information (for demonstration purposes)
            return Ok(new { Token = user.AuthToken, User = user });
        }

        //private string GenerateJwtToken(User user)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes("your_secret_key"); // Replace with your actual secret key

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Username),
        //            new Claim(ClaimTypes.Role, user.Role.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(1), // Token expiration time
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}

        [HttpPost("Logout")]
        public ActionResult Logout(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
                return NotFound();

            // Clear the authentication token
            user.AuthToken = null;

            // Save the updated user (with the cleared authentication token)
            _context.SaveChanges();

            return Ok("User logged out successfully");
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
