namespace GumballMachine
{
    public interface IGumballMachineContext : IGumballMachine
    {
        void ReleaseBall();
        uint GetBallCount();
        void SetSoldOutState();
        void SetNoQuarterState();
        void SetSoldState();
        void SetHasQuarterState();
    }
}
