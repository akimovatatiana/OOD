using System;

namespace WeatherStationDuo.WeatherData
{
    public class WeatherStatistics
    {
        private readonly StatisticalData _temperatureData = new StatisticalData();
        private readonly StatisticalData _humidityData = new StatisticalData();
        private readonly StatisticalData _pressureData = new StatisticalData();

        public void PrintStatistics(SWeatherInfo data)
        {
            Console.WriteLine($"Temperature: {_temperatureData.GetStatisticalData(data.temperature)}");
            Console.WriteLine($"Humidity: {_humidityData.GetStatisticalData(data.humidity)}");
            Console.WriteLine($"Pressure: {_pressureData.GetStatisticalData(data.pressure)}");
            Console.WriteLine("----------------");
        }
    }
}
