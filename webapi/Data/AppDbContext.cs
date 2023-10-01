using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        // DbSet properties for the entity classes
        public DbSet<User> Users { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<CRMIntegration> CRMIntegrations { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<TimeAttendance> TimeAttendances { get; set; }
        public DbSet<CustomerSupportTicket> CustomerSupportTickets { get; set; }
        public DbSet<MarketingCampaign> MarketingCampaigns { get; set; }
        public DbSet<HRDocument> HRDocuments { get; set; }
        public DbSet<FinancialTransaction> FinancialTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationships and foreign keys here
            modelBuilder.Entity<PerformanceReview>()
                .HasOne(pr => pr.Employee)
                .WithMany(e => e.PerformanceReviews)
                .HasForeignKey(pr => pr.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FinancialTransaction>()
                .Property(ft => ft.Amount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<MarketingCampaign>()
                .Property(mc => mc.Budget)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany()
                .HasForeignKey(e => e.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
