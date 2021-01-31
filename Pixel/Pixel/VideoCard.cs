using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel
{
    public class VideoCard
    {
        public int id { get; set; } 
        public string CardName { get; set; } 
        public string ModelGpu { get; set; }
        public string FrequencyGpu { get; set; } //Частота GPU
        public string FloatMemory { get; set; }
        public string TypeMemory { get; set; }
        public string TechnicalProcess { get; set; } //Техпроцесс
        public string Price { get; set; } //Техпроцесс

        public VideoCard() { }

        public VideoCard(string cardName, string modelGpu, string frequencyGpu, string floatMemory, string typeMemory, string technicalProcess, string price)
        {
            CardName = cardName;
            ModelGpu = modelGpu;
            FrequencyGpu = frequencyGpu;
            FloatMemory = floatMemory;
            TypeMemory = typeMemory;
            TechnicalProcess = technicalProcess;
            Price = price;
        }
    }
}
