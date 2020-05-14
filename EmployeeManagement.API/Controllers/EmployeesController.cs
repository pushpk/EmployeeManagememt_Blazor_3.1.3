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
        public async Task<ActionResult<Employee>> Post([FromBody] Employee employee)
        {
                try
                {
                var emp =  this.employeeRepository.GetEmployeeByEmail(employee.Email);

                if(emp != null)
                {
                    ModelState.AddModelError("email", "Employee Email already exist");
                    return BadRequest(ModelState);
                }

                    Employee createdEmployee = await this.employeeRepository.AddEmployee(employee);
                    return CreatedAtAction(nameof(Get), new { employeeId = createdEmployee.EmployeeId });
                    
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());

                }

        }

        // PUT: api/Employees/5
        [HttpPut("Edit/{id}")]
        public async Task<ActionResult<Employee>> Put(int id, [FromBody] Employee editedEmployee)
        {
            if(id != editedEmployee.EmployeeId)
            {
                return BadRequest("Emp Id Mismatch");
            }

           return await this.employeeRepository.EditEmployee(id, editedEmployee);
           
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {

            try
            {
                var emp = this.employeeRepository.GetEmployee(id);

                if (emp == null)
                {
                    return NotFound($"Employee {id} not found");
                }
                var deletedEmployee =  await employeeRepository.DeleteEmployee(id);
                return deletedEmployee;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message.ToString());

            }
         }
    }
}
