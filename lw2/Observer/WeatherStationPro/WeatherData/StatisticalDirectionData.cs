using System;

namespace WeatherStationPro.WeatherData
{
    public class StatisticalDirectionData
    {
        private double _sinSum = 0;
        private double _cosSum = 0;
        private uint _countAcc = 0;

        private double ConvertDegreesToRadians(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }

        private double ConvertRadiansToDegrees(double radians)
        {
            return (180 / Math.PI) * radians;
        }

        public void UpdateDirectionData(double value)
        {
            _sinSum += Math.Sin(ConvertDegreesToRadians(value));
            _cosSum += Math.Cos(ConvertDegreesToRadians(value));
            ++_countAcc;
        }

        public string GetAverageDirection()
        {
            var averageDirection = (ConvertRadiansToDegrees(Math.Atan2(_sinSum / _countAcc, _cosSum / _countAcc)) + 360) % 360;
            return $"    Average direction {averageDirection}";
        }
    }
}
