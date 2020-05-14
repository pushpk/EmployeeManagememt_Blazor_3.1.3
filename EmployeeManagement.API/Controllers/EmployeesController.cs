﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.API.Data;
using EmployeeManagement.API.Repositories;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeesController(IEmployeeRepository empRepo)
        {
            this.employeeRepository = empRepo;

        }
        // GET: api/Employees
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await this.employeeRepository.GetEmployees();
           
        }

        // GET: api/Employees/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Employee> Get(int employeeId)
        {
            return await this.employeeRepository.GetEmployee(employeeId);

        }

        // POST: api/Employees
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
           
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
