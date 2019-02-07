using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.SimUDuck.Quacking
{
    public class NormalQuack : QuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Normal quack!");
        }
    }
}
