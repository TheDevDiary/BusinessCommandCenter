using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace webapi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy => policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                 );
            });

            // Configure services, including DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  // Show detailed error page in development
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");  // Handle errors gracefully in production
                app.UseHsts();
            }

            app.UseRouting();

            app.UseCors("default");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("default");
            });

            app.UseHttpsRedirection();

        }


    }

}
