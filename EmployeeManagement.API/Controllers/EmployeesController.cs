using System;
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
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await this.employeeRepository.GetEmployees());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());

            }
           
        }

        // GET: api/Employees/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult> Get(int employeeId)
        {
            try
            {
                return Ok(await this.employeeRepository.GetEmployee(employeeId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());

            }

        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Employee employee)
        {
            if(ModelState.IsValid)
             {
                try
                {
                    Employee createdEmployee = await this.employeeRepository.AddEmployee(employee);
                    CreatedAtAction(nameof(Get), new { employeeId = createdEmployee.EmployeeId });
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());

                }

            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Required fields are missing");
            }
        }

        // PUT: api/Employees/5
        [HttpPut("Edit/{id}")]
        public void Put(int id, [FromBody] Employee editedEmployee)
        {
            this.employeeRepository.EditEmployee(id, editedEmployee);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
