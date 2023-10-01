using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public Employee GetEmployeeById(int employeeId)
        {
            return _dbContext.Employees
                .Include(e => e.Manager)
                .FirstOrDefault(e => e.Id == employeeId);
        }
        public void AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }
        public void UpdateEmployee(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();
        }
        public void DeleteEmployee(int employeeId)
        {
            var employee = _dbContext.Employees.Find(employeeId);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
            }
        }
    }
}
