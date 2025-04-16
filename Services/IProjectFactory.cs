using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLecture.Services
{
    internal interface IProjectFactory
    {
        IProject CreateProject(string name);
    }
}
