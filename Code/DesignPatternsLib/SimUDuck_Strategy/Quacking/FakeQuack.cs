using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.SimUDuck.Quacking
{
    public class FakeQuack : QuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Fake quack!");
        }
    }
}
