using DesignPatternsLib.SimUDuck.Flying;
using DesignPatternsLib.SimUDuck.Quacking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.SimUDuck.Ducks
{
    public abstract class Duck
    {
        public FlyBehavior FlyBehavior { get; set; }
        public QuackBehavior QuackBehavior { get; set; }

        public abstract void Display();

        public void Swim()
        {
            Console.WriteLine("All ducks float, even decoys.");
        }

        public void PerformQuack()
        {
            QuackBehavior.Quack();
        }

        public void PerformFly()
        {
            FlyBehavior.Fly();
        }

        public void SetQuackBehavior(QuackBehavior quackBehavior)
        {
            QuackBehavior = quackBehavior;
        }

        public QuackBehavior GetQuackBehavior()
        {
            return QuackBehavior;
        }

        public void SetFlyBehavior(FlyBehavior flyBehavior)
        {
            FlyBehavior = flyBehavior;
        }

        public FlyBehavior GetFlyBehavior()
        {
            return FlyBehavior;
        }
    }
}
