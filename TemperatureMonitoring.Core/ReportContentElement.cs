using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitoring.Core
{
    public struct ReportContentElement
    {
        public string Time { set; get; }
        public int ActualTemp { set; get; }
        public int NormalTemp { set; get; }
        public int ResultTemp { set; get; }

        public ReportContentElement(DateTime time, int actualTemp, int normalTemp, int resultTemp)
        {
            Time = time.ToString();
            this.ActualTemp = actualTemp;
            this.NormalTemp = normalTemp;
            this.ResultTemp = resultTemp;
        }

        public override string ToString()
        {
            return $"Время: {Time} | Факт: {ActualTemp} | Норма: {NormalTemp} | Отклонение: {ResultTemp}";
        }
    }
}
