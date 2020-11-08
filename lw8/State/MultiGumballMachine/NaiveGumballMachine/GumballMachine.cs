using MultiGumballMachine.GumballMachineWithState;
using System;

namespace MultiGumballMachine.NaiveGumballMachine
{
	public class GumballMachine : IGumballMachine
    {
		private uint _count;
		private State _state = State.SoldOut;
		private uint _quartersCount;

		public GumballMachine(uint count)
		{
			_count = count;
			_state = (count > 0) ? State.NoQuarter : State.SoldOut;
		}

		public void InsertQuarter()
		{
			switch (_state)
			{
				case State.SoldOut:
					Console.WriteLine("You can't insert a quarter, the machine is sold out");
					break;
				case State.NoQuarter:
					AddQuarter();
					_state = State.HasQuarter;
					break;
				case State.HasQuarter:
					AddQuarter();
					break;
				case State.Sold:
					Console.WriteLine("Please wait, we're already giving you a gumball");
					break;
			}
		}

		public void EjectQuarter()
		{
			switch (_state)
			{
				case State.HasQuarter:
					ReturnQuarters();
					_state = State.NoQuarter;
					break;
				case State.NoQuarter:
					Console.WriteLine("You haven't inserted a quarter");
					break;
				case State.Sold:
					Console.WriteLine("Sorry you already turned the crank");
					break;
				case State.SoldOut:
					if (_quartersCount > 0)
						ReturnQuarters();
					else
						Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
					break;
			}
		}

		public void TurnCrank()
		{	
			switch (_state)
			{
				case State.SoldOut:
					Console.WriteLine("You turned but there's no gumballs");
					break;
				case State.NoQuarter:
					Console.WriteLine("You turned but there's no quarter");
					break;
				case State.HasQuarter:
					Console.WriteLine("You turned...");
					_state = State.Sold;
					Dispense();
					break;
				case State.Sold:
					Console.WriteLine("Turning twice doesn't get you another gumball");
					break;
			}
		}

		public void Refill(uint numBalls)
		{
			if (numBalls > 0)
			{
				_count += numBalls;
				_state = _quartersCount > 0 ? State.HasQuarter : State.NoQuarter;
				Console.WriteLine($"Gumballs refilled. Gumballs count: {_count}");
			}
			else
			{
				Console.WriteLine("Cannot refill with no balls");
			}
		}

		private void AddQuarter()
		{
			if (_quartersCount < Constants.MaxQuartersCount)
			{
				_quartersCount++;
				Console.WriteLine($"You inserted a quarter. Quarters count: {_quartersCount}");
			}
			else
			{
				Console.WriteLine("You can't insert another quarter. Max quarters quantity is 5");
			}
		}

		private void ReturnQuarters()
		{
			Console.WriteLine($"Quarter{(_quartersCount > 1 ? "s" : "")} returned");
			_quartersCount = 0;
		}

		private void ReleaseBall()
		{
			if (_count != 0)
			{
				Console.WriteLine("A gumball comes rolling out the slot...");
				--_count;
				--_quartersCount;
			}
		}

		public override string ToString()
		{
			string state =
				(_state == State.SoldOut) ? "sold out" :
				(_state == State.NoQuarter) ? "waiting for quarter" :
				(_state == State.HasQuarter) ? "waiting for turn of crank"
				: "delivering a gumball";
			
			var fmt = $"Mighty Gumball, Inc.\nC# - enabled Standing Gumball Model #2020 (with state)\nInventory: {_count} gumball{(_count != 1 ? "s" : "")}\nMachine is {state}\n";
			return fmt;
		}

		private void Dispense()
		{
			switch (_state)
			{
				case State.Sold:
					ReleaseBall();
					if (_count == 0)
					{
						Console.WriteLine("Oops, out of gumballs");
						_state = State.SoldOut;
					}
					else if (_quartersCount > 0)
					{
						_state = State.HasQuarter;
					}
					else
					{
						_state = State.NoQuarter;
					}
					break;
				case State.NoQuarter:
					Console.WriteLine("You need to pay first");
					break;
				case State.SoldOut:
				case State.HasQuarter:
					Console.WriteLine("No gumball dispensed");
					break;
			}
		}
	}
}
