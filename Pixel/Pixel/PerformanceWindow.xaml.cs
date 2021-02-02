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
        private string month, year;
        public PerformanceWindow()
        {
            InitializeComponent();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {


            List<int> listMonths = new List<int>();
            List<int> listYears = new List<int>();

            await Task.Run(() =>
            {
                for (int i = 1; i <= 12; i++)
                    listMonths.Add(i);
                for (int i = 2021; i <= 2077; i++)
                    listYears.Add(i);
            });
            monthList.ItemsSource = listMonths;
            yearsList.ItemsSource = listYears;



        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            db = new ApplicationContext();
            List<TradeTransaction> tradeTransactions = new List<TradeTransaction>();
            List<TradeTransaction> list = db.TradeTransactions.ToList();
            month = monthList.Text;
            year = yearsList.Text;
            await Task.Run(() =>
            {
                list = db.TradeTransactions.ToList();
                int sum = 0;
                for (int j = 1; j <= 31; j++)
                {
                    foreach (var i in list)
                    {
                        if (i.Day == j && i.Month.ToString() == month && i.Year.ToString() == year)
                        {
                            tradeTransactions.Add(i);
                        }
                    }
                }
                //size проверочный день
                //sum это переменная через которую прогоняем сумму
                //cost запоминает сколько повторяющихся дней
                //IdSave запоминает индекс первого попавшегося дня
                //locker блокирует idSave
                int size = 0, cost = 0, idSave = 0, locker = 0;
                List<TradeTransaction> listRemove = new List<TradeTransaction>();
                while (size <= 31)
                {
                    size++;
                    cost = 0;
                    locker = 0;
                    idSave = 0;
                    for (int i = 0; i < tradeTransactions.Count; i++)
                    {
                        if (tradeTransactions[i].Day == size)
                        {
                            if (locker == 0)
                            {
                                idSave = i;
                                locker = -1;
                            }
                            sum += tradeTransactions[i].Amount;
                            if (cost != 0)
                            {
                                listRemove.Add(tradeTransactions[i]);
                                tradeTransactions[idSave].Amount = sum;
                            }
                            cost++;
                        }
                    }
                }
                //Удаление ненужных элементов
                foreach (var i in listRemove)
                {
                    tradeTransactions.Remove(i);
                }
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
