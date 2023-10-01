using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Dashboards
        [HttpGet]
        public ActionResult<IEnumerable<Dashboard>> GetDashboards()
        {
            return _context.Dashboards.Include(d => d.Widgets).ToList();
        }

        // GET: api/Dashboards/{id}
        [HttpGet("{id}")]
        public ActionResult<Dashboard> GetDashboard(int id)
        {
            var dashboard = _context.Dashboards.Include(d => d.Widgets).FirstOrDefault(d => d.Id == id);

            if (dashboard == null)
            {
                return NotFound();
            }

            return dashboard;
        }

        // POST: api/Dashboards
        [HttpPost]
        public ActionResult<Dashboard> CreateDashboard(Dashboard dashboard)
        {
            _context.Dashboards.Add(dashboard);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetDashboard), new { id = dashboard.Id }, dashboard);
        }

        // PUT: api/Dashboards/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateDashboard(int id, Dashboard dashboard)
        {
            if (id != dashboard.Id)
            {
                return BadRequest();
            }

            _context.Entry(dashboard).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Dashboards/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteDashboard(int id)
        {
            var dashboard = _context.Dashboards.Find(id);

            if (dashboard == null)
            {
                return NotFound();
            }

            _context.Dashboards.Remove(dashboard);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
