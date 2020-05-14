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

        Task<Employee> GetEmployeeByEmail(string employeeEmail);

        Task<Employee> AddEmployee(Employee employee);

        Task<Employee> DeleteEmployee(int employeeId);
        Task<Employee> EditEmployee(int id, Employee employee);



    }
}
