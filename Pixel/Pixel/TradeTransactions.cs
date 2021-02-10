using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pixel
{
    class TradeTransaction : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        private string cardName, statuse;

        public string CardName
        {
            get { return cardName; }
            set
            {
                cardName = value;
                OnPropertyChanged("CardName");
            }
        }
        public string Status
        {
            get { return statuse; }
            set
            {
                statuse = value;
                OnPropertyChanged("Status");
            }
        }



        public TradeTransaction() { }

        public TradeTransaction(string cardName, int day, int month, int year, string status, int amount)
        {
            Day = day;
            Month = month;
            Year = year;
            CardName = cardName;
            Status = status;
            Amount = amount;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
