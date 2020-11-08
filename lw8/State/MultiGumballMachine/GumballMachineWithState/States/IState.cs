namespace MultiGumballMachine.GumballMachineWithState.States
{
    public interface IState
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void Dispense();
        void Refill(uint numBalls);
        string ToString();
    }
}
