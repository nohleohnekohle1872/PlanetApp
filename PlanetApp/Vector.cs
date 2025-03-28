using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PlanetApp
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public static Vector XVector = new(1, 0, 0);
        public static Vector YVector = new(0, 1, 0);
        public static Vector ZVector = new(0, 0, 1);

        public Vector(double x, double y, double z)
        {
            X = x; 
            Y = y;
            Z = z;
        }

        public static Vector Addition(params Vector[] vectorArray)
        {
            double x = 0;
            double y = 0;
            double z = 0;
            foreach (Vector v in vectorArray)
            {
                x += v.X;
                y += v.Y;
                z += v.Z;
            }
            return new Vector(x, y, z);
        }

        public static Vector Subtraction(params Vector[] vectorArray)
        {
            double x = 0;
            double y = 0;
            double z = 0;
            foreach (Vector v in vectorArray)
            {
                x -= v.X;
                y -= v.Y;
                z -= v.Z;
            }
            return new Vector(x, y, z);
        }

        public static Vector MultiplyF(Vector vector, double factor)
        {
            return new(vector.X * factor, vector.Y * factor, vector.Z * factor);
        }

        public static double DotProduct(Vector vector1, Vector vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
        }

        public static Vector CrossProduct(Vector vector1, Vector vector2)
        {
            return new(vector1.Y * vector2.Z - vector1.Z * vector2.Y, vector1.Z * vector2.X - vector1.X * vector2.Z, vector1.X * vector2.Y - vector1.Y * vector2.X) ;
        }
        
        public static double ScalarTripleProduct(Vector vector1, Vector vector2, Vector vector3)
        {
            return DotProduct(CrossProduct(vector1, vector2), vector3);
        }

        public static double Length(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z);
        }

        public static double GetAngel(Vector vector1, Vector vector2)
        {
            double x = DotProduct(vector1, vector2) / (Length(vector1) * Length(vector2));
            return Program.TransformRadiantToDegree(Math.Acos(x));
        }
        
        public static Point ToPoint(Vector vector)
        {
            return new(vector.X, vector.Y, vector.Z);
        }

        public Matrix ToMatrix()
        {
            Matrix m = new(3, 1);
            m.Fill([X, Y, Z]);
            return m;
        }

        public Vector RotateOnX(double angle)
        {
            Matrix.X_RotationMatrix.Fill([1, 0, 0,
                                          0, Math.Cos(Program.TransformDegreeToRadiant(angle)), -Math.Sin(Program.TransformDegreeToRadiant(angle)),
                                          0, Math.Sin(Program.TransformDegreeToRadiant(angle)), Math.Cos(Program.TransformDegreeToRadiant(angle))]);

            Matrix m = this.ToMatrix();
            Matrix resultMatrix = Matrix.X_RotationMatrix.Multiply(m);
            return resultMatrix.ToVector3();
        }

        public Vector RotateOnY(double angle)
        {
            Matrix.Y_RotationMatrix.Fill([Math.Cos(Program.TransformDegreeToRadiant(angle)), 0, Math.Sin(Program.TransformDegreeToRadiant(angle)),
                                          0, 1, 0,
                                          -Math.Sin(Program.TransformDegreeToRadiant(angle)), 0, Math.Cos(Program.TransformDegreeToRadiant(angle))]);

            Matrix m = this.ToMatrix();
            Matrix resultMatrix = Matrix.Y_RotationMatrix.Multiply(m);
            return resultMatrix.ToVector3();
        }

        public Vector RotateOnZ(double angle)
        {
            Matrix.Z_RotationMatrix.Fill([Math.Cos(Program.TransformDegreeToRadiant(angle)), -Math.Sin(Program.TransformDegreeToRadiant(angle)), 0,
                               Math.Sin(Program.TransformDegreeToRadiant(angle)), Math.Cos(Program.TransformDegreeToRadiant(angle)), 0,
                               0, 0, 1]);

            Matrix m = this.ToMatrix();
            Matrix resultMatrix = Matrix.Z_RotationMatrix.Multiply(m);
            return resultMatrix.ToVector3();
        }

        public void Show(int x, int y)
        {
            HelpSystems.PrintString(x, y, X.ToString());
            y++;
            HelpSystems.PrintString(x, y, Y.ToString());
            y++;
            HelpSystems.PrintString(x, y, Z.ToString());
        }

        public static Vector Round(Vector v)
        {
            return new(Math.Round(v.X, 0), Math.Round(v.Y, 0), Math.Round(v.Z, 0));
        }

        public static Vector GetDirectionVectorBy2Points(Point p1, Point p2)
        {
            return new(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }

        public bool IsEqualTo(Vector v)
        {
            if (v.X == X && v.Y == Y && v.Z == Z)
                return true;
            return false;
        }
    }
}
