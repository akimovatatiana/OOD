namespace Coffee.Beverages
{
    class Latte : Coffee
    {
        private readonly LatteSize _size;

        public Latte(LatteSize size = LatteSize.Standart)
            : base(size.ToString() + " Latte")
        {
            _size = size;
        }

        public override double GetCost()
        {
            return _size == LatteSize.Standart ? 90 : 130;
        }
    }

    public enum LatteSize
    {
        Standart,
        Double
    }
}
