using Coffee.Beverages;
using Coffee.Condiments;
using System;

namespace Coffee
{
    class Program
    {
		static void Main()
        {			
			{
				var latte = new Latte();
				var cinnamon = new Cinnamon(latte);
				var lemon = new Lemon(cinnamon, 2);
				var iceCubes = new IceCubes(lemon, 2, IceCubeType.Dry);
				var beverage = new ChocolateCrumbs(iceCubes, 2);

				Console.WriteLine(beverage.GetDescription() + " costs " + beverage.GetCost());
			}

			{
				var beverage =
					new ChocolateCrumbs(
						new IceCubes(             
							new Lemon(            
								new Cinnamon(     
									new Latte()),
								2),
							2, IceCubeType.Dry),
						2);

				Console.WriteLine(beverage.GetDescription() + " costs " + beverage.GetCost());
			}

			{
				var latte = new Latte(LatteSize.Double);
				var cinnamon = new Cinnamon(latte);
				var lemon = new Lemon(cinnamon, 2);
				var iceCubes = new IceCubes(lemon, 2, IceCubeType.Dry);
				var beverage = new ChocolateCrumbs(iceCubes, 2);

				Console.WriteLine(beverage.GetDescription() + " costs " + beverage.GetCost());
			}

			{
				var cappuccino = new Cappuccino(CappuccinoSize.Standart);
				var cinnamon = new Cinnamon(cappuccino);
				var lemon = new Lemon(cinnamon, 2);
				var iceCubes = new IceCubes(lemon, 2, IceCubeType.Dry);
				var liquor = new Liquor(iceCubes, LiquorType.Nut);
				var beverage = new ChocolateCrumbs(liquor, 2);

				Console.WriteLine(beverage.GetDescription() + " costs " + beverage.GetCost());
			}

			{
				var tea = new Tea(TeaType.Green);
				var cinnamon = new Cinnamon(tea);
				var lemon = new Lemon(cinnamon, 2);
				var iceCubes = new IceCubes(lemon, 2, IceCubeType.Dry);
				var beverage = new ChocolateCrumbs(iceCubes, 2);

				Console.WriteLine(beverage.GetDescription() + " costs " + beverage.GetCost());
			}
		}
    }
}
