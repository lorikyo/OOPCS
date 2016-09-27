using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop6
{
    public abstract class Shape
    {
        public abstract void FindArea();
    }
    public class Triangle : Shape
    {
        public override void FindArea()
        {
            Console.WriteLine("Findarea Triangle");
        }
    }
    public class Rectangle : Shape
    {
        public override void FindArea()
        {
            Console.WriteLine("Findarea Rectangle");
        }
    }
    public class MainAbstract
    {
        static void Main(string[] args)
        {
            Shape s = new Triangle();
            Triangle t = new Triangle();
            Rectangle r = new Rectangle();
            
            s.FindArea();
            t.FindArea();
            //t.Draw(676);
            
        }
    }
}


