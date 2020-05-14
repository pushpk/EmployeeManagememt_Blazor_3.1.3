using EmployeeManagement.API.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        public EmployeeRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;

        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
          var result =   await _dbContext.AddAsync(employee);
           
                await _dbContext.SaveChangesAsync();
                return result.Entity;
           
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(s => s.EmployeeId == employeeId);
            _dbContext.Remove(employee);

            try
            {
                await _dbContext.SaveChangesAsync();
                return employee;
            }
            catch (Exception)
            {

                return null;
            }


        }

        public async Task<Employee> EditEmployee(int id, Employee employee)
        {
            var result = await _dbContext.Employees.FirstOrDefaultAsync(s => s.EmployeeId == id);
           
            _dbContext.Entry(employee).State = EntityState.Modified;
            _dbContext.SaveChanges();
           
            return result;



        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var result = await _dbContext.Employees.FirstOrDefaultAsync(s => s.EmployeeId == employeeId);
            return result;
        }

        public  async Task<Employee> GetEmployeeByEmail(string employeeEmail)
        {
            var result = await _dbContext.Employees.FirstOrDefaultAsync(s => s.Email == employeeEmail);
            return result;

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var result = await _dbContext.Employees.ToListAsync();
            return result;

        }
    }
}
