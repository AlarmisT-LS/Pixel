using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;

namespace Pixel
{
    public static class MyExtraction
    {
        public static ChartValues<int> ToChartValues(this List<int> list)
        {
            ChartValues<int> result = new ChartValues<int>();
            foreach (var i in list)
            {
                result.Add(i);
            }
            return result;
        }
    }
}
