using System;

namespace WeatherStationProDuo.WeatherData
{
    public class Display : Observer.IObserver<SWeatherInfo>
    {
        private readonly WeatherDataIn _weatherDataIn;
        private readonly WeatherDataOut _weatherDataOut;

        public Display(WeatherDataIn weatherDataIn, WeatherDataOut weatherDataOut)
        {
            _weatherDataIn = weatherDataIn;
            _weatherDataOut = weatherDataOut;
        }

        public void Update(SWeatherInfo data, Observer.IObservable<SWeatherInfo> observable)
        {
            if (_weatherDataIn == observable)
            {
                Console.WriteLine("Inside:");
            }
            if (_weatherDataOut == observable)
            {
                Console.WriteLine("Outside:");
                Console.WriteLine($"Current Wind Speed {data.windInfo.Value.speed}");
                Console.WriteLine($"Current Wind Direction {data.windInfo.Value.direction}");
            }
            Console.WriteLine($"Current Temp {data.temperature}");
            Console.WriteLine($"Current Hum {data.humidity}");
            Console.WriteLine($"Current Pressure {data.pressure}");
            Console.WriteLine("----------------");
        }
    }
}
