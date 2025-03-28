using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PlanetApp
{
    public class Planet
    {
        public int Radius { get; set; }
        public string Name { get; set; }
        public Point[] BorderPoints { get; set; } = [];
        public Point MiddlePoint {  get; set; }
        public Point[] FillPoints { get; set; } = [];
        public ConsoleColor BorderColor { get; set; }
        public ConsoleColor FillColor { get; set; }
        public string BorderSign { get; set; }
        public string FillSign { get; set; }

        public Planet(int radius, string name, Point middlePoint, ConsoleColor borderColor, string borderSign, ConsoleColor fillColor, string fillSign) 
        { 
            Radius = radius;
            Name = name;
            MiddlePoint = middlePoint;
            BorderColor = borderColor;
            BorderSign = borderSign;
            FillColor = fillColor;
            FillSign = fillSign;
            BorderPoints = CalculateBorderPoints();
        }

        public Point[] CalculateBorderPoints()
        {
            List<Point> borderPoints = [];
            Point previousPoint = null;
            int _AA = 10;
            if (Radius > 20)
                _AA = 9;

            if (Radius > 30)
                _AA = 8;

            if (Radius > 70)
                _AA = 6;

            if (Radius > 130)
                _AA = 4;

            if (Radius > 200)
                _AA = 2;

            for (double i = 0; i <= 360; i += _AA)
            {
                int x = (int)Math.Round(Math.Cos(Program.TransformDegreeToRadiant(i)) * Radius) * 2 + (int)MiddlePoint.X;
                int y = (int)Math.Round(Math.Sin(Program.TransformDegreeToRadiant(i)) * Radius) + (int)MiddlePoint.Y;

                Point point = new(x, y, 0);
                
                if (i == 0)
                    borderPoints.Add(point);
                else
                {
                    if (!point.IsEqualTo(previousPoint))
                        borderPoints.Add(point);
                }
                
                previousPoint = point;
            }

            return borderPoints.ToArray();
        }

        public void DrawBorder()
        {
            foreach (Point point in BorderPoints)
            {
                point.Draw(BorderColor, BorderSign);
            }
        }

        public void Fill()
        {
            int previousRadius = Radius;

            for (int i = 0; Radius > 0; i++)
            {
                Radius -= 1;
                FillPoints = CalculateBorderPoints();
                foreach (Point point in FillPoints)
                {
                    point.Draw(FillColor, FillSign);
                }
            }

            Radius = previousRadius;
            FillPoints = null;
            FillPoints = [];
        }

        public void ReverseFill()
        {
            int previousRadius = Radius;
            Radius = 0;

            for (int i = 0; i < previousRadius; i++)
            {
                Radius += 1;
                FillPoints = CalculateBorderPoints();
                foreach (Point point in FillPoints)
                {
                    point.Draw(FillColor, FillSign);
                }
            }

            Radius = previousRadius;
            FillPoints = null;
            FillPoints = [];
        }
        public void RemoveFill()
        {
            int previousRadius = Radius;

            for (int i = 0; Radius > 0; i++)
            {
                Radius -= 1;
                FillPoints = CalculateBorderPoints();
                foreach (Point point in FillPoints)
                {
                    point.Remove();
                }
            }

            Radius = previousRadius;
            FillPoints = null;
            FillPoints = [];
        }

        public void ReverseRemoveFill()
        {
            int previousRadius = Radius;
            Radius = 0;

            for (int i = 0; i < previousRadius; i++)
            {
                Radius += 1;
                FillPoints = CalculateBorderPoints();
                foreach (Point point in FillPoints)
                {
                    point.Remove();
                }
            }

            Radius = previousRadius;
            FillPoints = null;
            FillPoints = [];
        }

        public void Draw()
        {
            DrawBorder();
            ReverseFill();
        }

        public void Remove()
        {
            RemoveBorder();
            ReverseRemoveFill();
        }

        public void RemoveBorder()
        {
            foreach (Point point in BorderPoints)
            {
                point.Remove();
            }
        }
    }
}
