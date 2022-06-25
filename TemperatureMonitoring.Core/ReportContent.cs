namespace TemperatureMonitoring.Core
{
    public class ReportContent
    {
        public List<string> content;
        public Fish fish;

        public ReportContent(Fish fish)
        {
            content = new();
            this.fish = fish;
        }

        public void AddResultToReport(DateTime analyzeTime, int actualTemperature, int normalTemprature)
        {
            content.Add($"{analyzeTime:dd.MM.yyyy HH.mm.ss} | {actualTemperature} | {normalTemprature} | {actualTemperature - normalTemprature}");
        }
    }
}
