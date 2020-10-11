namespace Coffee.Beverages
{
    class Milkshake : Beverage
    {
		private readonly MilkshakeSize _size;

		public Milkshake(MilkshakeSize size = MilkshakeSize.Medium)
			: base(size.ToString() + " Milkshake")
		{
			_size = size;
		}

		public override double GetCost()
		{
			return _size switch
			{
				MilkshakeSize.Small => 50,
				MilkshakeSize.Medium => 60,
				MilkshakeSize.Large => 80,
				_ => 0,
			};
		}
	}

	public enum MilkshakeSize
	{
		Small,
		Medium,
		Large
	}
}
