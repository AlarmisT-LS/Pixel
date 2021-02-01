using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pixel
{
    public class VideoCard : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string cardName, modelGpu, frequencyGpu, floatMemory, typeMemory, technicalProcess, price;
        public string CardName
        {
            get { return cardName; }
            set
            {
                cardName = value;
                OnPropertyChanged("CardName");
            }
        }
        public string ModelGpu
        {
            get { return modelGpu; }
            set
            {
                modelGpu = value;
                OnPropertyChanged("ModelGpu");
            }
        }

        public string FrequencyGpu
        {
            get { return frequencyGpu; }
            set
            {
                frequencyGpu = value;
                OnPropertyChanged("FrequencyGpu");
            }
        }
        public string FloatMemory
        {
            get { return floatMemory; }
            set
            {
                floatMemory = value;
                OnPropertyChanged("FloatMemory");
            }
        }
        public string TypeMemory
        {
            get { return typeMemory; }
            set
            {
                typeMemory = value;
                OnPropertyChanged("TypeMemory");
            }
        }
        public string TechnicalProcess
        {
            get { return technicalProcess; }
            set
            {
                technicalProcess = value;
                OnPropertyChanged("TechnicalProcess");
            }
        }
        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public int Amount { get; set; }

        public VideoCard() { }

        public VideoCard(string cardName, string modelGpu, string frequencyGpu, string floatMemory, string typeMemory, string technicalProcess, string price)
        {
            this.cardName = cardName;
            this.modelGpu = modelGpu;
            this.frequencyGpu = frequencyGpu;
            this.floatMemory = floatMemory;
            this.typeMemory = typeMemory;
            this.technicalProcess = technicalProcess;
            this.price = price;
            Amount = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
