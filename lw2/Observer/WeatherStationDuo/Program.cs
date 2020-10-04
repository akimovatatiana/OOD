using WeatherStationDuo.WeatherData;

namespace WeatherStationDuo
{
    class Program
    {
        static void Main()
        {
			CWeatherData weatherDataIn = new CWeatherData(WeatherStationType.IN);
			CWeatherData weatherDataOut = new CWeatherData(WeatherStationType.OUT);

			Display display = new Display(weatherDataIn, weatherDataOut);
			weatherDataIn.RegisterObserver(display, 2);
			weatherDataOut.RegisterObserver(display, 2);

			StatsDisplay statsDisplay = new StatsDisplay(weatherDataIn, weatherDataOut);
			weatherDataIn.RegisterObserver(statsDisplay, 0);
			weatherDataOut.RegisterObserver(statsDisplay, 1);

			StatsDisplay statsDisplay1 = new StatsDisplay(weatherDataIn, weatherDataOut);
			weatherDataOut.RegisterObserver(statsDisplay1, 0);

			weatherDataIn.SetMeasurements(3, 0.7, 760);
			weatherDataOut.SetMeasurements(4, 0.8, 761);

			weatherDataOut.RemoveObserver(statsDisplay);

			weatherDataIn.SetMeasurements(10, 0.8, 761);
			weatherDataOut.SetMeasurements(-10, 0.8, 761);
		}
    }
}
