using System;

namespace WeatherStationProDuo.WeatherData
{
    public class WeatherStatistics
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

        private void UpdateStatistics(SWeatherInfo data)
        {
            _temperatureData.UpdateData(data.temperature);
            _humidityData.UpdateData(data.humidity);
            _pressureData.UpdateData(data.pressure);
        }

        private void UpdateWindStatistics(SWeatherInfo data)
        {
            _windSpeed.UpdateData(data.windInfo.Value.speed);
            _windDirection.UpdateDirectionData(data.windInfo.Value.direction);
        }

        public void PrintStatistics(SWeatherInfo data)
        {
            UpdateStatistics(data);

            Console.WriteLine($"Temperature: {GetSpesificStatistics(_temperatureData)}");
            Console.WriteLine($"Humidity: {GetSpesificStatistics(_humidityData)}");
            Console.WriteLine($"Pressure: {GetSpesificStatistics(_pressureData)}");

            if (data.windInfo != null)
            {
                UpdateWindStatistics(data);

                Console.WriteLine($"Wind: {GetSpesificStatistics(_windSpeed)}");
                Console.WriteLine($"{GetDirectionStatistics(_windDirection)}");
            }
            Console.WriteLine("----------------");
        }
    }
}
