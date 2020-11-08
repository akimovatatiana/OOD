using MultiGumballMachine.GumballMachineWithState;
using System;

namespace MultiGumballMachine
{
	class Program
    {
		static void Main()
		{
			Console.WriteLine("Choose type of gumball machine. Type 0 for Gumball Machine With State or 1 for Naive Gumball Machine");
			uint type;

			while (!(uint.TryParse(Console.ReadLine(), out type) && (type == 1 || type == 0)))
			{
				Console.WriteLine("Wrong Gumball Machine type. Type 0 for Gumball Machine With State or 1 for Naive Gumball Machine");
			}

			if (type == 0)
			{
				uint numBalls = GetBallsNumber();
				TestGumballMachineWithState(numBalls);
			}
			else if (type == 1)
			{
				uint numBalls = GetBallsNumber();
				TestGumballMachineNaive(numBalls);
			}
		}

		private static void TestGumballMachineWithState(uint numBalls)
		{
			var gm = new GumballMachine(numBalls);
			Console.WriteLine("Enter a command. For more info enter 'help'");
			Client client = new Client(Console.Out, Console.In, gm);
			client.Start();
		}

		private static void TestGumballMachineNaive(uint numBalls)
		{
			var gm = new NaiveGumballMachine.GumballMachine(numBalls);
			Console.WriteLine("Enter a command. For more info enter 'help'");
			Client client = new Client(Console.Out, Console.In, gm);
			client.Start();
		}

		private static uint GetBallsNumber()
		{
			Console.WriteLine("Type number of gumballs");
			uint numBalls;
			while (!uint.TryParse(Console.ReadLine(), out numBalls))
			{
				Console.WriteLine("Wrong number of balls. Type balls number again");
			}
			return numBalls;
		}
	}
}
