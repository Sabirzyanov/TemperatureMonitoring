namespace TemperatureMonitoring.Core
{
    public class Fish
    {
        public string Name { get; set; }
        public int MaxTemperature { get; set; }
        public TimeSpan MaxTemperatureStoreTime { get; set; }
        public int MinTemperature { get; set; } = int.MinValue;
        public TimeSpan MinTemperatureStoreTime { get; set; }

        public Fish(string name, int maxTemperature, TimeSpan maxTemperatureStoreTime, TimeSpan minTemperatureStoreTime, int minTemperature)
        {
            Name = name;
            MaxTemperature = maxTemperature;
            MaxTemperatureStoreTime = maxTemperatureStoreTime;
            MinTemperature = minTemperature;
            MinTemperatureStoreTime = minTemperatureStoreTime;
        }

        public Fish(string name, int maxTemperature, TimeSpan maxTemperatureStoreTime)
        {
            Name = name;
            MaxTemperature = maxTemperature;
            MaxTemperatureStoreTime = maxTemperatureStoreTime;
        }
    }
}
