using System;

namespace WeatherStationProDuo.WeatherData
{
    public class StatsDisplay : Observer.IObserver<SWeatherInfo>
    {
        private readonly WeatherStatistics _weatherStatisticsIn = new WeatherStatistics();
        private readonly WeatherStatistics _weatherStatisticsOut = new WeatherStatistics();

        private readonly WeatherDataIn _weatherDataIn;
        private readonly WeatherDataOut _weatherDataOut;

        public StatsDisplay(WeatherDataIn weatherDataIn, WeatherDataOut weatherDataOut)
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
