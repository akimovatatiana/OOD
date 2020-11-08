using System;

namespace MultiGumballMachine.GumballMachineWithState.States
{
    public class NoQuarterState : IState
    {
        private readonly IGumballMachineContext _gumballMachine;

        public NoQuarterState(IGumballMachineContext gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }

        public void Dispense()
        {
            Console.WriteLine("You need to pay first");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("You haven't inserted a quarter");
        }

        public void InsertQuarter()
        {
            _gumballMachine.AddQuarter();
            _gumballMachine.SetHasQuarterState();
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned but there's no quarter");
        }

        public void Refill(uint numBalls)
        {
            _gumballMachine.RefillBalls(numBalls);
        }

        public override string ToString()
        {
            return "waiting for quarter";
        }
    }
}
