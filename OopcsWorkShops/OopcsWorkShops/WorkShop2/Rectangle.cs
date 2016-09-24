using System;
using System.Collections.Generic;
using System.Text;

namespace OopcsWorkShops
{
    public class Rectangle
    {
        double length, breadth;
        public Rectangle(double l, double b)
        {
            length = l;
            breadth = b;
        }
        public double Length
        {
            get
            {
                return length;
            }
        }
        public double Breadth
        {
            get
            {
                return breadth;
            }
        }
        public double Area
        {
            get
            {
                return Length * Breadth;
            }
        }
        public double Perimeter
        {
            get
            {
                return (2 * (Length + Breadth));
            }
        }
        public string StrValue()
        {
            return string.Format("Rectangle: {0},{1}", Length,Breadth);
        }
    }
    class RectangleMain
    {
        public static void Main()
        {
            Rectangle r = new Rectangle(10, 6);
            Console.WriteLine(r.StrValue());
            Console.WriteLine(r.Area);
            Console.WriteLine(r.Perimeter);
        }
    }
}
