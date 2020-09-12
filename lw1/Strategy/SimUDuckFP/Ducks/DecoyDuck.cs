using SimUDuckFP.Behaviors;
using System;

namespace SimUDuckFP.Ducks
{
    class DecoyDuck : Duck
    {
        public DecoyDuck()
            : base(FlyBehavior.FlyNoWay, QuackBehavior.Mute, DanceBehavior.NoDanceBehavior)
        { }

        public override void Display()
        {
            Console.WriteLine("I'm decoy duck");
        }
    }
}
