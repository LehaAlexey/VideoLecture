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
            OpenFileDialog ImageFileDialog = new OpenFileDialog();
            ImageFileDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";

            bool? result = ImageFileDialog.ShowDialog();

            if (result.HasValue && result.Value)
                Thread.Sleep(200);
        }

        private void ChoosePdf_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog PdfFileDialog = new OpenFileDialog();
            PdfFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";

            bool? result = PdfFileDialog.ShowDialog();

            if (result.HasValue && result.Value)
                Thread.Sleep(200);
        }

        private void ChooseAudio_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog audioFileDialog = new OpenFileDialog();
            audioFileDialog.Filter = "Audio files(*.wav)|*.wav";

            bool? result = audioFileDialog.ShowDialog();

            if (result.HasValue && result.Value)
                Thread.Sleep(100);
        }

        private void ChoosePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ImageFileDialog = new OpenFileDialog();
            ImageFileDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";

            bool? result = ImageFileDialog.ShowDialog();

            if (result.HasValue && result.Value)
                Thread.Sleep(100);
        }
    }
}
