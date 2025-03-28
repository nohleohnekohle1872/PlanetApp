using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetApp
{
    public class Axis
    {
        public Point StartPoint {  get; set; }
        public Point EndPoint { get; set; }
        public Point[] Points { get; set; } = [];

        public Axis(Point startPoint, Point endPoint) 
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Points = CalculatePoints();
        }

        private Point[] CalculatePoints()
        {
            List<Point> points = [];

            if (StartPoint.X == EndPoint.X)
            {
                for (int i = (int)StartPoint.Y; i < EndPoint.Y; ++i)
                {
                    points.Add(new(StartPoint.X, i, 0));
                }
            }
            else
            {
                for (int i = (int)StartPoint.X; i < EndPoint.X; ++i)
                {
                    points.Add(new(i, StartPoint.Y, 0));
                }
            }
            
            return points.ToArray();
        }

        public Point ReflectPoint(Point point)
        {
            // y-axis
            if (StartPoint.X == EndPoint.X)
            {
                var result = from p in Points
                             where p.Y == point.Y
                             select p;

                Point axisPoint = result.First();

                int distanceBetweenGivenPointAndAxis = (int)Math.Abs(axisPoint.X - point.X);

                if (point.X < result.First().X)
                {
                    return new(axisPoint.X + distanceBetweenGivenPointAndAxis, point.Y, 0);
                }
                else
                {
                    return new(axisPoint.X - distanceBetweenGivenPointAndAxis, point.Y, 0);
                }
            }

            // x-axis
            else
            {
                var result = from p in Points
                             where p.X == point.X
                             select p;

                Point axisPoint = result.First();

                int distanceBetweenGivenPointAndAxis = (int)Math.Abs(axisPoint.Y - point.Y);

                if (point.Y < result.First().Y)
                {
                    return new(point.X, axisPoint.Y + distanceBetweenGivenPointAndAxis, 0);
                }
                else
                {
                    return new(point.X, axisPoint.Y - distanceBetweenGivenPointAndAxis, 0);
                }
            }
        }

    }
}
