using System;

namespace MultiGumballMachine.GumballMachineWithState.States
{
    public class SoldState : IState
    {
        private readonly IGumballMachineContext _gumballMachine;

        public SoldState(IGumballMachineContext gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void Dispense()
        {
            _gumballMachine.ReleaseBall();
            if (_gumballMachine.GetBallCount() == 0)
            {
                Console.WriteLine("Oops, out of gumballs");
                _gumballMachine.SetSoldOutState();
            }
            else if (_gumballMachine.GetQuartersCount() > 0)
            {
                _gumballMachine.SetHasQuarterState();
            }
            else
            {
                _gumballMachine.SetNoQuarterState();
            }
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Sorry you already turned the crank");
        }

        public void InsertQuarter()
        {
            Console.WriteLine("Please wait, we're already giving you a gumball");
        }

        public void TurnCrank()
        {
            Console.WriteLine("Turning twice doesn't get you another gumball");
        }

        public void Refill(uint numBalls)
        {
            Console.WriteLine("Can't refill gumballs when machine is giving you a gumball");
        }

        public override string ToString()
        {
            return "delivering a gumball";
        }
    }
}
