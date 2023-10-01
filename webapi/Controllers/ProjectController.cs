using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/projects
        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetProjects()
        {
            return _context.Projects.Include(p => p.Manager).ToList();
        }

        // GET: api/projects/{id}
        [HttpGet("{id}")]
        public ActionResult<Project> GetProjectById(int id)
        {
            var project = _context.Projects.Include(p => p.Manager).FirstOrDefault(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // POST: api/projects
        [HttpPost]
        public ActionResult<Project> CreateProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
        }
    }
}
