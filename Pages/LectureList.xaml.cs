using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using VideoLecture.DataProviders;

namespace VideoLecture
{
    /// <summary>
    /// Логика взаимодействия для LectureList.xaml
    /// </summary>
    public partial class LectureList : Window
    {
        public event EventHandler<string> LectureIsChose; //событие для возвращения имени выбранного лектора
        public LectureList()
        {
            InitializeComponent();
            Lectures.ItemsSource = VideoLectureProvider.GetLectures();
            Lectures.DisplayMemberPath = "Name";
            SelectLectureButton.IsEnabled = false;
        }
        private void Lectures_SelectionChanged(object sender, RoutedEventArgs e)
        {
            SelectLectureButton.IsEnabled = true;
        }
        private void SelectLecture_Click(object sender, RoutedEventArgs e)
        {
            LectureIsChose(sender, Lectures.SelectedItem.ToString());
            DialogResult = true;
            Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
