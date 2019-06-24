using NLog;
using Solution_1.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_1
{
    class Figure
    {

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        protected static List<Figure> Figures { get; set; }
        public uint ID { get; private set; }

        static Figure()
        {
            Figures = new List<Figure>();
        }

        public Figure(uint iD)
        {
            ID = iD;
        }

        public static void GetArea(int index)
        {
            try
            {
                var figure = Figures[index - 1];
                Console.WriteLine("Area: " + figure.GetArea());
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Figure doesn’t exist");
                logger.Error(e);
            }    
        }

        protected virtual double GetArea()
        {
            return 0;
        }

        public static void GetSumArea()
        {
            double sumArea = 0;
            foreach (var item in Figures)
            {
                sumArea += item.GetArea();
            }
            Console.WriteLine("Sum area: " + sumArea);
        }

        public static void GetCenterOfFigure(int index)
        {
            try
            {
                var figure = Figures[index - 1];
                Console.WriteLine("Center: " + figure.GetCenter());
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Figure doesn’t exist");
                logger.Error(e);
            }
        }

        protected virtual string GetCenter()
        {
            return null;
        }

        public static void Intersect(int index)
        {
            Figure figure = Figures[index - 1];
            foreach (var item in Figures)
            {
                if (item != figure)
                {
                    figure.Intersect(item);
                }
            }
        }

        protected virtual void Intersect(Figure figure)
        {
            Console.WriteLine("Base method");
        }

        public static void PrintList()
        {
            if (Figures.Count > 0)
            {
                foreach (var item in Figures)
                {
                    Console.WriteLine(item.ToString());
                } 
            }
            else
            {
                Console.WriteLine("Empty result");
            }
        }

        public static void AddToList(Figure figure)
        {
            Figures.Add(figure);
        }

        public static int GetLastID()
        {
            return Figures.Count;
        }
    }
}
