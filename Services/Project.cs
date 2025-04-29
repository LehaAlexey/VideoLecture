using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLecture.Services
{
    internal class Project : IProject
    {
        public Project(string name)
        {
            Name = name;
        }
        public string Name { get ; private set; }

        public async Task<bool> GenerateLectueAudioAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GenerateLectueComplexAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GenerateLectueVideoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
