using System;

namespace WeatherStation.WeatherData
{
    public class StatsDisplay : Observer.IObserver<SWeatherInfo>
    {
        private StatisticalData _temperatureData = new StatisticalData();
        private StatisticalData _humidityData = new StatisticalData();
        private StatisticalData _pressureData = new StatisticalData();

        private string GetSpesificStatistics(StatisticalData data)
        {
            return $"\n    Max {data.GetMaxValue()}\n    Min {data.GetMinValue()}\n    Average {data.GetAverageValue()}";
        }

        public void Update(SWeatherInfo data)
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
