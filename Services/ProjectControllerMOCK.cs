using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLecture.Services
{
    internal class ProjectControllerMOCK : IProjectController
    {
        public List<IProject> _projects { get; set; }
        private readonly IProjectFactory _projectFactory;
        public ProjectControllerMOCK(IProjectFactory projectFactory)
        {
            _projectFactory = projectFactory ?? throw new ArgumentNullException(nameof(projectFactory));
            _projects = new List<IProject>();
        }

        public Task<IProject> CreateProjectAsync(string name)
        {
            IProject newProject = _projectFactory.CreateProject(name);
            _projects.Add(newProject);
            return Task.FromResult(newProject);
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
