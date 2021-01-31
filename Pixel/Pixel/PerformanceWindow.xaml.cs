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
    /// Логика взаимодействия для PerformanceWindow.xaml
    /// </summary>
    public partial class PerformanceWindow : Window
    {
        private ApplicationContext db;
        public PerformanceWindow()
        {
            InitializeComponent();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new ApplicationContext();
            List<TradeTransaction> tradeTransactions = new List<TradeTransaction>();
            await Task.Run(() => 
            {
                tradeTransactions = db.TradeTransactions.ToList();
            });
            listView.ItemsSource = tradeTransactions;
        }
        private void Button_Report_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow();
            reportWindow.Show();
            Close();

        }
        private void Button_Admission_Click(object sender, RoutedEventArgs e)
        {
            AdmissionWindow admissionWindow = new AdmissionWindow();
            admissionWindow.Show();
            Close();
        }
        private void Button_Input_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inputWindow = new MainWindow();
            inputWindow.Show();
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
