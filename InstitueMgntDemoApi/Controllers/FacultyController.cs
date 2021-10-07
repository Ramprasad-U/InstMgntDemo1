using InstitueMgntDemoApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstitueMgntDemoApiData;
using Microsoft.AspNetCore.Cors;

namespace InstitueMgntDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyController(IFacultyRepository facultyRepository)
        {
            this._facultyRepository = facultyRepository;
        }
        //[EnableCors("AnotherPolicy")]
        [HttpGet]
        public async Task<ActionResult> Getmysubjectlist()
        {
            return Ok (await _facultyRepository.mySubjectsList());
        }

        [HttpGet("{id}",Name = "GetFacultyAssignToSubjectById")]
        public async Task<ActionResult<FacultyAssignToSubject>> GetFacultyAssignToSubjectById(int id)
        {
            var result = await _facultyRepository.GetFacultyAssignToSubjectById(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<FacultyAssignToSubject>> Addsubjecttofaculty(FacultyAssignToSubject facultyAssignToSubject)
        {
            if (facultyAssignToSubject == null)
                    return BadRequest();

            var createdFacultyAssignToSubject = await _facultyRepository.assignFacultyToSubject(facultyAssignToSubject);

            return CreatedAtAction(nameof(GetFacultyAssignToSubjectById),
                    new { id = createdFacultyAssignToSubject.Id }, createdFacultyAssignToSubject);
            
        }
        
        [HttpGet]//("{subid}", Name = "listStubysubbelongstoid")]
        [Route("~/studentlist/{subid}")]
        public async Task<ActionResult> listStubysubbelongstoid(int subid)
        {
            return Ok(await _facultyRepository.listStubysubbelongstoid(subid));
        }


    }
}

