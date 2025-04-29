using System.Diagnostics.Eventing.Reader;
using System.Windows;
using VideoLecture.Services;

namespace VideoLecture
{
    public partial class CreateProjectDialog : Window
    {
        public string ProjectName { get; private set; }

        public IProjectController ProjectController { get; set; }

        public CreateProjectDialog(IProjectController projectController)
        {
            InitializeComponent();
            ProjectController = projectController;
            ProjectName = string.Empty;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectController.IsProjectAlreadyExistAsync(ProjectNameTextBox.Text).Result)
                WarningMessage.Text = "Проект с данным именем уже существует!";

            else
            {
                WarningMessage.Text = string.Empty;
                ProjectName = ProjectNameTextBox.Text;
                DialogResult = true;
                Close();
            }
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
