using System;
using System.Collections.Generic;
using webapi.Models;

namespace webapi.Data
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int employeeId);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
    }
}
