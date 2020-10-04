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

        public void Update(SWeatherInfo data)
        {
            _temperatureData.UpdateData(data.temperature);
            _humidityData.UpdateData(data.humidity);
            _pressureData.UpdateData(data.pressure);
            _windSpeed.UpdateData(data.windInfo.speed);
            _windDirection.UpdateDirectionData(data.windInfo.direction);

            Console.WriteLine($"Temperature: {_temperatureData.GetStatisticalData()}");
            Console.WriteLine($"Humidity: {_humidityData.GetStatisticalData()}");
            Console.WriteLine($"Pressure: {_pressureData.GetStatisticalData()}");
            Console.WriteLine($"Wind: {_windSpeed.GetStatisticalData()}");
            Console.WriteLine($"{_windDirection.GetAverageDirection()}");
            Console.WriteLine("----------------");
        }
    }
}
