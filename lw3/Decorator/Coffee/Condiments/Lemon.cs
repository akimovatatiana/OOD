using Coffee.Beverages;

namespace Coffee.Condiments
{
    class Lemon : CondimentDecorator
    {
        private readonly uint _quantity;

        public Lemon(IBeverage beverage, uint quantity)
           : base(beverage)
        {
            _quantity = quantity;
        }

        public override double GetCondimentCost()
        {
            return 10.0 * _quantity;
        }

        public override string GetCondimentDescription()
        {
            return "Lemon x " + _quantity.ToString();
        }
    }
}
