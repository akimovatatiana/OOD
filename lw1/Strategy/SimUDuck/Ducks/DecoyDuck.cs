using SimUDuck.DanceBehavior;
using SimUDuck.FlyBehavior;
using SimUDuck.QuackBehaviors;
using System;

namespace SimUDuck.Ducks
{
    class DecoyDuck : Duck
    {
        public DecoyDuck()
            : base(new FlyNoWay(), new MuteQuackBehavior(), new NoDanceBehavior())
        { }

        public override void Display()
        {
            Console.WriteLine("I'm decoy duck");
        }
    }
}
