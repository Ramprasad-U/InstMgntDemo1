using InstitueMgntDemoApi.Services;
using InstitueMgntDemoApiData;
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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            this._subjectRepository = subjectRepository;
        }

        [HttpGet("{id:int}", Name = "GetSubjectById")]
        public async Task<ActionResult<Subject>> GetSubjectById(int id)
        {
            try
            {
                var result = (await _subjectRepository.GetSubjectById(id));
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

        [HttpGet("{Name}", Name = "GetSubjectByName")]
        public async Task<ActionResult<Subject>> GetSubjectByName(string Name)
        {
            try
            {
                var result = (await _subjectRepository.GetSubjectByName(Name));
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

        [HttpPost]
        public async Task<ActionResult<Subject>> CreateSubject(Subject subject)
        {
            try
            {
                if (subject == null)
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

                //var dep = _subjectRepository.GetSubjectByName(Subject.SubjectName);
                //if (dep != null)
                //{
                //    ModelState.AddModelError("Name", "Department Name Already exists");
                //    return BadRequest(ModelState);
                //}

                var createSubject = await _subjectRepository.AddSubject(subject);
                return CreatedAtAction(nameof(GetSubjectById),
                    new { id = createSubject.SubjectId }, createSubject);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new subject record");
            }

        }

        [HttpGet]
        public async Task<ActionResult> GetSubjects()
        {
            try
            {
                return Ok(await _subjectRepository.GetSubjects());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}
