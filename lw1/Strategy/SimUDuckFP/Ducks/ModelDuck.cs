﻿using SimUDuckFP.Behaviors;
using System;

namespace SimUDuckFP.Ducks
{
    class ModelDuck : Duck
    {
        public ModelDuck()
            : base(FlyBehavior.FlyNoWay, QuackBehavior.Quack, DanceBehavior.NoDanceBehavior)
        { }

        public override void Display()
        {
            Console.WriteLine("I'm model duck");
        }
    }
}
