using System.Text.RegularExpressions;
using System.Windows;
using VideoLecture.DataProviders;

namespace VideoLecture.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditLecture.xaml
    /// </summary>
    public partial class AddEditLecture : Window
    {
        public Lector lecture { get; set; }
        public string AudioPath { get; set; }
        public string PhotoPath { get; set; }
        public AddEditLecture(Lector lecture = null)
        {
            InitializeComponent();
            
            if (lecture is null)
                return;
            this.lecture = lecture;
            AddEditButton.Content = "Изменить";
            AudioPath = lecture.AudioPath;
            PhotoPath = lecture.PhotoPath;
            LectureNameTextBox.Text = lecture.Name;
            AddEditButton.IsEnabled = false;
            AudioIsChooseTextBlock.Text = AudioPath.Split('\\').Last();
            PhotoIsChooseTextBlock.Text = PhotoPath.Split('\\').Last();
        }
        private void SetAudio_Click(object sender, RoutedEventArgs e)
        {
            var isChoosen = FileProvider.ChooseAudio(out string path);
            if (isChoosen)
            {
                AudioPath = path;
                AddEditButton.IsEnabled = true;
                AudioIsChooseTextBlock.Text = path.Split('\\').Last();
            }
        }
        private void SetPhoto_Click(object sender, RoutedEventArgs e)
        {
            var isChoosen = FileProvider.ChoosePhoto(out string path);
            if (isChoosen)
            {
                PhotoPath = path;
                AddEditButton.IsEnabled = true;
                PhotoIsChooseTextBlock.Text = path.Split('\\').Last();
            }
        }
        private void LectureNameChanged(object sender, RoutedEventArgs e)
        {
            AddEditButton.IsEnabled = true;
        }

        private void AddEditLecture_Click(object sender, RoutedEventArgs e)
        {
            LectureNameTextBox.Text = LectureNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(AudioPath) || string.IsNullOrEmpty(PhotoPath))
            {
                MessageBox.Show("Ошибка добавления: не выбрана фотография или файл озвучки.");
                return;
            }
            if (string.IsNullOrWhiteSpace(LectureNameTextBox.Text))
            {
                MessageBox.Show("Ошибка добавления: не введено название образа.");
                return;
            }
            if (!Regex.IsMatch(LectureNameTextBox.Text, @"^[A-Za-zА-Яа-яёЁ0-9-_.,]+$"))
            {
                MessageBox.Show("Ошибка добавления: название образа имеет неверный формат. Используйте буквы, цифры, а также следующие символы: '-' или '_'.");
                return;
            }

            if (lecture is null) //если мы СОЗДАЕМ, а не исправляем
            {
                if (VideoLectorProvider.IsXmlFileExist(LectureNameTextBox.Text))
                {
                    MessageBox.Show("Ошибка добавления: образ с таким названием уже существует");
                    return;
                }
                VideoLectorProvider.CreateXmlFile(new Lector() { Name = LectureNameTextBox.Text, AudioPath = AudioPath, PhotoPath = PhotoPath });
                MessageBox.Show("Образ успешно добавлен!");
                return;
            }

            //TODO: Исправить это, чтобы образ создавался или перезаписывался
            VideoLectorProvider.EditXmlFile(lecture.Name, new Lector() { Name = LectureNameTextBox.Text, AudioPath = AudioPath, PhotoPath = PhotoPath });
            MessageBox.Show("Образ успешно добавлен!");
            return;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
    }
}
