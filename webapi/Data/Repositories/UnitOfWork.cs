using Microsoft.EntityFrameworkCore;

namespace webapi.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IUnitOfWork _dbContext;
        public IUserRepository UserRepository { get; set; }
        public IDashboardRepository DashboardRepository { get; set; }
        public IProjectRepository ProjectRepository { get; set; }
        public ICRMIntegrationRepository CRMIntegrationRepository { get; set; }
        public IDocumentRepository DocumentRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IPerformanceReviewRepository PerformanceReviewRepository { get; set; }
        public IVendorRepository VendorRepository { get; set; }
        public ITimeAttendanceRepository TimeAttendanceRepository { get; set; }
        public ICustomerSupportTicketRepository CustomerSupportTicketRepository { get; set; }
        public IMarketingCampaignRepository MarketingCampaignRepository { get; set; }
        public IHRDocumentRepository HRDocumentRepository { get; set; }
        public IFinancialTransactionRepository FinancialTransactionRepository { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);  // Suppress finalization
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
