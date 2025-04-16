using System.Windows;
using System.Windows.Controls;
using VideoLecture.Services;
using VideoLecture.Views;

namespace VideoLecture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IProjectController _projectController;
        public MainWindow()
        {
            InitializeComponent();

            IProjectFactory projectFactory = new ProjectFactoryMOCK(); //пока назвать иначе чем MOCK эту реализацию не могу. Такова жизззь
            _projectController = new ProjectControllerMOCK(projectFactory);
        }

        private void CreateProject_Click(object sender, RoutedEventArgs e)
        {
            ShowCreateProjectDialog();
        }

        private void ShowCreateProjectDialog()
        {
            CreateProjectDialog dialog = new CreateProjectDialog();
            if (dialog.ShowDialog() == true) // Если пользователь нажал "Создать"
            {
                string projectName = dialog.ProjectName;
                AddNewProject(projectName);
            }
            else
            {
                // Логика, если пользователь отменил создание проекта
            }
        }

        private void AddNewProject(string name)
        {
            var project = _projectController.CreateProjectAsync(name).Result; // Создание проекта
            AddProjectTab(project);
        }

        private void AddProjectTab(IProject project)
        {
            var projectTab = new ProjectTab
            {
                DataContext = project, // Привязка данных к вкладке
                Content = new ProjectPage()
            };

            TabItem tabItem = new TabItem
            {
                Header = project.Name,
                Content = projectTab
            };

            ProjectTabControl.Items.Add(tabItem);
        }
    }
}