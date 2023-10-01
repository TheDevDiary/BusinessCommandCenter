using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AppDbContext _dbContext;
        public DashboardRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Dashboard GetDashboardByUserId(int userId)
        {
            return _dbContext.Dashboards.Include(d => d.Widgets).FirstOrDefault(d => d.UserId == userId);
        }
        public void AddDashboard(Dashboard dashboard)
        {
            _dbContext.Dashboards.Add(dashboard);
            _dbContext.SaveChanges();
        }
        public void UpdateDashboard(Dashboard dashboard)
        {
            _dbContext.Dashboards.Update(dashboard);
            _dbContext.SaveChanges();
        }
        public void DeleteDashboard(int dashboardId)
        {
            var dashboard = _dbContext.Dashboards.Find(dashboardId);
            if(dashboard != null)
            {
                _dbContext.Dashboards.Remove(dashboard);
                _dbContext.SaveChanges();
            }
        }

        public Dashboard GetDashboardById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
