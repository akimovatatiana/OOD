using System;
using WeatherStation.WeatherData;

namespace WeatherStationTests
{
    public class TestPriorityObserver : WeatherStation.Observer.IObserver<SWeatherInfo>
    {
        private readonly int _priority;

        public TestPriorityObserver(int priority)
        {
            _priority = priority;
        }

        public void Update(SWeatherInfo data)
        {
            Console.Write($"{_priority};");
        }
    }
}
