using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopcsWorkShops
{
    public class BadTriangleException : ApplicationException
    {
        public BadTriangleException() : base()
        {

        }
        public BadTriangleException(string message) : base(message)
        {
            Message = message;
        }
    }
    class BadTriangleExceptionTest
    {
        public static void Main()
        {
            Triangle r;
            try
            {
                r = new Triangle(10, 24, 1000);
                double maxSide = r.Side1;
                double sumOther2Side = r.Side2 + r.Side3;
                if (r.Side2 > maxSide)
                {
                    maxSide = r.Side2;
                    sumOther2Side = r.Side1 + r.Side3;
                }
                if (r.Side3 > maxSide)
                {
                    maxSide = r.Side3;
                    sumOther2Side = r.Side1 + r.Side2;
                }

                if (maxSide >= sumOther2Side)
                {
                    throw new BadTriangleException();
                }
                Console.WriteLine(r.StrValue());
                Console.WriteLine(r.Perimeter);
                Console.WriteLine(r.Area);
                Console.WriteLine(r.IsRightAngle);
            }
            catch (BadTriangleException e)
            {
                Console.Write("Exception: ");
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
