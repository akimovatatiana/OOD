using SimUDuck.DanceBehavior;
using SimUDuck.FlyBehavior;
using SimUDuck.QuackBehaviors;
using System;

namespace SimUDuck.Ducks
{
    class RubberDuck : Duck
    {
        public RubberDuck()
            : base(new FlyNoWay(), new SqueakBehavior(), new NoDanceBehavior())
        { }

        public override void Display()
        {
            Console.WriteLine("I'm rubber duck");
        }
    }
}
