using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InstitueMgntDemoApi.Services;
using InstitueMgntDemoApiData;


namespace InstitueMgntDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await _employeeRepository.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}", Name = "GetEmployeeById")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                var result = (await _employeeRepository.GetEmployeeById(id));
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{email}", Name = "GetEmployeeByEmail")]
        public async Task<ActionResult<Employee>> GetEmployeeByEmail(string email)
        {
            try
            {
                var result = (await _employeeRepository.GetEmployeeByEmail(email));
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var empemail = _employeeRepository.GetEmployeeByEmail(employee.EmpEmail);
                if (empemail.Result != null)
                {
                    ModelState.AddModelError("EmailId", "Email Id Already exists");
                    return BadRequest(ModelState);
                }
                var createEmployee = await _employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployeeById),
                    new { id = createEmployee.EmpId }, createEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }

        }


    }
}
