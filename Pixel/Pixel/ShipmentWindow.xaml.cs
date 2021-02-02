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
    /// Логика взаимодействия для ShipmentWindow.xaml
    /// </summary>
    public partial class ShipmentWindow : Window
    {
        private ApplicationContext db;
        public ShipmentWindow()
        {
            InitializeComponent();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Добовление листа видеокарт 
            List<string> listCard = new List<string>();
            List<int> listNumbers = new List<int>();
            List<int> listMonths = new List<int>();
            List<int> listYears = new List<int>();

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


            //Добавление листа чисел, месяцев, годов
            await Task.Run(() =>
            {
                for (int i = 1; i <= 31; i++)
                    listNumbers.Add(i);
                for (int i = 1; i <= 12; i++)
                    listMonths.Add(i);
                for (int i = 2021; i <= 2077; i++)
                    listYears.Add(i);
            });
            CardList.ItemsSource = listCard;
            numberList.ItemsSource = listNumbers;
            monthList.ItemsSource = listMonths;
            yearsList.ItemsSource = listYears;
        }
        private async void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            ClearComboBoxBorderBrush();
            bool TemporaryVariableBool = await CheckForNegationAsync(CardList.Text, textBoxAmount.Text);
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
            else if (TemporaryVariableBool)
            {
                textBoxAmount.BorderBrush = Brushes.Red;
                textBoxAmount.ToolTip = "На складе нет такого количества товара!";
            }
            else
            {
                string str = CardList.Text, number = textBoxAmount.Text;
                await Task.Run(() =>
                {
                    List<VideoCard> videoCards = db.VideoCards.ToList();
                    foreach (var item in videoCards)
                    {
                        if (item.CardName == str)
                        {
                            if ((item.Amount - Convert.ToInt32(number)) >= 0)
                            {
                                item.Amount -= Convert.ToInt32(number);
                            }

                        }

                    }
                });
                db.TradeTransactions.Add(new TradeTransaction(CardList.Text, Convert.ToInt32(numberList.Text), Convert.ToInt32(monthList.Text), Convert.ToInt32(yearsList.Text), "Отгружено", Convert.ToInt32($"-{textBoxAmount.Text}")));
                db.SaveChanges();
                ClearTextComboBox();
            }
        }
        private async Task<bool> CheckForNegationAsync(string name, string count)
        {
            return await Task.Run(() => CheckForNegation(name, count));
        }
        private bool CheckForNegation(string name, string count)
        {
            List<VideoCard> videoCards = db.VideoCards.ToList();
            foreach (var item in videoCards)
            {
                if (item.CardName == name)
                {
                    if ((item.Amount -= Convert.ToInt32(count)) >= 0)
                        return false;
                    else
                        return true;
                }
            }
            return true;
        }
        private void ClearComboBoxBorderBrush()
        {
            textBoxProvider.BorderBrush = Brushes.Transparent;
            numberList.BorderBrush = Brushes.Transparent;
            monthList.BorderBrush = Brushes.Transparent;
            yearsList.BorderBrush = Brushes.Transparent;
            CardList.BorderBrush = Brushes.Transparent;
            textBoxAmount.BorderBrush = Brushes.Transparent;
            textBoxAmount.ToolTip = null;
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
        private void Button_Performance_Click(object sender, RoutedEventArgs e)
        {
            PerformanceWindow performanceWindow = new PerformanceWindow();
            performanceWindow.Show();
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
        private void Button_Report_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow();
            reportWindow.Show();
            Close();
        }
        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
