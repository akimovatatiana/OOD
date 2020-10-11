using Coffee.Beverages;

namespace Coffee.Condiments
{
    class Syrup : CondimentDecorator
    {
        private readonly SyrupType _syrupType;

        public Syrup(IBeverage beverage, SyrupType syrupType)
            : base(beverage)
        {
            _syrupType = syrupType;
        }

        public override double GetCondimentCost()
        {
            return 15;
        }

        public override string GetCondimentDescription()
        {
            return (_syrupType == SyrupType.Chocolate ? "Chocolate" : "Maple") + " syrup";
        }
    }

    public enum SyrupType
    {
        Chocolate,
        Maple
    }
}
