﻿using System;

namespace WeatherStation.WeatherData
{
    public class StatsDisplay : Observer.IObserver<SWeatherInfo>
    {
        private StaticticalData _temperatureData = new StaticticalData();
        private StaticticalData _humidityData = new StaticticalData();
        private StaticticalData _pressureData = new StaticticalData();

        public void Update(SWeatherInfo data)
        {
            Console.WriteLine($"Temperature: {_temperatureData.GetStatisticalData(data.temperature)}");
            Console.WriteLine($"Humidity: {_humidityData.GetStatisticalData(data.humidity)}");
            Console.WriteLine($"Pressure: {_pressureData.GetStatisticalData(data.pressure)}");
            Console.WriteLine("----------------");
        }
    }
}