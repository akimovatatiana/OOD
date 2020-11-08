namespace MultiGumballMachine.GumballMachineWithState
{
    public interface IGumballMachine
    {
        void EjectQuarter();
        void InsertQuarter();
        void TurnCrank();
        void Refill(uint numBalls);
    }
}
