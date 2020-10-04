using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using WeatherStationDuo.WeatherData;

namespace WeatherStationDuoTests
{
    [TestClass]
    public class WeatherStationDuoTest
    {
        [TestMethod]
        public void NotifyObservers_WithWeatherStationType()
        {
            var weatherDataIn = new CWeatherData(WeatherStationType.IN);
            var weatherDataOut = new CWeatherData(WeatherStationType.OUT);

            var display = new DisplayDuo(weatherDataIn, weatherDataOut);

            weatherDataIn.RegisterObserver(display, 1);
            weatherDataOut.RegisterObserver(display, 1);

            var sw = new StringWriter();
            Console.SetOut(sw);
            Console.SetError(sw);

            weatherDataIn.SetMeasurements(3, 0.7, 760);
            weatherDataOut.SetMeasurements(4, 0.8, 761);

            string result = sw.ToString();
            string expected = "Inside;Outside;";

            Assert.AreEqual(expected, result);
        }
    }
}
