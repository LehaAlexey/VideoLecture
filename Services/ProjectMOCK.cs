using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLecture.Services
{
    internal class ProjectMOCK : IProject
    {
        public ProjectMOCK(string name)
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

        public async Task<bool> SetLecturePhotoAsync(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SetPresentationAsync(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SetSpeechAudioAsync(string path)
        {
            throw new NotImplementedException();
        }
    }
}
