using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _dbContext;
        public ProjectRepository(AppDbContext dbContet)
        {
            _dbContext = dbContet;
        }
        public Project GetProjectById(int projectId)
        {
            return _dbContext.Projects
                .Include(p => p.Manager)
                .FirstOrDefault(p => p.Id == projectId);
        }
        public List<Project> GetAllProjects()
        {
            return _dbContext.Projects.Include(p => p.Manager).ToList();
        }
        public void AddProject(Project project)
        {
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
        }
        public void UpdateProject(Project project)
        {
            _dbContext.Projects.Update(project);
            _dbContext.SaveChanges();
        }
        public void DeleteProject(int projectId)
        {
            var project = _dbContext.Projects.Find(projectId);
            if (project != null)
            {
                _dbContext.Projects.Remove(project);
                _dbContext.SaveChanges();
            }
        }
    }
}
