namespace Coffee.Beverages
{
    abstract class Beverage : IBeverage
    {
        private readonly string _description;

        public Beverage(string description)
        {
            _description = description;
        }

        public abstract double GetCost();

        public string GetDescription()
        {
            return _description;
        }
    }
}
