namespace TemperatureMonitoring.Core
{
    public class ReportContent
    {
        public List<ReportContentElement> content;
        public Fish fish;

        public ReportContent(Fish fish)
        {
            content = new();
            this.fish = fish;
        }

        public void AddResultToReport(DateTime analyzeTime, int actualTemperature, int normalTemprature)
        {
            content.Add(new ReportContentElement(analyzeTime, actualTemperature, normalTemprature, actualTemperature - normalTemprature));
        }
    }
}
