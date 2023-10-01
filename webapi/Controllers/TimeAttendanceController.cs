using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/timeattendances")]
    [ApiController]
    public class TimeAttendancesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TimeAttendancesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/timeattendances
        [HttpGet]
        public ActionResult<IEnumerable<TimeAttendance>> GetTimeAttendances()
        {
            return _context.TimeAttendances.ToList();
        }

        // GET: api/timeattendances/{id}
        [HttpGet("{id}")]
        public ActionResult<TimeAttendance> GetTimeAttendanceById(int id)
        {
            var timeAttendance = _context.TimeAttendances.FirstOrDefault(ta => ta.Id == id);

            if (timeAttendance == null)
            {
                return NotFound();
            }

            return timeAttendance;
        }

        // POST: api/timeattendances
        [HttpPost]
        public ActionResult<TimeAttendance> CreateTimeAttendance(TimeAttendance timeAttendance)
        {
            _context.TimeAttendances.Add(timeAttendance);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTimeAttendanceById), new { id = timeAttendance.Id }, timeAttendance);
        }
    }
}
