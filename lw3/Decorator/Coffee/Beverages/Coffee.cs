namespace Coffee.Beverages
{
    class Coffee : Beverage
    {
		public Coffee(string description = "Coffee")
			: base(description)
		{
		}

		public override double GetCost()
		{
			return 60;
		}
	}
}
