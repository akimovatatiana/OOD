using System;

namespace WeatherStationDuo.WeatherData
{
    public class WeatherStatistics
    {
        private StaticticalData _temperatureData = new StaticticalData();
        private StaticticalData _humidityData = new StaticticalData();
        private StaticticalData _pressureData = new StaticticalData();

        public void PrintStatistics(SWeatherInfo data)
        {
            Console.WriteLine($"Temperature: {_temperatureData.GetStatisticalData(data.temperature)}");
            Console.WriteLine($"Humidity: {_humidityData.GetStatisticalData(data.humidity)}");
            Console.WriteLine($"Pressure: {_pressureData.GetStatisticalData(data.pressure)}");
            Console.WriteLine("----------------");
        }
    }
}
