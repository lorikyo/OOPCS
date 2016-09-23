using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OopcsWorkShops
{
    class Triangle
    {
        double s1, s2, s3;
        public Triangle(double a, double b, double c)
        {
            s1 = a;
            s2 = b;
            s3 = c;
        }
        public double Side1
        {
            get
            {
                return s1;
            }
        }
        public double Side2
        {
            get
            {
                return s2;
            }
        }
        public double Side3
        {
            get
            {
                return s3;
            }
        }
        public double Area
        {
            get
            {
                double s = (s1 + s2 + s3) / 2;
                double r = Math.Sqrt(s * (s - s1) * (s - s2) * (s - s3));
                return r;
            }
        }
        public double Perimeter
        {
            get
            {
                return s1 + s2 + s3;
            }
        }
        public bool IsRightAngle
        {
            get
            {
                return ((s1 * s1 + s2 * s2) == (s3 * s3));
            }
        }
        public string StrValue()
        {
            return String.Format("Triangle: {0},{1},{2}", s1, s2, s3);
        }
    }
    class TriangleMain
    {
        public static void Main()
        {
            Triangle r = new Triangle(10, 24, 26);
            Console.WriteLine(r.StrValue());
            Console.WriteLine(r.Perimeter);
            Console.WriteLine(r.Area);
            Console.WriteLine(r.IsRightAngle);
        }
    }
}
