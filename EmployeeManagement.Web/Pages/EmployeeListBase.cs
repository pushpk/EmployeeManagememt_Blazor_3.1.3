using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<EmployeeManagement.Models.Employee> Employees { get; set; }

        [Inject]
        public IEmployeeService employeeService{ get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees =  await employeeService.GetEmployees();
           //await Task.Run(LoadEmployees);
            //return base.OnInitializedAsync();
        }

        private void LoadEmployees()
        {
            //Employee e1 = new Employee
            //{
            //    EmployeeId = 1,
            //    FirstName = "Max",
            //    LastName = "Hall",
            //    Email = "David@pragimtech.com",
            //    DateOfBrith = new DateTime(1980, 10, 5),
            //    Gender = Gender.Male,
            //    DepartmentId = 1,
            //    PhotoPath = "images/john.png"
            //};

            //Employee e2 = new Employee
            //{
            //    EmployeeId = 2,
            //    FirstName = "Ryan",
            //    LastName = "Patrick",
            //    Email = "Sam@pragimtech.com",
            //    DateOfBrith = new DateTime(1981, 12, 22),
            //    Gender = Gender.Male,
            //    DepartmentId = 1,
            //    PhotoPath = "images/sam.png"
            //};

            //Employee e3 = new Employee
            //{
            //    EmployeeId = 3,
            //    FirstName = "Sarah",
            //    LastName = "Taylor",
            //    Email = "mary@pragimtech.com",
            //    DateOfBrith = new DateTime(1979, 11, 11),
            //    Gender = Gender.Female,
            //    DepartmentId = 1,
            //    PhotoPath = "images/mary.png"
            //};

            //Employee e4 = new Employee
            //{
            //    EmployeeId = 3,
            //    FirstName = "Dale",
            //    LastName = "Reid",
            //    Email = "sara@pragimtech.com",
            //    DateOfBrith = new DateTime(1982, 9, 23),
            //    Gender = Gender.Female,
            //    DepartmentId = 1,
            //    PhotoPath = "images/sara.png"
            //};

            Employees = new List<EmployeeManagement.Models.Employee>();

        }
    }
}
