using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using webapi.Data;

namespace webapi.Data
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            builder.WebHost.ConfigureKestrel((context, options) =>
            {
                options.Limits.MaxRequestBodySize = 52428800; // 50 MB in bytes
            });


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy => policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                );
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, // Disable issuer validation
                    ValidateAudience = false, // Disable audience validation
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"))
                };
            });



            var app = builder.Build();
           

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            app.UseHttpsRedirection();

            // Use the custom role-based authorization middleware
            app.UseMiddleware<RoleAuthorizationMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }

    public class RoleAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var user = context.User;

            if (user != null && user.Identity.IsAuthenticated)
            {
                // Check if the user has the required role
                if (!IsUserAuthorized(user))
                {
                    context.Response.StatusCode = 403; // Forbidden
                    return;
                }
            }

            await _next(context);
        }

        private bool IsUserAuthorized(ClaimsPrincipal user)
        {
            // Check if the user has the 'Admin' role
            if (user.IsInRole("Admin"))
            {
                return true;
            }
               

            // Check if the user has the 'Manager' role
            if (user.IsInRole("Manager"))
            {

                return true;
            }

            // Check if user has the 'Employee' role
            if (user.IsInRole("Employee"))
            {
                return true;

            }

            return false; // Default to unauthorized
        }
    }
}
