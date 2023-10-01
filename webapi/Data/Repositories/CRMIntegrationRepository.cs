using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data.Repositories
{
    public class CRMIntegrationRepository
    {
        private readonly AppDbContext _dbContext;
        public CRMIntegrationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public CRMIntegration GetCRMIntegrationById(int integrationId)
        {
            return _dbContext.CRMIntegrations.Include(ci => ci.User)
                .FirstOrDefault(ci => ci.Id == integrationId);
        }
        public List<CRMIntegration> GetCRMIntegationsByUserId(int userId)
        {
            return _dbContext.CRMIntegrations.Where(ci => ci.UserId == userId).ToList();
        }
        public void AddCRMIntegration(CRMIntegration integration)
        {
            _dbContext.CRMIntegrations.Add(integration);
            _dbContext.SaveChanges();
        }
        public void UpdateCRMIntegration(CRMIntegration integration)
        {
            _dbContext.CRMIntegrations.Update(integration);
            _dbContext.SaveChanges();
        }
        public void DeleteCRMIntegration(int integrationId)
        {
            var integration = _dbContext.CRMIntegrations.Find(integrationId);
            if (integration != null)
            {
                _dbContext.CRMIntegrations.Remove(integration);
                _dbContext.SaveChanges();
            }
        }
    }
}
