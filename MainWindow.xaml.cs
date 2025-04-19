using System.IO;
using System.Windows;
using System.Windows.Controls;
using VideoLecture.DataProviders;
using VideoLecture.Pages;
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

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            ShowCreateProjectDialog();
        }

        private void ShowCreateProjectDialog()
        {
            CreateProjectDialog dialog = new CreateProjectDialog();
            if (dialog.ShowDialog() == true)
            {
                string projectName = dialog.ProjectName;
                AddNewProject(projectName);
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

        private void AddLecture_Click(object sender, RoutedEventArgs e)
        {
            var createDialog = new AddEditLecture()
            .ShowDialog();
        }

        public string LectureName { get; set; } = string.Empty;
        private void EditLecture_Click(object sender, RoutedEventArgs e)
        {
            LectureList dialog = new LectureList();
            dialog.LectureIsChose += GetLectureName;
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                var editDialog = new AddEditLecture(VideoLectureProvider.GetLecture(LectureName))
                .ShowDialog();
            }
            LectureName = string.Empty;
        }
        private void DeleteLecture_Click(object sender, RoutedEventArgs e)
        {
            LectureList dialog = new LectureList();
            dialog.LectureIsChose += GetLectureName;
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить образ?", 
                                                "Отменить это действие будет невозможно.", 
                                                MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes) {
                    VideoLectureProvider.DeleteLecture(LectureName);
                }
            }
            LectureName = string.Empty;
        }
        private void GetLectureName(object sender, string name)
        {
            LectureName = name;
        }
    }
}