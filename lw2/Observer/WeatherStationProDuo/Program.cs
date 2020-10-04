using WeatherStationProDuo.WeatherData;

namespace WeatherStationProDuo
{
    class Program
    {
        static void Main()
        {
			WeatherDataIn weatherDataIn = new WeatherDataIn();
			WeatherDataOut weatherDataOut = new WeatherDataOut();

			Display display = new Display(weatherDataIn, weatherDataOut);
			StatsDisplay statsDisplay = new StatsDisplay(weatherDataIn, weatherDataOut);

			weatherDataIn.RegisterObserver(statsDisplay, 0);
			weatherDataOut.RegisterObserver(statsDisplay, 1);
			weatherDataIn.RegisterObserver(display, 2);

			weatherDataIn.SetMeasurements(3, 0.7, 760);
			weatherDataOut.SetMeasurements(4, 0.8, 761, 2, 60);

			weatherDataIn.RemoveObserver(display);

			weatherDataIn.SetMeasurements(10, 0.8, 761);
			weatherDataOut.SetMeasurements(-10, 0.8, 761, 2, 90);
		}
    }
}
