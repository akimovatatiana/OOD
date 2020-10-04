using System;

namespace WeatherStation.WeatherData
{
    public class StatsDisplay : Observer.IObserver<SWeatherInfo>
    {
        private StatisticalData _temperatureData = new StatisticalData();
        private StatisticalData _humidityData = new StatisticalData();
        private StatisticalData _pressureData = new StatisticalData();

        public void Update(SWeatherInfo data)
        {
            Console.WriteLine($"Temperature: {_temperatureData.GetStatisticalData(data.temperature)}");
            Console.WriteLine($"Humidity: {_humidityData.GetStatisticalData(data.humidity)}");
            Console.WriteLine($"Pressure: {_pressureData.GetStatisticalData(data.pressure)}");
            Console.WriteLine("----------------");
        }
    }
}
