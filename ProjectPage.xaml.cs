﻿using Microsoft.Win32;
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
using System.Xml.Linq;
using VideoLecture.DataProviders;
using VideoLecture.Pages;
using VideoLecture.Services;

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
        public Lector Lecture { get; set; }
        public string PdfPath { get; set; }
        public string TextPath { get; set; }
        private void ChooseLecture_Click(object sender, RoutedEventArgs e)
        {
            LectureList dialog = new LectureList();
            dialog.LectureIsChose += GetLecture;
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                Lecture = VideoLectorProvider.GetLecture(LectureName);
                LectureIsChooseTextBlock.Text = $"{LectureName}.xml";
            }
            
        }
        public string LectureName { get; set; }
        private void GetLecture(object sender, string name)
        {
            LectureName = name;
        }

        private void ChooseText_Click(object sender, RoutedEventArgs e)
        {
            var isChoosen = FileProvider.ChooseText(out string path);
            if (isChoosen)
            {
                TextPath = path;
                TextIsChooseTextBlock.Text = path.Split('\\').Last();
            }
        }

        private void ChoosePdf_Click(object sender, RoutedEventArgs e)
        {
            var isChoosen = FileProvider.ChoosePdf(out string path);
            if (isChoosen)
            {
                PdfPath = path;
                PdfIsChooseTextBlock.Text = path.Split('\\').Last();
            }
        }
        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить этот проект?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // Получаем доступ к родительскому окну
                var mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null)
                {
                    // Удаляем вкладку проекта
                    mainWindow.RemoveProjectTab((IProject)this.DataContext);
                }
            }
        }
        
    }
}
