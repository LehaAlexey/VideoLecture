using System.Windows;

namespace VideoLecture
{
    public partial class CreateProjectDialog : Window
    {
        public string ProjectName { get; private set; }

        public CreateProjectDialog()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectName = ProjectNameTextBox.Text;
            DialogResult = true; // Устанавливаем результат диалога как "успешный"
            Close(); // Закрываем диалог
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Устанавливаем результат диалога как "отмененный"
            Close(); // Закрываем диалог
        }
    }
}
