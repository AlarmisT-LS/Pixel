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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pixel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Button_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            ClearAuto();
            if (textBoxName.Text.Length == 0)
                textBoxName.BorderBrush = Brushes.Red;
            else if (LoginVerification(textBoxName.Text))
            {
                textBoxName.BorderBrush = Brushes.Red;
                textBoxName.ToolTip = "Имя уже занято!";
            }
            else if (textBoxModelGPU.Text.Length == 0)
                textBoxModelGPU.BorderBrush = Brushes.Red;
            else if (textBoxGPUFrequency.Text.Length == 0)
                textBoxGPUFrequency.BorderBrush = Brushes.Red;
            else if (textBoxVolueMemory.Text.Length == 0)
                textBoxVolueMemory.BorderBrush = Brushes.Red;
            else if (textBoxTypeMemory.Text.Length == 0)
                textBoxTypeMemory.BorderBrush = Brushes.Red;
            else if (textBoxTechnicalProcess.Text.Length == 0)
                textBoxTechnicalProcess.BorderBrush = Brushes.Red;
            else if (textBoxCostMoney.Text.Length == 0)
                textBoxTechnicalProcess.BorderBrush = Brushes.Red;
            else
            {
                db.VideoCards.Add(new VideoCard(textBoxName.Text, textBoxModelGPU.Text, textBoxGPUFrequency.Text, textBoxVolueMemory.Text, textBoxTypeMemory.Text, textBoxTechnicalProcess.Text, textBoxCostMoney.Text));
                db.SaveChanges();
                ClearBox();
            }
        }
        private bool LoginVerification(string log)
        {
            ApplicationContext db = new ApplicationContext();
            List<VideoCard> cards = db.VideoCards.ToList();

            foreach (var i in cards)
            {
                if (i.CardName == log)
                    return true;
            }
            return false;
        }
        private void ClearBox()
        {
            textBoxName.Text = "";
            textBoxModelGPU.Text = "";
            textBoxGPUFrequency.Text = "";
            textBoxVolueMemory.Text = "";
            textBoxTypeMemory.Text = "";
            textBoxTechnicalProcess.Text = "";
            textBoxCostMoney.Text = "";
        }
        private void ClearAuto()
        {
            textBoxName.ToolTip = null;
            textBoxName.BorderBrush = Brushes.Transparent;

            textBoxModelGPU.ToolTip = null;
            textBoxModelGPU.BorderBrush = Brushes.Transparent;

            textBoxGPUFrequency.ToolTip = null;
            textBoxGPUFrequency.BorderBrush = Brushes.Transparent;

            textBoxVolueMemory.ToolTip = null;
            textBoxVolueMemory.BorderBrush = Brushes.Transparent;

            textBoxTypeMemory.ToolTip = null;
            textBoxTypeMemory.BorderBrush = Brushes.Transparent;

            textBoxTechnicalProcess.ToolTip = null;
            textBoxTechnicalProcess.BorderBrush = Brushes.Transparent;
        }

        private void Button_Performance_Click(object sender, RoutedEventArgs e)
        {
            PerformanceWindow performanceWindow = new PerformanceWindow();
            performanceWindow.Show();
            Close();
        }

        private void Button_Report_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow();
            reportWindow.Show();
            Close();
        }

        private void Button_Shipment_Click(object sender, RoutedEventArgs e)
        {
            ShipmentWindow shipmentWindow = new ShipmentWindow();
            shipmentWindow.Show();
            Close();
        }

        private void Button_Admission_Click(object sender, RoutedEventArgs e)
        {
            AdmissionWindow admissionWindow = new AdmissionWindow();
            admissionWindow.Show();
            Close();
        }
    }
}
