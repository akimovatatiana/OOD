using WeatherStationPro.WeatherData;

namespace WeatherStationPro
{
    class Program
    {
        static void Main()
        {
            CWeatherData wd = new CWeatherData();

            Display display = new Display();
            wd.RegisterObserver(display, 1);

            StatsDisplay statsDisplay = new StatsDisplay();
            wd.RegisterObserver(statsDisplay, 0);

            wd.SetMeasurements(3, 0.7, 760, 4, 60);
            wd.SetMeasurements(4, 0.8, 761, 2, 90);

            wd.RemoveObserver(display);

            wd.SetMeasurements(10, 0.7, 760, 4, 270);
            wd.SetMeasurements(-10, 0.8, 761, 8, 180);
        }
    }
}
