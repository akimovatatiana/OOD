using System;
using WeatherStationDuo.WeatherData;

namespace WeatherStationDuoTests
{
    class DisplayDuo : WeatherStationDuo.Observer.IObserver<SWeatherInfo>
    {
        private readonly CWeatherData _weatherDataIn;
        private readonly CWeatherData _weatherDataOut;

        public DisplayDuo(CWeatherData weatherDataIn, CWeatherData weatherDataOut)
        {
            _weatherDataIn = weatherDataIn;
            _weatherDataOut = weatherDataOut;
        }

        public void Update(SWeatherInfo data, WeatherStationDuo.Observer.IObservable<SWeatherInfo> observable)
        {
            if (_weatherDataIn == observable)
            {
                Console.Write("Inside;");
            }
            if (_weatherDataOut == observable)
            {
                Console.Write("Outside;");
            }
        }
    }
}
