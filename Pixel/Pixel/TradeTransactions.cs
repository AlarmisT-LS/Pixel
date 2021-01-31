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
        private string cardName, date, statuse;

        public string CardName
        {
            get { return cardName; }
            set
            {
                cardName = value;
                OnPropertyChanged("CardName");
            }
        }
        public string Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
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

        public TradeTransaction(string cardName, string date, string status, int amount)
        {
            CardName = cardName;
            Date = date;
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
