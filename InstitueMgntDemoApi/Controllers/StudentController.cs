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
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }
        [HttpGet("{id:int}", Name = "GetStudentInfoById")]
        public async Task<ActionResult<StudentInfo>> GetStudentInfoById(int id)
        {
            try
            {
                var result = (await _studentRepository.GetStudentInfoById(id));
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

        [HttpGet("{email}", Name = "GetStudentInfoById")]
        public async Task<ActionResult<StudentInfo>> GetStudentInfoByEmail(string email)
        {
            try
            {
                var result = (await _studentRepository.GetStudentInfoByEmail(email));
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

        [HttpGet]
        public async Task<ActionResult> GetStudentInfos()
        {
            try
            {
                return Ok(await _studentRepository.GetStudentInfos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudentInfo>> CreateStudentInfo(StudentInfo studentInfo)
        {
            try
            {
                if (studentInfo == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var stdemail = _studentRepository.GetStudentInfoByEmail(studentInfo.Email);
                if(stdemail.Result != null)
                {
                    ModelState.AddModelError("EmailId", "Email Id Already exists");
                    return BadRequest(ModelState);
                }
                var createStudentInfo = await _studentRepository.AddStudentInfo(studentInfo);
                return CreatedAtAction(nameof(GetStudentInfoById),
                    new { id = createStudentInfo.StudentInfoId }, createStudentInfo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new studentInfo record");
            }

        }


    }
}
