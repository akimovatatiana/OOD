using Coffee.Beverages;

namespace Coffee.Condiments
{
    class Cinnamon : CondimentDecorator
    {
        public Cinnamon(IBeverage beverage)
            : base(beverage)
        {
        }

        public override double GetCondimentCost()
        {
            return 20;
        }

        public override string GetCondimentDescription()
        {
            return "Cinnamon";
        }
    }
}
