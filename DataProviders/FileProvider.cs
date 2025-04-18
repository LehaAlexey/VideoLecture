using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VideoLecture.DataProviders
{
    internal static class FileProvider
    {
        public static string ChooseAudio()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Audio File (*.wav)|*.wav";

            bool? result = fileDialog.ShowDialog();

            if (result.HasValue && result.Value)
                return fileDialog.FileName;
            else 
                return string.Empty;
        }

        public static string ChoosePhoto()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";

            bool? result = fileDialog.ShowDialog();

            if (result.HasValue && result.Value)
                return fileDialog.FileName;
            else
                return string.Empty;
        }

        public static string ChooseText()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";

            bool? result = fileDialog.ShowDialog();

            if (result.HasValue && result.Value)
                return fileDialog.FileName;
            else
                return string.Empty;
        }

        public static string ChoosePdf()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PDF Files (*.pdf)|*.pdf";

            bool? result = fileDialog.ShowDialog();

            if (result.HasValue && result.Value)
                return fileDialog.FileName;
            else
                return string.Empty;
        }
    }
}
