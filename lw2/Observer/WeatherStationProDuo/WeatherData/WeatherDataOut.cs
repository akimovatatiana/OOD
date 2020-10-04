using WeatherStationProDuo.Observer;

namespace WeatherStationProDuo.WeatherData
{
    public class WeatherDataOut : Observable<SWeatherInfo>
	{
		private double _temperature;
		private double _humidity;
		private double _pressure;
		private double _speed;
		private double _direction;

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

		public double GetSpeed()
		{
			return _speed;
		}

		public double GetDirection()
		{
			return _direction;
		}

		public void MeasurementsChanged()
		{
			NotifyObservers();
		}

		public void SetMeasurements(double temp, double humidity, double pressure, double speed, double direction)
		{
			_humidity = humidity;
			_temperature = temp;
			_pressure = pressure;
			_speed = speed;
			_direction = direction;

			MeasurementsChanged();
		}

		protected override SWeatherInfo GetChangedData()
		{
			SWeatherInfo info;
			info.temperature = GetTemperature();
			info.humidity = GetHumidity();
			info.pressure = GetPressure();
			info.windInfo = new WindInfo()
			{
				speed = GetSpeed(),
				direction = GetDirection()
			};
			return info;
		}
	}
}
