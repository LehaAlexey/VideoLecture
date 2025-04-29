using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLecture.Services
{
    internal class ProjectController : IProjectController
    {
        public List<IProject> _projects { get; set; }
        private readonly IProjectFactory _projectFactory;
        public ProjectController(IProjectFactory projectFactory)
        {
            _projectFactory = projectFactory ?? throw new ArgumentNullException(nameof(projectFactory));
            _projects = new List<IProject>();
        }

        public Task<IProject> CreateProjectAsync(string name)
        {
            if (_projects.Any(p => p.Name == name))
                new Exception("Данное имя уже занято");
            IProject newProject = _projectFactory.CreateProject(name);
            _projects.Add(newProject);
            return Task.FromResult(newProject);
        }

        public Task<bool> IsProjectAlreadyExistAsync(string name)
        {
            if (_projects.Any(p => p.Name == name))
                return Task.FromResult(true);
            return Task.FromResult(false);
        }

        public Task<bool> DeleteProjectAsync(IProject project)
        {
            if (_projects.Remove(project))
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
