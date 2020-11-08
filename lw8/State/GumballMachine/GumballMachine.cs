using System;

namespace GumballMachine
{
    public class GumballMachine : IGumballMachine
    {
        private readonly IGumballMachineContext _gumballMachineContext;

        public GumballMachine(uint numBalls)
        {
            _gumballMachineContext = new GumballMachineContext(numBalls);
        }

        public void EjectQuarter()
        {
            _gumballMachineContext.EjectQuarter();
        }

        public void InsertQuarter()
        {
            _gumballMachineContext.InsertQuarter();
        }

        public void TurnCrank()
        {
            _gumballMachineContext.TurnCrank();
        }

        public override string ToString()
        {
            return _gumballMachineContext.ToString();
        }
    }
}
