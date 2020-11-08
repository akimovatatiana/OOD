using System;

namespace GumballMachine
{
    class Program
    {
		static void TestGumballMachine(IGumballMachine m)
		{
			Console.WriteLine(m.ToString());

			m.InsertQuarter();
			m.TurnCrank();

			Console.WriteLine();
			Console.WriteLine(m.ToString());

			m.InsertQuarter();
			m.EjectQuarter();
			m.TurnCrank();

			Console.WriteLine();
			Console.WriteLine(m.ToString());

			m.InsertQuarter();
			m.TurnCrank();
			m.InsertQuarter();
			m.TurnCrank();
			m.EjectQuarter();

			Console.WriteLine();
			Console.WriteLine(m.ToString());

			m.InsertQuarter();
			m.InsertQuarter();
			m.TurnCrank();
			m.InsertQuarter();
			m.TurnCrank();
			m.InsertQuarter();
			m.TurnCrank();

			Console.WriteLine();
			Console.WriteLine(m.ToString());
		}

		static void Main()
        {
			var m = new GumballMachine(5);
			TestGumballMachine(m);
		}
    }
}
