using System;

namespace WeatherStationPro.WeatherData
{
    public class StatsDisplay : Observer.IObserver<SWeatherInfo>
    {
        private readonly StatisticalData _temperatureData = new StatisticalData();
        private readonly StatisticalData _humidityData = new StatisticalData();
        private readonly StatisticalData _pressureData = new StatisticalData();
        private readonly StatisticalData _windSpeed = new StatisticalData();
        private readonly StatisticalDirectionData _windDirection = new StatisticalDirectionData();

        private string GetSpesificStatistics(StatisticalData data)
        {
            return $"\n    Max {data.GetMaxValue()}\n    Min {data.GetMinValue()}\n    Average {data.GetAverageValue()}";
        }

        private string GetDirectionStatistics(StatisticalDirectionData data)
        {
            return $"    Average direction {data.GetAverageDirection()}";
        }

        public void Update(SWeatherInfo data)
        {
            _temperatureData.UpdateData(data.temperature);
            _humidityData.UpdateData(data.humidity);
            _pressureData.UpdateData(data.pressure);
            _windSpeed.UpdateData(data.windInfo.speed);
            _windDirection.UpdateDirectionData(data.windInfo.direction);

            Console.WriteLine($"Temperature: {GetSpesificStatistics(_temperatureData)}");
            Console.WriteLine($"Humidity: {GetSpesificStatistics(_humidityData)}");
            Console.WriteLine($"Pressure: {GetSpesificStatistics(_pressureData)}");
            Console.WriteLine($"Wind: {GetSpesificStatistics(_windSpeed)}");
            Console.WriteLine($"{GetDirectionStatistics(_windDirection)}");
            Console.WriteLine("----------------");
        }
    }
}
