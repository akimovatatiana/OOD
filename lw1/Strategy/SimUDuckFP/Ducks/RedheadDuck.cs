﻿using SimUDuckFP.Behaviors;
using System;

namespace SimUDuckFP.Ducks
{
    class RedheadDuck : Duck
    {
        public RedheadDuck()
           : base(FlyBehavior.FlyWithWings(), QuackBehavior.Quack, DanceBehavior.MinuetBehavior)
        { }

        public override void Display()
        {
            Console.WriteLine("I'm redhead duck");
        }
    }
}
