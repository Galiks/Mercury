using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Solution_5
{
    class Program
    {
        static object locker = new object();

        static void Main(string[] args)
        {

            for (int i = 0; i < 6; i++)
            {
                RunTrafficLight();
            }
            Console.ReadLine();
        }

        private static void RunTrafficLight()
        {
            Thread redThread = null;
            Thread yellowThread = null;
            Thread greenThread = null;

            redThread = new Thread(FuncForRedLight);
            yellowThread = new Thread(FuncForYellowLight);
            greenThread = new Thread(FuncForGreenLight);

            redThread.Start();
            yellowThread.Start();
            greenThread.Start();
        }

        public static void FuncForRedLight()
        {
            lock (locker)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(1000);
                Console.WriteLine("Зажегся красный");
            }            
        }

        public static void FuncForYellowLight()
        {
            lock (locker)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Thread.Sleep(1000);
                Console.WriteLine("Зажегся желтый");
            }
        }

        public static void FuncForGreenLight()
        {
            lock (locker)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(1000);
                Console.WriteLine("Зажегся зелёный");
            }
        }
    }
}
