namespace TemperatureMonitoring.Core
{
    internal interface IAnalyzer
    {
        public ReportContent Analyze(string data, DateTime analyzeTime, Fish fish);
        public ReportContent AnalyzeFromFile(string path, Fish fish);
    }
}
