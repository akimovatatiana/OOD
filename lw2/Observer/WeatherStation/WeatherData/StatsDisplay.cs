using System;

namespace WeatherStation.WeatherData
{
    public class StatsDisplay : Observer.IObserver<SWeatherInfo>
    {
        public void Update(SWeatherInfo data)
        {
            StaticticalData temperatureData = new StaticticalData();
            StaticticalData humidityData = new StaticticalData();
            StaticticalData pressureData = new StaticticalData();

            Console.WriteLine($"Temperature: {temperatureData.GetStatisticalData(data.temperature)}");
            Console.WriteLine($"Humidity: {humidityData.GetStatisticalData(data.humidity)}");
            Console.WriteLine($"Pressure: {pressureData.GetStatisticalData(data.pressure)}");
            Console.WriteLine("----------------");
        }
    }
}
