using InstitueMgntDemoApi.Services;
using InstitueMgntDemoApiData;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitueMgntDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }
        //[EnableCors]
        [HttpGet]
        // public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        public async Task<ActionResult> GetDepartments()
        {
            try
            {
                return Ok(await _departmentRepository.GetDepartments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}", Name ="GetDepartmentById")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            try
            {
                var result = (await _departmentRepository.GetDepartmentById(id));
                if(result == null)
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
        [HttpPost]
        public async Task<ActionResult<Department>> CreateDepartment(Department department)
        {
            try
            {
                if (department == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //var dep = getthe department by name to check it exits or not
                //if exists then 
                //ModelState.AddModelError("Name", "Dep name already exits");
                //return BadRequest(ModelState);

                var dep = _departmentRepository.GetDepartmentByName(department.DepartmentName);
                if (dep.Result != null)
                {
                    ModelState.AddModelError("DepartmentName", "Department Name Already exists");
                    return BadRequest(ModelState);
                }

                var createDepartment = await _departmentRepository.AddDepartment(department);
                return CreatedAtAction(nameof(GetDepartmentById),
                    new { id = createDepartment.DepartmentId }, createDepartment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new department record");
            }
            
        }

        [HttpGet("{Name}", Name = "GetDepartmentByName")]
        public async Task<ActionResult<Department>> GetDepartmentByName(string Name)
        {
            try
            {
                var result = (await _departmentRepository.GetDepartmentByName(Name));
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
    }
}
