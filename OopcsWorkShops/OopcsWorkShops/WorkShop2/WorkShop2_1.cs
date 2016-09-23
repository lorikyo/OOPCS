using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISS.RV.LIB;

namespace OopcsWorkShops
{
    public class Coin
    {
        // Attributes
        private int face;

        // Methods
        public int GetFace()
        {
            return face;
        }

        public void Flip()
        {
            face = ISSMath.RNDInt(2);
        }
        
        // Constructors
        public Coin()
        {
            Flip();
        }

        // Properties
        public string StrFace
        {
            get
            {
                if (GetFace() == 0) return "Heads";
                else return "Tails";
            }
        }
    }

    public class WorkShop2_1
    {
        public static void Main()
        {
            Coin coin1 = new Coin();
            coin1.Flip();
            coin1.Flip(); Console.WriteLine("Coin1: {0}", coin1.StrFace);
            coin1.Flip(); Console.WriteLine("Coin1: {0}", coin1.StrFace);
            coin1.Flip(); Console.WriteLine("Coin1: {0}", coin1.StrFace);

            Coin coin2 = new Coin();
            coin2.Flip(); Console.WriteLine("Coin2: {0}", coin2.StrFace);

            Console.WriteLine("Coin1: {0}", coin1.StrFace);

            Coin coin3 = new Coin();
            coin3.Flip();
            Console.WriteLine(coin3.StrFace);
        }
    }
}
