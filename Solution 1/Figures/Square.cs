using Solution_1.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_1
{
    class Square:Figure
    {
        private string Name
        {
            get
            {
                return GetType().Name;
            }
        }
        public double Left { get; private set; }
        public double Top { get; private set; }
        public double Side { get; private set; }

        public Square(double left, double top, double side, uint iD) : base(iD)
        {
            Left = left;
            Top = top;
            Side = side;
        }

        protected override double GetArea()
        {
            return Side * Side;
        }

        public override string ToString()
        {
            return $"#{ID} {Name}: left = {Left}, top = {Top}, side = {Side}";
        }

        protected override string GetCenter()
        {
            var left = Left + (Side / 2);
            var top = Top - (Side / 2);
            return $"{left} {top}";
        }

        protected override void Intersect(Figure figure)
        {
            if (figure is Circle)
            {
                if (IsIntersectWithCircle(figure as Circle))
                {
                    Console.WriteLine(figure.ToString());
                }
            }
            else if (figure is Square)
            {
                if (IsIntersectWithSquare(figure as Square))
                {
                    Console.WriteLine(figure.ToString());
                }
            }
            else if (figure is Rectangle)
            {
                if (IsIntersectWithRectangle(figure as Rectangle))
                {
                    Console.WriteLine(figure.ToString());
                }
            }
        }

        /// <summary>
        /// Does a rectangle cross a square
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        private bool IsIntersectWithRectangle(Rectangle rectangle)
        {
            double rectangleLeft = rectangle.Left;
            double rectangleTop = rectangle.Top;
            double rectangleRight = rectangleLeft + rectangle.Width;
            double rectangleBottom = rectangleTop - rectangle.Height;
            return HandlerIsIntersect(rectangleLeft, rectangleTop, rectangleRight, rectangleBottom);
        }

        /// <summary>
        /// Does a square cross a square
        /// </summary>
        /// <param name="square"></param>
        /// <returns></returns>
        private bool IsIntersectWithSquare(Square square)
        {
            double squareLeft = square.Left;
            double squareTop = square.Top;
            double squareRight = squareLeft + square.Side;
            double squareBottom = squareTop - square.Side;
            return HandlerIsIntersect(squareLeft, squareTop, squareRight, squareBottom);
        }

        /// <summary>
        /// Handler for interseect logic
        /// </summary>
        /// <param name="figureLeft">top left point along the axis X of figure</param>
        /// <param name="figureTop">top left point along the axis Y of figure</param>
        /// <param name="figureRight">bottom right point along the axis X of figure</param>
        /// <param name="figureBottom">bottom right point along the axis Y of figure</param>
        /// <returns>is intersect</returns>
        private bool HandlerIsIntersect(double figureLeft, double figureTop, double figureRight, double figureBottom)
        {
            double thisRight = Left + Side;
            double thisBottom = Top - Side;

            double left = Math.Max(figureLeft, Left);
            double top = Math.Min(figureTop, Top);
            double right = Math.Min(figureRight, thisRight);
            double bottom = Math.Max(figureBottom, thisBottom);

            double width = right - left;
            double height = top - bottom;

            if ((width < 0) || (height < 0))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Does a circle cross a square
        /// </summary>
        /// <param name="circle">Circle class object</param>
        /// <returns>is intersect</returns>
        private bool IsIntersectWithCircle(Circle circle)
        {
            double left = Left;
            double top = Top;
            double right = left + Side;
            double bottom = top - Side;
            double circleX = circle.PointX;
            double circleY = circle.PointY;
            double circleRadius = circle.Radius;
            if (circleY < top)
            {
                if (circleX < left)
                {
                    return ((circleX - left) * (circleX - left) + (circleY - top) * (circleY - top)) <= circleRadius * circleRadius;
                }
                if (circleX > right)
                {
                    return ((circleX - right) * (circleX - right) + (circleY - top) * (circleY - top)) <= circleRadius * circleRadius;
                }
                return (top - circleY) <= circleRadius;
            }
            if (circleY > bottom)
            {
                if (circleX < left)
                {
                    return ((circleX - left) * (circleX - left) + (circleY - bottom) * (circleY - bottom)) <= circleRadius * circleRadius;
                }
                if (circleX > right)
                {
                    return ((circleX - right) * (circleX - right) + (circleY - bottom) * (circleY - bottom)) <= circleRadius * circleRadius;
                }
                return (circleY - bottom) <= circleRadius; 
            }
            if (circleX < left)
            {
                return (left - circleX) <= circleRadius;
            }
            if (circleX > right)
            {
                return (circleX - right) <= circleRadius;
            }
            return true;
        }
    }
}
