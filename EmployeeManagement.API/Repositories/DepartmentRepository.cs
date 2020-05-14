using EmployeeManagement.API.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _DbContext;

        public DepartmentRepository(AppDbContext dbContext)
        {
            this._DbContext = dbContext;

        }
        public Department GetDepartment(int departmentId)
        {
            return this._DbContext.Departments.FirstOrDefault(s => s.DepartmentId == departmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return this._DbContext.Departments.ToList();
        }
    }
}
