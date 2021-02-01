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

namespace Pixel
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private ApplicationContext db;
        public ReportWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }
        private void Button_Input_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inputWindow = new MainWindow();
            inputWindow.Show();
            Close();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<VideoCard> graphicsCards = new List<VideoCard>();
            await Task.Run(() => 
            {
                graphicsCards = db.VideoCards.ToList();
            });
            lstw.ItemsSource = graphicsCards;
        }
        private void Button_MainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inputWindow = new MainWindow();
            inputWindow.Show();
            Close();
        }

        private void Button_Admission_Click(object sender, RoutedEventArgs e)
        {
            AdmissionWindow admission = new AdmissionWindow();
            admission.Show();
            Close();
        }

        private void Button_Performance_Click(object sender, RoutedEventArgs e)
        {
            PerformanceWindow performanceWindow = new PerformanceWindow();
            performanceWindow.Show();
            Close();
        }


        private void Button_Shipment_Click(object sender, RoutedEventArgs e)
        {
            ShipmentWindow shipmentWindow = new ShipmentWindow();
            shipmentWindow.Show();
            Close();
        }
        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
