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
    public class AttendanceDetailsController : ControllerBase
    {
        private readonly IAttendanceDetailsRepository _attendanceDetailsRepository;

        public AttendanceDetailsController(IAttendanceDetailsRepository attendanceDetailsRepository)
        {
            this._attendanceDetailsRepository = attendanceDetailsRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAttendanceDetails()
        {
            try
            {
                return Ok(await _attendanceDetailsRepository.GetAttendanceDetails());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}", Name = "GetAttendanceDetailsById")]
        public async Task<ActionResult> GetAttendanceDetailsById(int id)
        {
            try
            {
                var result = (await _attendanceDetailsRepository.GetAttendanceDetailsById(id));
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
        public async Task<ActionResult<AttendanceDetails>> CreateattendanceDetails(AttendanceDetails attendanceDetails)
        {
            try
            {
                if (attendanceDetails == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createattendanceDetails = await _attendanceDetailsRepository.AddAttdDetails(attendanceDetails);
                return CreatedAtAction(nameof(GetAttendanceDetailsById),
                    new { id = createattendanceDetails.id }, createattendanceDetails);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new subject record");
            }

        }



    }
}
