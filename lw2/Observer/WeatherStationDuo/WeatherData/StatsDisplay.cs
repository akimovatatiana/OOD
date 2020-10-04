using System;

namespace WeatherStationDuo.WeatherData
{
    public class StatsDisplay : Observer.IObserver<SWeatherInfo>
    {
        private WeatherStatistics _weatherStatisticsIn = new WeatherStatistics();
        private WeatherStatistics _weatherStatisticsOut = new WeatherStatistics();

        private readonly CWeatherData _weatherDataIn;
        private readonly CWeatherData _weatherDataOut;

        public StatsDisplay(CWeatherData weatherDataIn, CWeatherData weatherDataOut)
        {
            _weatherDataIn = weatherDataIn;
            _weatherDataOut = weatherDataOut;
        }

        public void Update(SWeatherInfo data, Observer.IObservable<SWeatherInfo> observable)
        {
            if (_weatherDataIn == observable)
            {
                Console.WriteLine("Inside:");
                _weatherStatisticsIn.PrintStatistics(data);
            }
            if(_weatherDataOut == observable)
            {
                Console.WriteLine("Outside:");
                _weatherStatisticsOut.PrintStatistics(data);
            }
        }
    }
}
