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

        public void PrintStatistics(SWeatherInfo data)
        {
            _temperatureData.UpdateData(data.temperature);
            _humidityData.UpdateData(data.humidity);
            _pressureData.UpdateData(data.pressure);

            Console.WriteLine($"Temperature: {_temperatureData.GetStatisticalData()}");
            Console.WriteLine($"Humidity: {_humidityData.GetStatisticalData()}");
            Console.WriteLine($"Pressure: {_pressureData.GetStatisticalData()}");

            if (data.windInfo != null)
            {
                _windSpeed.UpdateData(data.windInfo.Value.speed);
                _windDirection.UpdateDirectionData(data.windInfo.Value.direction);

                Console.WriteLine($"Wind: {_windSpeed.GetStatisticalData()}");
                Console.WriteLine($"{_windDirection.GetAverageDirection()}");
            }
            Console.WriteLine("----------------");
        }
    }
}
