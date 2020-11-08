namespace MultiGumballMachine.GumballMachineWithState
{
    public interface IGumballMachineContext : IGumballMachine
    {
        void ReleaseBall();
        uint GetBallCount();
        void SetSoldOutState();
        void SetNoQuarterState();
        void SetSoldState();
        void SetHasQuarterState();
        void SetMaxQuarterState();
        void AddQuarter();
        uint GetQuartersCount();
        void ReturnQuarters();
        void RefillBalls(uint numBalls);
    }
}
