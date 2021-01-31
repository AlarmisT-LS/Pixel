using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel
{
    class TradeTransaction
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public int Amount { get; set; }

        public TradeTransaction() { }

        public TradeTransaction(string cardName, string date, string status, int amount)
        {
            CardName = cardName;
            Date = date;
            Status = status;
            Amount = amount;
        }
    }
}
