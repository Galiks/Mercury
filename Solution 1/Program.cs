using NLog;
using Solution_1.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_1
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            Console.WriteLine($"Hello, User!");
            DisplayCommands();
            while (true)
            {
                Console.Write("Enter the command: ");
                string command = Console.ReadLine();
                string[] splitCommand = command.Split(' ');
                string commandName = splitCommand[0];
                switch (commandName)
                {
                    case ("create"):
                        CreateFigure(splitCommand);
                        break;
                    case ("list"):
                        Figure.PrintList();
                        break;
                    case ("area"):
                        GetArea(splitCommand);
                        break;
                    case ("sum"):
                        GetSumArea(splitCommand);
                        break;
                    case ("center"):
                        GetCenter(splitCommand);
                        break;
                    case ("intersect"):
                        GetIntersect(splitCommand);
                        break;
                    case ("help"):
                        DisplayCommands();
                        break;
                    case ("exit"):
                        return;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                } 
            }
        }

        private static void DisplayCommands()
        {
            Console.WriteLine($"You can use the next commands:{Environment.NewLine}" +
                                $"create - create figure;{Environment.NewLine}" +
                                $"if you don't know how create figure enter 'create help';{Environment.NewLine}" +
                                $"list - displays a list of all created shapes;{Environment.NewLine}" +
                                $"area <n> - calculates the area of the figure with the number n;{Environment.NewLine}" +
                                $"sum area - displays the total area of all created figures;{Environment.NewLine}" +
                                $"center <n> - calculates the geometric center (point) of the figure with the number n;{Environment.NewLine}" +
                                $"intersect <n> - displays figures which intersect with the figure with the number n.{Environment.NewLine}" +
                                $"help - displays commands{Environment.NewLine}");
        }

        private static void GetIntersect(string[] splitCommand)
        {
            if (splitCommand.Length == 2)
            {
                if (Int32.TryParse(splitCommand[1], out int index))
                {
                    Figure.Intersect(index);
                }
                else
                {
                    Console.WriteLine("Incorrect syntax");
                }
            }
            else
            {
                Console.WriteLine("Unknown command");
            }
        }

        private static void GetCenter(string[] splitCommand)
        {
            if (splitCommand.Length == 2)
            {
                if (Int32.TryParse(splitCommand[1], out int index))
                {
                    Figure.GetCenterOfFigure(index);
                }
                else
                {
                    Console.WriteLine("Incorrect syntax");
                }
            }
            else
            {
                Console.WriteLine("Unknown command");
            }
        }

        private static void GetSumArea(string[] splitCommand)
        {
            try
            {
                if (splitCommand[1] == "area")
                {
                    Figure.GetSumArea();
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Unknown command");
                logger.Error(e);
                return;
            }
        }

        private static void GetArea(string[] splitCommand)
        {
            if (splitCommand.Length == 2)
            {
                if (Int32.TryParse(splitCommand[1], out int index))
                {
                    Figure.GetArea(index);
                }
                else
                {
                    Console.WriteLine("Incorrect syntax");
                }
            }
            else
            {
                Console.WriteLine("Unknown command");
            }
        }

        private static void CreateFigure(string[] splitCommand)
        {
            string figureName = "";
            try
            {
                figureName = splitCommand[1];
                if (figureName.Equals("help"))
                {
                    HelpToCreateFigure();
                    return;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Unknown command");
                logger.Error(e);
                return;
            }

            switch (figureName.ToLower())
            {
                case ("circle"):
                    CreateCircle(splitCommand);
                    break;
                case ("square"):
                    CreateSquare(splitCommand);
                    break;
                case ("rectangle"):
                    CreateRectangle(splitCommand);
                    break;
                default:
                    Console.WriteLine("Unknown figure");
                    break;
            }
        }

        private static void HelpToCreateFigure()
        {
            Console.WriteLine("create circle<centerX> < centerY > < radius >\n" +
                                "create square<left> < top > < side >\n" +
                                "create rectangle<left> < top > < width > < height >\n");
        }

        private static void CreateRectangle(string[] splitCommand)
        {
            if (splitCommand.Length == 6)
            {
                double left = ParseToDouble(splitCommand[2]);
                double top = ParseToDouble(splitCommand[3]);
                double width = ParseToDouble(splitCommand[4]);
                double height = ParseToDouble(splitCommand[5]);
                if (!(Double.IsNaN(left) || Double.IsNaN(top) || Double.IsNaN(width) || Double.IsNaN(height)))
                {
                    var rectangle = new Rectangle(left, top, width, height, (uint)Figure.GetLastID() + 1);
                    Console.WriteLine(rectangle.ToString());
                    Figure.AddToList(rectangle);
                }
                else
                {
                    Console.WriteLine("Incorrect syntax");
                }
            }
            else
            {
                Console.WriteLine("Unknown command");
            }
        }

        private static void CreateSquare(string[] splitCommand)
        {
            if (splitCommand.Length == 5)
            {
                double left = ParseToDouble(splitCommand[2]);
                double top = ParseToDouble(splitCommand[3]);
                double side = ParseToDouble(splitCommand[4]);
                if (!(Double.IsNaN(left) || Double.IsNaN(top) || Double.IsNaN(side)))
                {
                    var square = new Square(left, top, side, (uint)Figure.GetLastID() + 1);
                    Console.WriteLine(square.ToString());
                    Figure.AddToList(square);
                }
                else
                {
                    Console.WriteLine("Incorrect syntax");
                }
            }
            else
            {
                Console.WriteLine("Unknown command");
            }
        }

        private static void CreateCircle(string[] splitCommand)
        {
            if (splitCommand.Length == 5)
            {
                double centerX = ParseToDouble(splitCommand[2]);
                double centerY = ParseToDouble(splitCommand[3]);
                double radius = ParseToDouble(splitCommand[4]);
                if (radius <= 0)
                {
                    Console.WriteLine("Radius less zero");
                }
                if (!(Double.IsNaN(centerX) || Double.IsNaN(centerY) || Double.IsNaN(radius)))
                {
                    var circle = new Circle(centerX, centerY, radius, (uint)Figure.GetLastID() + 1);
                    Console.WriteLine(circle.ToString());
                    Figure.AddToList(circle);
                }
                else
                {
                    Console.WriteLine("Incorrect syntax");
                }
            }
            else
            {
                Console.WriteLine("Unknown command");
            }
        }

        private static double ParseToDouble(string number)
        {
            if (Double.TryParse(number, out double result))
            {
                return result;
            }
            else
            {
                return Double.NaN;
            }
        }

        /// <summary>
        /// Тest figures
        /// </summary>
        private static void CreateTestFigure()
        {
            Figure.AddToList(new Circle(0.5, -0.5, 3, 1));
            Figure.AddToList(new Square(-1, 0, 2, 2));
            Figure.AddToList(new Rectangle(-1, 0, 2, 2, 3));
            Figure.AddToList(new Circle(5, 5, 1, 4));
            Figure.AddToList(new Circle(4.5, -4.5, 3, 5));
            Figure.AddToList(new Rectangle(10, 0, 2, 2, 6));
            Figure.AddToList(new Square(0, 1, 2, 7));
            Figure.AddToList(new Square(99, 99, 1, 8));
        }
    }
}
