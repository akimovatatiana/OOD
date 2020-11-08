using System;

namespace MultiGumballMachine.GumballMachineWithState.States
{
    public class HasQuaterState : IState
    {
        private readonly IGumballMachineContext _gumballMachine;

        public HasQuaterState(IGumballMachineContext gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public void EjectQuarter()
        {
            _gumballMachine.ReturnQuarters();
            _gumballMachine.SetNoQuarterState();
        }

        public void InsertQuarter()
        {
            _gumballMachine.AddQuarter();
            if (_gumballMachine.GetQuartersCount() == Constants.MaxQuartersCount)
            {
                _gumballMachine.SetMaxQuarterState();
            }
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned...");
            _gumballMachine.SetSoldState();
        }

        public void Refill(uint numBalls)
        {
            _gumballMachine.RefillBalls(numBalls);
        }

        public override string ToString()
        {
            return "waiting for turn of crank";
        }
    }
}
