using System;

namespace WeatherStationDuo.WeatherData
{
    public class Display : Observer.IObserver<SWeatherInfo>
    {
        private readonly CWeatherData _weatherDataIn;
        private readonly CWeatherData _weatherDataOut;

        public Display(CWeatherData weatherDataIn, CWeatherData weatherDataOut)
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
            }
            Console.WriteLine($"Current Temp {data.temperature}");
            Console.WriteLine($"Current Hum {data.humidity}");
            Console.WriteLine($"Current Pressure {data.pressure}");
            Console.WriteLine("----------------");
        }
    }
}
