using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WarConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Cold Dead World.");
            Thread.Sleep(1000);
            Console.WriteLine("Would You Like To Play?");
            if (YES())
            {
                Game game = new Game();
                game.start();
            }
            else
            {
                //otherwise run simple econ simulator
                Economy e = new Economy();
                Console.Write("Game Starting");

                while (true)
                {
                    e.addEvent();
                    e.updateEconomy();
                    e.updateEconomy();
                    e.updateEconomy();
                    Thread.Sleep(1000);
                }
            }
        }

        public static int EMP(){
            Console.WriteLine("(1/2/3)");
            char c = (char)Console.Read();
            if (c != '1' && c != '2' && c != '3')
            {
                Console.ReadLine();
                Console.WriteLine("Invalid Response. Please Type only 1, 2 or 3.");
                return EMP();
            }
            Console.ReadLine();
            if (c == '1') { return 1; }
            if (c == '2') { return 2; }
            if (c == '3') { return 3; }
            return 0;
        }

        public static bool YES()
        {
            Console.WriteLine("(Y/N)");
            var c = Console.Read();
            Console.ReadLine();
            if (c == 'y' || c == 'Y') { return true; }
            else if (c == 'n' || c == 'N') { return false; }
            else { 
                Console.WriteLine("Invalid Response. Please Type only Y or N.");
                return YES();
            }
        }
        public static void ENTER()
        {
            Console.WriteLine();
            Console.WriteLine("Press ENTER To Continue.");
            Console.Read();
            Console.ReadLine();
        }
    }
}
