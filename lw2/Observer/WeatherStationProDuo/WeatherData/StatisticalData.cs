﻿namespace WeatherStationProDuo.WeatherData
{
    public class StatisticalData
    {
        private double _min = double.PositiveInfinity;
        private double _max = double.NegativeInfinity;
        private double _acc = 0;
        private uint _countAcc = 0;

        public void UpdateData(double value)
        {
            if (_min > value)
            {
                _min = value;
            }
            if (_max < value)
            {
                _max = value;
            }
            _acc += value;
            ++_countAcc;
        }

        public string GetStatisticalData()
        {
            return $"\n    Max {_max}\n    Min {_min}\n    Average {_acc / _countAcc}";
        }
    }
}
