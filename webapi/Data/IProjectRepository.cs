using System;
using System.Collections.Generic;
using webapi.Models;

namespace webapi.Data
{
    public interface IProjectRepository
    {
        Project GetProjectById(int projectId);
        List<Project> GetAllProjects();
        void AddProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int projectId);
    }
}
