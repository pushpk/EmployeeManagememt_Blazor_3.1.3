using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        public EmployeeManagement.Models.Employee employee { get; set; } = new EmployeeManagement.Models.Employee();

        [Inject]
        public IEmployeeService employeeService{ get; set; }

        protected override async Task OnInitializedAsync()
        {
            EmployeeManagement.Models.Employee emp =  await employeeService.GetEmployee(int.Parse(Id));
            employee = emp;

           //await Task.Run(LoadEmployees);
            //return base.OnInitializedAsync();
        }

   
    }
}
