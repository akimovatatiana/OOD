using GumballMachine.States;
using System;

namespace GumballMachine
{
    public class GumballMachineContext : IGumballMachineContext
    {
        private uint _count = 0;
        private readonly SoldState _soldState;
        private readonly SoldOutState _soldOutState;
        private readonly NoQuarterState _noQuarterState;
        private readonly HasQuaterState _hasQuaterState;
        private IState _state;

        public GumballMachineContext(uint numBalls)
        {
            _soldState = new SoldState(this);
            _soldOutState = new SoldOutState(this);
            _noQuarterState = new NoQuarterState(this);
            _hasQuaterState = new HasQuaterState(this);
            _count = numBalls;
            _state = (numBalls > 0) ? _noQuarterState : (IState)_soldOutState;
        }

        public void EjectQuarter()
        {
            _state.EjectQuarter();
        }

        public void InsertQuarter()
        {
            _state.InsertQuarter();
        }

        public void TurnCrank()
        {
            _state.TurnCrank();
            _state.Dispense();
        }

        public override string ToString()
        {
            var fmt = $"Mighty Gumball, Inc.\nC# - enabled Standing Gumball Model #2020 (with state)\nInventory: {_count} gumball{(_count != 1 ? "s" : "")}\nMachine is {_state}\n";
            return fmt;
        }

        public uint GetBallCount()
        {
            return _count;
        }

        public void ReleaseBall()
        {
            if (_count != 0)
            {
                Console.WriteLine("A gumball comes rolling out the slot...");
                --_count;
            }
        }

        public void SetHasQuarterState()
        {
            _state = _hasQuaterState;
        }

        public void SetNoQuarterState()
        {
            _state = _noQuarterState;
        }

        public void SetSoldOutState()
        {
            _state = _soldOutState;
        }

        public void SetSoldState()
        {
            _state = _soldState;
        }
    }
}
