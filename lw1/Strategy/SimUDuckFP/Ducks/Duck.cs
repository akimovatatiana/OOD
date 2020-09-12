using System;

namespace SimUDuckFP.Ducks
{
    class Duck
    {
        Action _flyBehavior;
        Action _quackBehavior;
        Action _danceBehavior;

        public Duck(Action flyBehavior, Action quackBehavior, Action danceBehavior)
        {
            _flyBehavior = flyBehavior;
            _quackBehavior = quackBehavior;
            _danceBehavior = danceBehavior;
        }

        public void Quack()
        {
            _quackBehavior();
        }

        public void Swim()
        {
            Console.WriteLine("I'm swimming!");
        }

        public void Fly()
        {
            _flyBehavior();
        }

        public void Dance()
        {
            _danceBehavior();
        }

        public void SetFlyBehavior(Action flyBehavior)
        {
            _flyBehavior = flyBehavior;
        }

        public virtual void Display() { }
    }
}
