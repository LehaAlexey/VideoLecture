using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLecture.Services
{
    internal class ProjectFactoryMOCK : IProjectFactory
    {
        public IProject CreateProject(string name)
        {
            return new ProjectMOCK(name);
        }
    }
}
