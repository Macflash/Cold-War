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
            Economy e = new Economy();
            Console.Write("Game Starting");

            while (YES())
            {
                e.addEvent();
                e.updateEconomy();
                e.updateEconomy();
                e.updateEconomy();
                Thread.Sleep(1000);
            }
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
    }
}
