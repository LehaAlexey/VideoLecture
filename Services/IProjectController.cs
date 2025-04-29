using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLecture.Services
{
    //TODO: на подумать - реализовать логику сохранения проектов. Пока они существуют лишь на время работы приложения
    public interface IProjectController
    {
        public List<IProject> _projects { get; set; }
        public Task<IProject> CreateProjectAsync(string name);
        public Task<bool> DeleteProjectAsync(IProject project);
        public Task<bool> IsProjectAlreadyExistAsync(string name);
    }
}
