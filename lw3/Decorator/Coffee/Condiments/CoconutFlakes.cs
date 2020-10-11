using Coffee.Beverages;

namespace Coffee.Condiments
{
    class CoconutFlakes : CondimentDecorator
    {
        private readonly uint _mass;

        public CoconutFlakes(IBeverage beverage, uint mass)
            : base(beverage)
        {
            _mass = mass;
        }

        public override double GetCondimentCost()
        {
            return 1.0 * _mass;
        }

        public override string GetCondimentDescription()
        {
            return "Coconut flakes " + _mass.ToString() + "g";
        }
    }
}
