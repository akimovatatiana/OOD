using System;

namespace SimUDuck.QuackBehaviors
{
    class SqueakBehavior : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Squeek!!!");
        }
    }
}
