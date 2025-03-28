namespace PlanetApp
{
    public class Program
    {
        public static int[] currentCursorPosition = [0, 0];
        public static Point MiddlePointOfBALL = new(80, 40, 0);
        public static int radiusOfBall = 20;
        public static List<Point> BallPoints = [];
        public static List<Point> newBallPointsAfterRotation = [];
        public static List<Point> CubePoints = [];
        public static List<List<Point>> listsWithPointsVectorRotationOnYAxis = [];
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.ReadKey();

            //CALCULATEBALLPOINTS();
            //DisplayBall();

            //while (true)
            //{
            //    TurnBall();
            //    DisplayBall();            
            //}


            Point MiddlePointOfSunSystem = new(600, 200, 0);
            Planet sun = new(10, "Sun", MiddlePointOfSunSystem, ConsoleColor.DarkYellow, "  ", ConsoleColor.DarkYellow, "  ");
            sun.Draw();
            Planet orbit1 = new(16, "Orbit1", MiddlePointOfSunSystem, ConsoleColor.Gray, "  ", ConsoleColor.Gray, "  ");
            orbit1.DrawBorder();
            Planet orbit2 = new(32, "Orbit2", MiddlePointOfSunSystem, ConsoleColor.Green, "  ", ConsoleColor.Green, "  ");
            orbit2.DrawBorder();
            Planet orbit3 = new(60, "Orbit3", MiddlePointOfSunSystem, ConsoleColor.DarkMagenta, "  ", ConsoleColor.DarkMagenta, "  ");
            orbit3.DrawBorder();
            Planet orbit4 = new(100, "Orbit4", MiddlePointOfSunSystem, ConsoleColor.Blue, "  ", ConsoleColor.Blue, "  ");
            orbit4.DrawBorder();
            Planet orbit5 = new(150, "Orbit5", MiddlePointOfSunSystem, ConsoleColor.DarkRed, "  ", ConsoleColor.DarkRed, "  ");
            orbit5.DrawBorder();

            Planet merkur = new(3, "Merkur", orbit1.BorderPoints.First(), ConsoleColor.DarkRed, "  ", ConsoleColor.DarkRed, "  ");
            Planet venus = new(5, "Venus", orbit2.BorderPoints.First(), ConsoleColor.DarkRed, "  ", ConsoleColor.DarkRed, "  ");
            Planet earth = new(8, "Earth", orbit3.BorderPoints.First(), ConsoleColor.DarkRed, "  ", ConsoleColor.DarkRed, "  ");
            Planet mars = new(15, "Mars", orbit4.BorderPoints.First(), ConsoleColor.DarkRed, "  ", ConsoleColor.DarkRed, "  ");
            Planet jupiter = new(37, "Juppiter", orbit5.BorderPoints.First(), ConsoleColor.DarkRed, "  ", ConsoleColor.DarkRed, "  ");

            Planet[] planets = { merkur, venus, earth, mars, jupiter };
            Planet[] orbits = { orbit1, orbit2, orbit3, orbit4, orbit5 };

            while (true)
            {
                for (int k = 0; k < orbits.First().BorderPoints.Length; k++)
                {
                    for (int i = 0; i < orbits.Length; i++)
                    {
                        planets[i].MiddlePoint = orbits[i].BorderPoints[k];
                        DrawPlanet(planets[i]);
                    }

                    for (int i = 0; i < planets.Length; i++)
                    {
                        RemovePlanet(planets[i]);
                    }
                }
            }


        }
        public static double TransformDegreeToRadiant(double degree)
        {
            return degree * Math.PI / 180D;
        }
        public static double TransformRadiantToDegree(double radiant)
        {
            return radiant * 180 / Math.PI;
        }
        public static void DrawPlanet(Planet planet)
        {
            planet.BorderPoints = planet.CalculateBorderPoints();
            planet.Draw();
        }
        public static void RemovePlanet(Planet planet)
        {
            planet.Remove();
            planet.BorderPoints = null;
        }
        public static void FireworkAnimation()
        {
            Point p1 = new(200, 300, 0);
            Point p2 = new(400, 280, 0);
            Point p3 = new(800, 280, 0);
            Point p4 = new(1000, 300, 0);

            Point[] f1 = [p1, new(p1.X, p1.Y - 5, 0), new(p1.X, p1.Y - 10, 0), new(p1.X, p1.Y - 15, 0), new(p1.X, p1.Y - 20, 0), new(p1.X, p1.Y - 25, 0), new(p1.X, p1.Y - 30, 0), new(p1.X, p1.Y - 35, 0), new(p1.X, p1.Y - 40, 0), new(p1.X, p1.Y - 45, 0), new(p1.X, p1.Y - 50, 0), new(p1.X, p1.Y - 55, 0), new(p1.X, p1.Y - 60, 0), new(p1.X, p1.Y - 65, 0), new(p1.X, p1.Y - 70, 0), new(p1.X, p1.Y - 75, 0), new(p1.X, p1.Y - 80, 0),];
            Point[] f2 = [p2, new(p2.X, p2.Y - 5, 0), new(p2.X, p2.Y - 10, 0), new(p2.X, p2.Y - 15, 0), new(p2.X, p2.Y - 20, 0), new(p2.X, p2.Y - 25, 0), new(p2.X, p2.Y - 30, 0), new(p2.X, p2.Y - 35, 0), new(p2.X, p2.Y - 40, 0), new(p2.X, p2.Y - 45, 0), new(p2.X, p2.Y - 50, 0), new(p2.X, p2.Y - 55, 0), new(p2.X, p2.Y - 60, 0), new(p2.X, p2.Y - 65, 0), new(p2.X, p2.Y - 70, 0), new(p2.X, p2.Y - 75, 0), new(p2.X, p2.Y - 80, 0)];
            Point[] f3 = [p3, new(p3.X, p3.Y - 5, 0), new(p3.X, p3.Y - 10, 0), new(p3.X, p3.Y - 15, 0), new(p3.X, p3.Y - 20, 0), new(p3.X, p3.Y - 25, 0), new(p3.X, p3.Y - 30, 0), new(p3.X, p3.Y - 35, 0), new(p3.X, p3.Y - 40, 0), new(p3.X, p3.Y - 45, 0), new(p3.X, p3.Y - 50, 0), new(p3.X, p3.Y - 55, 0), new(p3.X, p3.Y - 60, 0), new(p3.X, p3.Y - 65, 0), new(p3.X, p3.Y - 70, 0), new(p3.X, p3.Y - 75, 0), new(p3.X, p3.Y - 80, 0),];
            Point[] f4 = [p4, new(p4.X, p4.Y - 5, 0), new(p4.X, p4.Y - 10, 0), new(p4.X, p4.Y - 15, 0), new(p4.X, p4.Y - 20, 0), new(p4.X, p4.Y - 25, 0), new(p4.X, p4.Y - 30, 0), new(p4.X, p4.Y - 35, 0), new(p4.X, p4.Y - 40, 0), new(p4.X, p4.Y - 45, 0), new(p4.X, p4.Y - 50, 0), new(p4.X, p4.Y - 55, 0), new(p4.X, p4.Y - 60, 0), new(p4.X, p4.Y - 65, 0), new(p4.X, p4.Y - 70, 0), new(p4.X, p4.Y - 75, 0), new(p4.X, p4.Y - 80, 0)];

            Planet firework1 = new(40, "DavidsFirework", f1.Last(), ConsoleColor.DarkMagenta, "  ", ConsoleColor.DarkMagenta, "  ");
            Planet firework2 = new(40, "AntonsFirework", f2.Last(), ConsoleColor.Green, "  ", ConsoleColor.Green, "  ");
            Planet firework3 = new(40, "DavidsFirework", f3.Last(), ConsoleColor.Cyan, "  ", ConsoleColor.Cyan, "  ");
            Planet firework4 = new(40, "AntonsFirework", f4.Last(), ConsoleColor.DarkYellow, "  ", ConsoleColor.DarkYellow, "  ");

            while (true)
            {
                foreach (Point p in f1)
                {
                    p.Draw(ConsoleColor.DarkGray, "@@@");
                    Thread.Sleep(20);
                }

                DrawPlanet(firework1);

                foreach (Point p in f2)
                {
                    p.Draw(ConsoleColor.DarkGray, "@@@");
                    Thread.Sleep(20);
                }

                DrawPlanet(firework2);

                foreach (Point p in f3)
                {
                    p.Draw(ConsoleColor.DarkGray, "@@@");
                    Thread.Sleep(20);
                }

                DrawPlanet(firework3);

                foreach (Point p in f4)
                {
                    p.Draw(ConsoleColor.DarkGray, "@@@");
                    Thread.Sleep(20);
                }

                DrawPlanet(firework4);

                Console.Clear();
            }
        }
        public static void CALCULATEBALLPOINTS()
        {
            double radiusOfBall = 20;
            Vector vectorForAxisRotation;
            List<Vector> vectorsWhichAriseIfVectorForAxisRotationIsRotatedOnTheXAxis = [];
            List<List<Vector>> vectorsWhichAriseIfVectorForAxisRotationIsRotatedOnTheYAxis = [];
            List<Vector> vectorsMiddlePointOfBallToPointOfCircle_E_YZ = [];
            List<Point> pointsVectorRotationOnXAxis = [];
            
            Point MiddlePointOfBall = new(80, 40, 0);
            Point ViewPoint = new(80, 40, 40);
            Point LightSource = new(0, 0, 0);
            bool vectorAlreadyExists = false;
            int counter = 0;



            // 
            for (double i = 0; i < 361; i += 1)
            {
                vectorForAxisRotation = new(0, 0, radiusOfBall);
                vectorForAxisRotation = vectorForAxisRotation.RotateOnX(i);
                vectorForAxisRotation = Vector.Round(vectorForAxisRotation);

                foreach (Vector vX in vectorsWhichAriseIfVectorForAxisRotationIsRotatedOnTheXAxis)
                {
                    if (vX.IsEqualTo(vectorForAxisRotation))
                        vectorAlreadyExists = true;
                    else
                        vectorAlreadyExists = false;
                }

                if (!vectorAlreadyExists)
                {
                    vectorsWhichAriseIfVectorForAxisRotationIsRotatedOnTheXAxis.Add(vectorForAxisRotation);
                    listsWithPointsVectorRotationOnYAxis.Add([]);
                    vectorsWhichAriseIfVectorForAxisRotationIsRotatedOnTheYAxis.Add([]);
                }

            }

            // Berechnet die Punkte, die aus den Richtungsvektoren entstehen, die entstehen, wenn man den Vektor "vectorForAxisRotation" um die X-Achse dreht
            foreach (Vector v in vectorsWhichAriseIfVectorForAxisRotationIsRotatedOnTheXAxis)
            {
                VectorialLineEquation vLE1 = new(MiddlePointOfBall.ToVector(), v);
                Point p1 = vLE1.GetPoint(1);
                pointsVectorRotationOnXAxis.Add(p1);
            }

            // Berechnet die Vektoren, die für die Y-Achsen-Rotation benötigt werden
            foreach (Point P in pointsVectorRotationOnXAxis)
            {
                vectorsMiddlePointOfBallToPointOfCircle_E_YZ.Add(Vector.GetDirectionVectorBy2Points(P, MiddlePointOfBall));
            }

            vectorAlreadyExists = false;

            foreach (Vector vV in vectorsMiddlePointOfBallToPointOfCircle_E_YZ)
            {
                // Berechnet den Vektor, der entsteht, wenn der Vektor "vectorForAxisRotation" um die Y-Achse gedreht wird
                for (double i = 0; i < 361; i += 1)
                {
                    vectorForAxisRotation = vV.RotateOnY(i);
                    vectorForAxisRotation = Vector.Round(vectorForAxisRotation);

                    foreach (Vector v in vectorsWhichAriseIfVectorForAxisRotationIsRotatedOnTheYAxis[counter])
                    {
                        if (v.IsEqualTo(vectorForAxisRotation))
                            vectorAlreadyExists = true;
                        else
                            vectorAlreadyExists = false;
                    }

                    if (!vectorAlreadyExists)
                        vectorsWhichAriseIfVectorForAxisRotationIsRotatedOnTheYAxis[counter].Add(vectorForAxisRotation);
                }

                // Berechnet die Punkte die aus den Richtungsvektoren entstehen, wenn den Vektor "vectorForAxisRotation" um die Y-Achse dreht
                foreach (Vector v in vectorsWhichAriseIfVectorForAxisRotationIsRotatedOnTheYAxis[counter])
                {
                    VectorialLineEquation vLE1 = new(MiddlePointOfBall.ToVector(), v);
                    Point p1 = vLE1.GetPoint(1);
                    p1 = new(p1.X * 2, p1.Y, p1.Z);
                    listsWithPointsVectorRotationOnYAxis[counter].Add(p1);
                    BallPoints.Add(p1);

                    int x = new Random().Next(0, 9);
                    char c = ' ';
                    switch (x)
                    {
                        case 0:
                            c = 'i';
                            break;

                        case 1:
                            c = 'e';
                            break;

                        case 2:
                            c = 'a';
                            break;

                        case 3:
                            c = 'f';
                            break;

                        case 4:
                            c = 't';
                            break;

                        case 5:
                            c = 'p';
                            break;

                        case 6:
                            c = '@';
                            break;

                        case 7:
                            c = 'x';
                            break;

                        case 8:
                            c = 'k';
                            break;

                        default:
                            break;
                    }

                    p1.Sign = c;
                }

                counter++;
                vectorAlreadyExists = false;
            }
        }
        public static void CALCULATECUBEPOINTS(Point[] borderPoints)
        {

        }
        public static void DisplayBall()
        {
            foreach (Point p in BallPoints)
            {
                p.Draw(ConsoleColor.Red, new(p.Sign, 2));
            }
        }
        public static void TurnBall()
        {
            foreach (Point p in BallPoints)
            {
                Vector v = Vector.GetDirectionVectorBy2Points(p, MiddlePointOfBALL);
                v = v.RotateOnX(5);
                VectorialLineEquation vLE1 = new(MiddlePointOfBALL.ToVector(), v);
                Point p1 = vLE1.GetPoint(1);
                newBallPointsAfterRotation.Add(p1);
            }

            BallPoints = newBallPointsAfterRotation;
        }

        


    }
}