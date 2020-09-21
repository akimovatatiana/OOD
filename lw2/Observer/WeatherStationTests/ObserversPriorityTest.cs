using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using WeatherStation.WeatherData;

namespace WeatherStationTests
{
    [TestClass]
    public class ObserversPriorityTest
    {
        [TestMethod]
        public void Observers_WithHigherPriority_ShouldBeNotifiedFirst()
        {
            var wd = new CWeatherData();
            var testDisplay1 = new TestPriorityObserver(1);
            var testDisplay2 = new TestPriorityObserver(2);
            var testDisplay3 = new TestPriorityObserver(3);

            wd.RegisterObserver(testDisplay1, 1);
            wd.RegisterObserver(testDisplay2, 2);
            wd.RegisterObserver(testDisplay3, 3);

            var sw = new StringWriter();
            Console.SetOut(sw);
            Console.SetError(sw);
            wd.SetMeasurements(3, 0.7, 760);
            string result = sw.ToString();

            Assert.AreEqual("3;2;1;", result);
        }
    }
}
