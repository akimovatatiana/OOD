using Coffee.Beverages;

namespace Coffee.Condiments
{
    class Chocolate : CondimentDecorator
    {
        private readonly uint _slices;

        public Chocolate(IBeverage beverage, uint slices)
            : base(beverage)
        {
            _slices = slices > 5 ? 5 : slices;
        }

        public override double GetCondimentCost()
        {
            return 10.0 * _slices;
        }

        public override string GetCondimentDescription()
        {
            return "Chocolate " + _slices.ToString() + " slices";
        }
    }
}
