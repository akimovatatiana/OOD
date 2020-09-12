﻿using SimUDuckFP.Behaviors;
using System;

namespace SimUDuckFP.Ducks
{
    class RubberDuck : Duck
    {
        public RubberDuck()
            : base(FlyBehavior.FlyNoWay, QuackBehavior.Squeak, DanceBehavior.NoDanceBehavior)
        { }

        public override void Display()
        {
            Console.WriteLine("I'm rubber duck");
        }
    }
}
