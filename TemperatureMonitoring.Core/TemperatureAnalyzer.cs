namespace TemperatureMonitoring.Core
{
    /// <summary>
    /// <paramref name="AnalyzeInterval"/> 
    /// The time after which the temperature analysis takes place
    /// </summary>
    public class TemperatureAnalyzer : IAnalyzer
    {
        public TimeSpan AnalyzeInterval = TimeSpan.FromMinutes(10);

        private int[] TemperatureStringParser(string data, char spliter=' ')
        {
            try 
            {
                string[] splitedData = data.Split(spliter);
                return splitedData.Select(int.Parse).ToArray();
            }
            catch
            {
                throw;
            }
        }

        public ReportContent Analyze(string data, DateTime analyzeTime, Fish fish)
        {
            int[] parsedTemperaturesData = TemperatureStringParser(data);

            ReportContent content = new ReportContent(fish);

            foreach (int temp in parsedTemperaturesData)
            {
                int normalTemp = TemperatureCheck(fish, temp).Item2;
                bool temperatureCheckResult = TemperatureCheck(fish, temp).Item1;
                if (!temperatureCheckResult)
                {
                    content.AddResultToReport(analyzeTime, temp, normalTemp, fish);
                }
                else
                {
                    continue;
                }

                analyzeTime += AnalyzeInterval;
            }

            return content;
        }

        public ReportContent AnalyzeFromFile(string path, Fish fish)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    DateTime analyzeTime = DateTime.Parse(sr.ReadLine());
                    string data = sr.ReadLine();
                    return Analyze(data, analyzeTime, fish);
                }
            }
            catch
            {
                throw;
            }
        }

        private Tuple<bool, int> TemperatureCheck(Fish fish, int actualTemp)
        {
            if (fish.MinTemperature > actualTemp && fish.MinTemperature != int.MinValue)
                return new Tuple<bool, int>(false, fish.MinTemperature);
            else if (fish.MaxTemperature < actualTemp)
                return new Tuple<bool, int>(false, fish.MaxTemperature);
            else if (int.MinValue == fish.MinTemperature)
                return new Tuple<bool, int>(true, fish.MaxTemperature);
            else
                return new Tuple<bool, int>(true, fish.MaxTemperature);
        }

        public void Save(ReportContent report, string result, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (var item in report.content)
                    {
                        sw.WriteLine(item.ToString());
                    }
                    sw.WriteLine(result);   
                }
            }
            catch
            {
                throw;
            }
        }
    }
}