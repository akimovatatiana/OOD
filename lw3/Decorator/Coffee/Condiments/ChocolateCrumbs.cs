using Coffee.Beverages;

namespace Coffee.Condiments
{
    class ChocolateCrumbs : CondimentDecorator
    {
        private readonly uint _mass;

        public ChocolateCrumbs(IBeverage beverage, uint mass)
            : base(beverage)
        {
            _mass = mass;
        }

        public override double GetCondimentCost()
        {
            return 2.0 * _mass;
        }

        public override string GetCondimentDescription()
        {
            return "Chocolate crumbs " + _mass.ToString() + "g";
        }
    }
}
