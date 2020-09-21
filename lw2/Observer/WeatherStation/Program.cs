using WeatherStation.WeatherData;

namespace WeatherStation
{
    class Program
    {
        static void Main()
        {
			CWeatherData wd = new CWeatherData();

			Display display = new Display();
			wd.RegisterObserver(display, 1);

			StatsDisplay statsDisplay = new StatsDisplay();
			wd.RegisterObserver(statsDisplay, 2); 

			wd.SetMeasurements(3, 0.7, 760);
			wd.SetMeasurements(4, 0.8, 761);

			wd.RemoveObserver(statsDisplay);

			wd.SetMeasurements(10, 0.8, 761);
			wd.SetMeasurements(-10, 0.8, 761);
		}
    }
}
