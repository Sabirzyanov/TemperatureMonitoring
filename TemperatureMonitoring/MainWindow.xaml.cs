using TemperatureMonitoring.Core;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Collections.Generic;

namespace TemperatureMonitoring
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TemperatureAnalyzer temperatureAnalyzer;
        ReportContent report;
        public MainWindow()
        {
            InitializeComponent();
            temperatureAnalyzer = new TemperatureAnalyzer();
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog loadDialog = new OpenFileDialog();
            var result = loadDialog.ShowDialog();
            if (result == true)
            {
                using (StreamReader sr = new StreamReader(loadDialog.FileName))
                {
                    AnalyzeDate.Text = sr.ReadLine();
                    TemperaturesData.Text = sr.ReadLine();
                }
            }
        }

        private void GenerateReportBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Fish fish = new Fish(FishType.Text, int.Parse(MaxTemp.Text), TimeSpan.FromMinutes(double.Parse(MaxTempStoreTime.Text)),
                                     TimeSpan.FromMinutes(double.Parse(MinTempStoreTime.Text)), int.Parse(MinTemp.Text));
                report = temperatureAnalyzer.Analyze(TemperaturesData.Text, DateTime.Parse(AnalyzeDate.Text), fish);
                ReportTable.ItemsSource = report.content;

                if (report.MaxTempStoringTime > report.MinTempStoringTime)
                {
                    VerdictTextBox.Text = $"Результат: Порог максимального превышен на {report.MaxTempStoringTime.TotalMinutes} минут";
                }
                if (report.MinTempStoringTime > report.MaxTempStoringTime)
                {
                    VerdictTextBox.Text = $"Результат: Порог минимального превышен на {report.MinTempStoringTime.TotalMinutes} минут";
                }
            }
            catch
            {
                MessageBox.Show("Введите данные всех полей");
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            var result = saveDialog.ShowDialog();
            if (result == true)
            {
                temperatureAnalyzer.Save(report, VerdictTextBox.Text, saveDialog.FileName);
            }
        }
    }
}
