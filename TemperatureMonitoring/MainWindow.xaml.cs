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

        //private void IntTextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    TextBox textBox = (TextBox)sender;
        //    if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "[^0-9]"))
        //    {
        //        MessageBox.Show("Please enter only numbers.");
        //        textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
        //    }
        //}

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
                var result = temperatureAnalyzer.Analyze(TemperaturesData.Text, DateTime.Parse(AnalyzeDate.Text), fish);
                ReportTable.ItemsSource = result.content;
            }
            catch
            {
                MessageBox.Show("Введите данные всех полей");
            }
        }
    }
}
