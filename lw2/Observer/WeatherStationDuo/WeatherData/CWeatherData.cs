using WeatherStationDuo.Observer;

namespace WeatherStationDuo.WeatherData
{
    public class CWeatherData : Observable<SWeatherInfo>
    {
		private double _temperature;
		private double _humidity;
		private double _pressure;

		public double GetTemperature()
		{
			return _temperature;
		}

		public double GetHumidity()
		{
			return _humidity;
		}

		public double GetPressure()
		{
			return _pressure;
		}

		public void MeasurementsChanged()
		{
			NotifyObservers();
		}

		public void SetMeasurements(double temp, double humidity, double pressure)
		{
			_humidity = humidity;
			_temperature = temp;
			_pressure = pressure;

			MeasurementsChanged();
		}

		protected override SWeatherInfo GetChangedData()
        {
			SWeatherInfo info;
			info.temperature = GetTemperature();
			info.humidity = GetHumidity();
			info.pressure = GetPressure();
			return info;
        }
    }
}
