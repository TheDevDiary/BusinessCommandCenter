using System;
using System.Collections.Generic;
using webapi.Models;

public interface IDashboardRepository
{
    Dashboard GetDashboardById(int userId);
    void AddDashboard(Dashboard dashboard);
    void UpdateDashboard(Dashboard dashboard);
    void DeleteDashboard(int dasboardId);
}
