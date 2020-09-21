using WeatherStation.WeatherData;

namespace WeatherStationTests
{
    public class TestUpdateObserver : WeatherStation.Observer.IObserver<SWeatherInfo>
    {
        private readonly WeatherStation.Observer.IObservable<SWeatherInfo> _observable;

        public TestUpdateObserver(WeatherStation.Observer.IObservable<SWeatherInfo> observable)
        {
            _observable = observable;
        }

        public void Update(SWeatherInfo data)
        {
            _observable.RemoveObserver(this);
        }
    }
}
