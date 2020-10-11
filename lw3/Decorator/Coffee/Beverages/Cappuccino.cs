namespace Coffee.Beverages
{
    class Cappuccino : Coffee
    {
        private readonly CappuccinoSize _size;

        public Cappuccino(CappuccinoSize size = CappuccinoSize.Standart)
            : base(size.ToString() + " Cappuccino")
        {
            _size = size;
        }

        public override double GetCost()
        {
            return _size == CappuccinoSize.Standart ? 80 : 120;
        }
    }

    public enum CappuccinoSize
    {
        Standart,
        Double
    }
}
