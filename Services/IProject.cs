using System.Web;

namespace VideoLecture.Services
{
    //Пока неясно, как будут считываться файлы, и нужны ли для этого сторонние библиотеки и т.д.
    public interface IProject
    {
        public string Name { get;}
        public Task<bool> SetSpeechAudioAsync(string path);
        public Task<bool> SetPresentationAsync(string path);
        public Task<bool> SetLecturePhotoAsync(string path);

        public Task<bool> GenerateLectueComplexAsync();

        public Task<bool> GenerateLectueAudioAsync();
        public Task<bool> GenerateLectueVideoAsync();
    }
}