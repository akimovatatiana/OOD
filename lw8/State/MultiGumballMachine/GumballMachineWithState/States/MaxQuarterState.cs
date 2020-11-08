using System;

namespace MultiGumballMachine.GumballMachineWithState.States
{
    public class MaxQuarterState : IState
    {
        private readonly IGumballMachineContext _gumballMachine;

        public MaxQuarterState(IGumballMachineContext gumballMachine)
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
            Console.WriteLine("You can't insert another quarter. Max quarters quantity is 5");
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
            return "at the max quarters quantity, waiting for turn of crank";
        }
    }
}
