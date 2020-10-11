using Coffee.Beverages;

namespace Coffee.Condiments
{
    class IceCubes : CondimentDecorator
    {
        private readonly uint _quantity;
        private readonly IceCubeType _type;

        public IceCubes(IBeverage beverage, uint quantity, IceCubeType type = IceCubeType.Water)
            : base(beverage)
        {
            _quantity = quantity;
            _type = type;
        }

        public override double GetCondimentCost()
        {
            return (_type == IceCubeType.Dry ? 10 : 5) * _quantity;
        }

        public override string GetCondimentDescription()
        {
            return (_type == IceCubeType.Dry ? "Dry" : "Water") + " ice cubes x " + _quantity.ToString();
        }
    }
    public enum IceCubeType
    {
        Dry,
        Water
    }
}
