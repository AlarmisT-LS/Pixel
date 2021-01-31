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
    /// Логика взаимодействия для AdmissionWindow.xaml
    /// </summary>
    public partial class AdmissionWindow : Window
    {
        private ApplicationContext db;
        public AdmissionWindow()
        {
            InitializeComponent();
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

        private void Button_Input_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inputWindow = new MainWindow();
            inputWindow.Show();
            Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            List<string> listCard = new List<string>();
            db = new ApplicationContext();
            await Task.Run(() =>
            {
                List<VideoCard> videoCards = db.VideoCards.ToList();
                int i = 0;
                foreach (var it in videoCards)
                {
                    listCard.Add(it.CardName);
                    i++;
                }
            });
            List<string> listNumber = new List<string>();
            await Task.Run(() =>
            {
                for (int i = 1; i <= 31; i++)
                    listNumber.Add(i.ToString());
            });
            CardList.ItemsSource = listCard;
            numberList.ItemsSource = listNumber;
            monthList.ItemsSource = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
            yearsList.ItemsSource = new List<string>() { "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030" };
        }

        private async void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            ClearComboBoxBorderBrush();
            if (textBoxProvider.Text.Length == 0)
                textBoxProvider.BorderBrush = Brushes.Red;
            else if (numberList.Text.Length == 0)
                numberList.BorderBrush = Brushes.Red;
            else if (monthList.Text.Length == 0)
                monthList.BorderBrush = Brushes.Red;
            else if (yearsList.Text.Length == 0)
                yearsList.BorderBrush = Brushes.Red;
            else if (CardList.Text.Length == 0)
                CardList.BorderBrush = Brushes.Red;
            else if (textBoxAmount.Text.Length == 0)
                textBoxAmount.BorderBrush = Brushes.Red;
            else if (int.Parse(textBoxAmount.Text) < 1)
                textBoxAmount.BorderBrush = Brushes.Red;

            else
            {
                string str = CardList.Text, number = textBoxAmount.Text;
                await Task.Run(() =>
                {
                    List<VideoCard> videoCards = db.VideoCards.ToList();
                    foreach (var item in videoCards)
                    {
                        if (item.CardName == str)
                            item.Amount += Convert.ToInt32(number);
                    }

                });
                db.TradeTransactions.Add(new TradeTransaction(CardList.Text, $"{numberList.Text}.{monthList.Text}.{yearsList.Text}", "Добавлено", Convert.ToInt32(textBoxAmount.Text)));
                db.SaveChanges();
                ClearTextComboBox();
            }
        }


        private void ClearComboBoxBorderBrush()
        {
            textBoxProvider.BorderBrush = Brushes.Transparent;
            numberList.BorderBrush = Brushes.Transparent;
            monthList.BorderBrush = Brushes.Transparent;
            yearsList.BorderBrush = Brushes.Transparent;
            CardList.BorderBrush = Brushes.Transparent;
            textBoxAmount.BorderBrush = Brushes.Transparent;
        }
        private void ClearTextComboBox()
        {
            textBoxProvider.Text = "";
            numberList.Text = "";
            monthList.Text = "";
            yearsList.Text = "";
            CardList.Text = "";
            textBoxAmount.Text = "";
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
