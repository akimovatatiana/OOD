using SimUDuck.DanceBehavior;
using SimUDuck.FlyBehavior;
using SimUDuck.QuackBehaviors;
using System;

namespace SimUDuck.Ducks
{
    class MallardDuck : Duck
    {
        public MallardDuck()
            : base(new FlyWithWings(), new QuackBehavior(), new WaltzBehavior())
        { }

        public override void Display() 
        {
            Console.WriteLine("I'm mallard duck");
        }
    }
}
