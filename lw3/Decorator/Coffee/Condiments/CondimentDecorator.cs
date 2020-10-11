using Coffee.Beverages;

namespace Coffee.Condiments
{
    abstract class CondimentDecorator : IBeverage
    {
        private readonly IBeverage _beverage;

        protected CondimentDecorator(IBeverage beverage)
        {
            _beverage = beverage;
        }

        public string GetDescription()
        {
            return _beverage.GetDescription() + ", " + GetCondimentDescription();
        }

        public double GetCost()
        {
            return _beverage.GetCost() + GetCondimentCost();
        }

        public abstract double GetCondimentCost();

        public abstract string GetCondimentDescription();
    }
}