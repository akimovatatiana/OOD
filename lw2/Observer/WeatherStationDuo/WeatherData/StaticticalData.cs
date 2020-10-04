namespace WeatherStationDuo.WeatherData
{
    public class StaticticalData
    {
        private double _min = double.PositiveInfinity;
        private double _max = double.NegativeInfinity;
        private double _acc = 0;
        private uint _countAcc = 0;

        public string GetStatisticalData(double value)
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

            return $"\n    Max {_max}\n    Min {_min}\n    Average {_acc / _countAcc}";
        }
    }
}
