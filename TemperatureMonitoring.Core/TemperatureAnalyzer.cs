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
                bool temperatureCheckResult = TemperatureCheck(fish, temp);

                int normalTemp;
                if (temp < fish.MaxTemperature && fish.MinTemperature != 0)
                {
                    normalTemp = fish.MinTemperature;
                }
                else 
                {
                    normalTemp = fish.MaxTemperature;
                }

                if (!temperatureCheckResult)
                {
                    content.AddResultToReport(analyzeTime, temp, normalTemp);
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

        private bool TemperatureCheck(Fish fish, int actualTemp)
        {
            if (fish.MinTemperature > actualTemp)
                return false;

            else if (fish.MaxTemperature < actualTemp)
                return false;
            else
                return true;
        }
    }
}