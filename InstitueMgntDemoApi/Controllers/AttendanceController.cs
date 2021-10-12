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
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceController(IAttendanceRepository attendanceRepository)
        {
            this._attendanceRepository = attendanceRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAttendances()
        {
            try
            {
                return Ok(await _attendanceRepository.GetAttendances());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}", Name = "GetAttendanceById")]
        public async Task<ActionResult<Attendance>> GetAttendanceById(int id)
        {
            try
            {
                var result = (await _attendanceRepository.GetAttendancesById(id));
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
        public async Task<ActionResult<Attendance>> AddAttendances(Attendance attendance)
        {
            try
            {
                if (attendance == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createAttendance = await _attendanceRepository.AddAttendance(attendance);
                return CreatedAtAction(nameof(GetAttendanceById),
                    new { id = createAttendance.id }, createAttendance);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }

        }
    }
}
