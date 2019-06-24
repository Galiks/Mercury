using Solution_1.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_1
{
    class Circle:Figure
    {
        private string Name
        {
            get
            {
                return GetType().Name;
            }
        }
        public double PointX { get; private set; }
        public double PointY { get; private set; }

        public double Radius { get; private set; }

        public Circle(double pointX, double pointY, double radius, uint iD) : base(iD)
        {
            PointX = pointX;
            PointY = pointY;
            Radius = radius;
        }

        protected override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override string ToString()
        {
            return $"#{ID} {Name}: x = {PointX}, y = {PointY}, radius = {Radius}";
        }

        protected override string GetCenter()
        {
            return $"{PointX} {PointY}";
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
        /// Does a circle cross an another circle
        /// </summary>
        /// <param name="circle">Circle class object</param>
        /// <returns>is intersect</returns>
        private bool IsIntersectWithCircle(Circle circle)
        {
            var radiusSpacing = Math.Sqrt(Math.Pow(Math.Abs(PointX - circle.PointX), 2) 
                + Math.Pow(Math.Abs(PointY - circle.PointY), 2));
            if ((Radius + circle.Radius) < radiusSpacing ||
                Math.Abs(Radius - circle.Radius) > radiusSpacing)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Does a circle cross a square
        /// </summary>
        /// <param name="square">Square class object</param>
        /// <returns>is intersect</returns>
        private bool IsIntersectWithSquare(Square square)
        {
            double left = square.Left;
            double top = square.Top;
            double right = left + square.Side;
            double bottom = top - square.Side;
            return HandlerIsIntersect(left, top, right, bottom);
        }

        /// <summary>
        /// Does a circle cross a rectagle
        /// </summary>
        /// <param name="rectangle">Rectangle class object</param>
        /// <returns>is intersect</returns>
        private bool IsIntersectWithRectangle(Rectangle rectangle)
        {
            double left = rectangle.Left;
            double top = rectangle.Top;
            double right = left + rectangle.Width;
            double bottom = top - rectangle.Height;
            return HandlerIsIntersect(left, top, right, bottom);
        }

        /// <summary>
        /// Handler for intersect logic
        /// </summary>
        /// <param name="left">top left point along the axis X</param>
        /// <param name="top">top left point along the axis Y</param>
        /// <param name="right">bottom right point along the axis X</param>
        /// <param name="bottom">bottom right point along the axis Y</param>
        /// <returns>is intersect</returns>
        private bool HandlerIsIntersect(double left, double top, double right, double bottom)
        {
            double circleX = PointX;
            double circleY = PointY;
            double circleRadius = Radius;
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
