using System;

namespace WeatherStationDuo.WeatherData
{
    public class WeatherStatistics
    {
        private readonly StatisticalData _temperatureData = new StatisticalData();
        private readonly StatisticalData _humidityData = new StatisticalData();
        private readonly StatisticalData _pressureData = new StatisticalData();

        private string GetSpesificStatistics(StatisticalData data)
        {
            return $"\n    Max {data.GetMaxValue()}\n    Min {data.GetMinValue()}\n    Average {data.GetAverageValue()}";
        }

        public void PrintStatistics(SWeatherInfo data)
        {
            _temperatureData.UpdateData(data.temperature);
            _humidityData.UpdateData(data.humidity);
            _pressureData.UpdateData(data.pressure);

            Console.WriteLine($"Temperature: {GetSpesificStatistics(_temperatureData)}");
            Console.WriteLine($"Humidity: {GetSpesificStatistics(_humidityData)}");
            Console.WriteLine($"Pressure: {GetSpesificStatistics(_pressureData)}");
            Console.WriteLine("----------------");
        }
    }
}
