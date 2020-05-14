using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
           await Task.Run(LoadEmployees);
            //return base.OnInitializedAsync();
        }

        private void LoadEmployees()
        {
            System.Threading.Thread.Sleep(3000);

            //Employees = new List<Employee> { e1, e2, e3, e4 };

        }
    }
}
