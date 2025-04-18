using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VideoLecture.DataProviders;

namespace VideoLecture
{
    /// <summary>
    /// Логика взаимодействия для ProjectPage.xaml
    /// </summary>
    public partial class ProjectPage : UserControl
    {
        public ProjectPage()
        {
            InitializeComponent();
        }

        private void ChooseText_Click(object sender, RoutedEventArgs e)
        {
            var textPath = FileProvider.ChooseText();
        }

        private void ChoosePdf_Click(object sender, RoutedEventArgs e)
        {
            var pdfPath = FileProvider.ChoosePdf();
        }
    }
}
