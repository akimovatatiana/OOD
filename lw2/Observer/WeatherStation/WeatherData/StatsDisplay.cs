using System;

namespace WeatherStation.WeatherData
{
    public class StatsDisplay : Observer.IObserver<SWeatherInfo>
    {
        private StaticticalData temperatureData = new StaticticalData();
        private StaticticalData humidityData = new StaticticalData();
        private StaticticalData pressureData = new StaticticalData();

        public void Update(SWeatherInfo data)
        {
            Console.WriteLine($"Temperature: {temperatureData.GetStatisticalData(data.temperature)}");
            Console.WriteLine($"Humidity: {humidityData.GetStatisticalData(data.humidity)}");
            Console.WriteLine($"Pressure: {pressureData.GetStatisticalData(data.pressure)}");
            Console.WriteLine("----------------");
        }
    }
}
