using System;

namespace SimUDuck.FlyBehavior
{
    class FlyWithWings : IFlyBehavior
    {
        private int flightCount = 0;
        public void Fly()
        {
            flightCount++;
            Console.WriteLine($"I'm flying with wings!! It's a flight number {flightCount}!");
        }
    }
}
