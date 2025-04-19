using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace VideoLecture.DataProviders
{
    internal static class VideoLectureProvider
    {
        const string PATH = "userfiles/video_lectors/";

        static VideoLectureProvider()
        {
            if (!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }
        }
        public static void CreateXmlFile(Lecture lecture)
        {


            XElement element = new XElement(
                lecture.Name,
                new XElement("LectureName", lecture.Name),
                new XElement("PhotoPath", lecture.PhotoPath),
                new XElement("AudioPath", lecture.AudioPath)
                );
            XDocument xdoc = new XDocument(element);

            xdoc.Save($"userfiles/video_lectors/{lecture.Name}.xml");
        }

        public static void EditXmlFile(string oldLectureName, Lecture newLecture)
        {
            string oldFilePath = $"{PATH}{oldLectureName}.xml";
            string newFilePath = $"{PATH}{newLecture.Name}.xml";
            if (!IsXmlFileExist(oldFilePath))
            {
                throw new Exception($"File is not exist: {oldFilePath}");
            }
            var doc = XDocument.Load(oldFilePath);


            XElement element = new XElement(
                newLecture.Name,
                new XElement("LectureName", newLecture.Name),
                new XElement("PhotoPath", newLecture.PhotoPath),
                new XElement("AudioPath", newLecture.AudioPath)
                ); 
            doc.ReplaceNodes(element);
            doc.Save(newFilePath);
            DeleteLecture(oldLectureName);
        }

        public static bool IsXmlFileExist(string name)
        {
            return File.Exists($"{PATH}{name}.xml");
        }

        public static List<Lecture> GetLectures()
        {
            List<Lecture> lectures = new List<Lecture>();
            foreach (var file in Directory.GetFiles(PATH, "*.xml"))
            {
                var xdoc = XDocument.Load(file);
                var lectureElement = xdoc.Root;
                if (lectureElement != null)
                {
                    var currentLecture = new Lecture
                    {
                        Name = lectureElement.Element("LectureName")?.Value,
                        PhotoPath = lectureElement.Element("PhotoPath")?.Value,
                        AudioPath = lectureElement.Element("AudioPath")?.Value
                    };
                    lectures.Add(currentLecture);
                }
            }

            return lectures;
        }

        public static Lecture GetLecture(string name)
        {
            Lecture lecture = null;
            var xdoc = XDocument.Load(PATH + $"{name}.xml");
            var lectureElement = xdoc.Root;
            if (lectureElement != null)
            {
                lecture = new Lecture
                {
                    Name = lectureElement.Element("LectureName")?.Value,
                    PhotoPath = lectureElement.Element("PhotoPath")?.Value,
                    AudioPath = lectureElement.Element("AudioPath")?.Value
                };
            }
            return lecture;
        }

        public static void DeleteLecture(string name)
        {
            File.Delete($"{PATH}{name}.xml");
        }
    }
}