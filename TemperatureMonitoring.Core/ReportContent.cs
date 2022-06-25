namespace TemperatureMonitoring.Core
{
    public class ReportContent
    {
        public List<ReportContentElement> content;
        public Fish fish;

        public TimeSpan MaxTempStoringTime;
        public TimeSpan MinTempStoringTime;
        public ReportContent(Fish fish)
        {
            content = new();
            this.fish = fish;
        }

        public void AddResultToReport(DateTime analyzeTime, int actualTemperature, int normalTemprature, Fish fish)
        {
            if (normalTemprature == fish.MaxTemperature)
            {
                MaxTempStoringTime += fish.MaxTemperatureStoreTime;
            }
            else
            {
                MinTempStoringTime += fish.MinTemperatureStoreTime;
            }
            content.Add(new ReportContentElement(analyzeTime, actualTemperature, normalTemprature, actualTemperature - normalTemprature));
        }
    }
}
