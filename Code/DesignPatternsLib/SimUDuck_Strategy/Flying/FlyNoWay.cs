﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLib.SimUDuck.Flying
{
    public class FlyNoWay : FlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("Fly no way!");
        }
    }
}
