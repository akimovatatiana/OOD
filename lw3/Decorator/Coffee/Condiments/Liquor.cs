using Coffee.Beverages;

namespace Coffee.Condiments
{
    class Liquor : CondimentDecorator
    {
        private readonly LiquorType _type;

        public Liquor(IBeverage beverage, LiquorType type)
            : base(beverage)
        {
            _type = type;
        }

        public override double GetCondimentCost()
        {
            return 50;
        }

        public override string GetCondimentDescription()
        {
            return _type.ToString() + " Liquor";
        }
    }

    public enum LiquorType
    {
        Nut,
        Chocolate
    }
}
