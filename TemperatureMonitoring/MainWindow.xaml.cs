using TemperatureMonitoring.Core;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace TemperatureMonitoring
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TemperatureAnalyzer temperatureAnalyzer;
        public MainWindow()
        {
            InitializeComponent();
            temperatureAnalyzer = new TemperatureAnalyzer();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog loadDialog = new OpenFileDialog();
            var result = loadDialog.ShowDialog();
            if (result == true)
            {
                
            }
        }
    }
}
