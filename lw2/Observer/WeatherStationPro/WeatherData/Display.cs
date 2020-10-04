using System;

namespace WeatherStationPro.WeatherData
{
    public class Display : Observer.IObserver<SWeatherInfo>
    {
        public void Update(SWeatherInfo data)
        {
            Console.WriteLine($"Current Temp {data.temperature}");
            Console.WriteLine($"Current Hum {data.humidity}");
            Console.WriteLine($"Current Pressure {data.pressure}");
            Console.WriteLine($"Current Wind Speed {data.windInfo.speed}");
            Console.WriteLine($"Current Wind Direction {data.windInfo.direction}");
            Console.WriteLine("----------------");
        }
    }
}
