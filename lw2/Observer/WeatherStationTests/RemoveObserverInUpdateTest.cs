using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherStation.WeatherData;

namespace WeatherStationTests
{
    [TestClass]
    public class RemoveObserverInUpdateTest
    {
        [TestMethod]
        public void RemoveObserverInUpdate_ShouldNotThrownException()
        {
            CWeatherData wd = new CWeatherData();
            TestUpdateObserver to = new TestUpdateObserver(wd);

            wd.RegisterObserver(to, 1);
            wd.SetMeasurements(3, 0.7, 760);
        }
    }
    
}
