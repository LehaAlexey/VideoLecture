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
        public static bool ChooseAudio(out string path)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Audio File (*.wav)|*.wav";

            bool? result = fileDialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                path = fileDialog.FileName;
                return true;
            }
            else
            {
                path = string.Empty;
                return false;
            }
        }

        public static bool ChoosePhoto(out string path)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";

            bool? result = fileDialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                path = fileDialog.FileName;
                return true;
            }
            else
            {
                path = string.Empty;
                return false;
            }
        }

        public static bool ChooseText(out string path)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Text Files (*.txt)|*.txt";

            bool? result = fileDialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                path = fileDialog.FileName;
                return true;
            }
            else
            {
                path = string.Empty;
                return false;
            }
        }

        public static bool ChoosePdf(out string path)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "PDF Files (*.pdf)|*.pdf";

            bool? result = fileDialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                path = fileDialog.FileName;
                return true;
            }
            else
            {
                path = string.Empty;
                return false;
            }
        }
    }
}
