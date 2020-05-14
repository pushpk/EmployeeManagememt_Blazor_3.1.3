using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Data
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int employeeId);

        void AddEmployee(Employee employee);

        Task<bool> DeleteEmployee(int employeeId);
        void EditEmployee(Employee employee);



    }
}
