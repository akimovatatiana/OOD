using System;

namespace SimUDuck.QuackBehaviors
{
    class QuackBehavior : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Quack Quack!!!");
        }
    }
}
