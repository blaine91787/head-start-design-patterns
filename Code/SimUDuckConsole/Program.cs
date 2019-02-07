using DesignPatternsLib.SimUDuck.Ducks;
using DesignPatternsLib.SimUDuck.Flying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuckConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Duck mallard = new MallardDuck();
            mallard.PerformQuack();
            mallard.PerformFly();

            Duck model = new ModelDuck();
            model.PerformQuack();
            model.PerformFly();
            model.FlyBehavior = new FlyRocketPowered();
            model.PerformFly();




            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
