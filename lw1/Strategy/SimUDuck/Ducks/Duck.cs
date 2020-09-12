using SimUDuck.DanceBehavior;
using SimUDuck.FlyBehavior;
using SimUDuck.QuackBehaviors;
using System;

namespace SimUDuck.Ducks
{
    class Duck
    {
        private IFlyBehavior _flyBehavior;
        private IQuackBehavior _quackBehavior;
        private IDanceBehavior _danceBehavior;

        public Duck(IFlyBehavior flyBehavior, IQuackBehavior quackBehavior, IDanceBehavior danceBehavior)
        {
            _flyBehavior = flyBehavior;
            _quackBehavior = quackBehavior;
            _danceBehavior = danceBehavior;
        }

        public void Quack()
        {
            _quackBehavior.Quack();
        }

        public void Swim()
        {
            Console.WriteLine("I'm swimming!");
        }

        public void Fly()
        {
            _flyBehavior.Fly();
        }

        public void Dance()
        {
            _danceBehavior.Dance();
        }

        public void SetFlyBehavior(IFlyBehavior flyBehavior)
        {
            _flyBehavior = flyBehavior;
        }

        public virtual void Display() { }
    }
}
