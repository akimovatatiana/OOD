namespace Coffee.Beverages
{
    class Tea : Beverage
	{
		public Tea(TeaType type = TeaType.Black)
			: base(type.ToString() + " Tea")
		{
		}

		public override double GetCost()
		{
			return 30;
		}
	}

	public enum TeaType
	{
		Black,
		Green,
		Red,
		Herbal
	}
}
