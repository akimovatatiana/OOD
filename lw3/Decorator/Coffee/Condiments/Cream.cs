using Coffee.Beverages;

namespace Coffee.Condiments
{
    class Cream : CondimentDecorator
    {
        public Cream(IBeverage beverage)
            : base(beverage)
        {
        }

        public override double GetCondimentCost()
        {
            return 25;
        }

        public override string GetCondimentDescription()
        {
            return "Cream";
        }
    }
}
