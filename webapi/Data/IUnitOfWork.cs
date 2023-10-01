using System;
using webapi.Data.Repositories;
using webapi.Models;


namespace webapi.Data
{
    public interface IUnitOfWork : IDisposable
    {
        // Add other repository interfaces here
        IUserRepository UserRepository { get; }
        IDashboardRepository DashboardRepository { get; }
        IProjectRepository ProjectRepository { get; }
        ICRMIntegrationRepository CRMIntegrationRepository { get; }
        IDocumentRepository DocumentRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IPerformanceReviewRepository PerformanceReviewRepository { get; }
        IVendorRepository VendorRepository { get; }
        ITimeAttendanceRepository TimeAttendanceRepository { get; }
        ICustomerSupportTicketRepository CustomerSupportTicketRepository { get; }
        IMarketingCampaignRepository MarketingCampaignRepository { get; }
        IHRDocumentRepository HRDocumentRepository { get; }
        IFinancialTransactionRepository FinancialTransactionRepository { get; }

    }
}
