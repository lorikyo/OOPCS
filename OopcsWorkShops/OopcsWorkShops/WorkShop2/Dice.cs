using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISS.RV.LIB;

namespace OopcsWorkShops
{
    class Dice
    {
        //Attributes
        private int faceUp; 
        //Accessor & Mutator
        public int GetFaceUp()
        {
            return faceUp;
        }
        //Methods
        public void Throw()
        {
            faceUp = ISSMath.RNDInt(6) + 1; //returns random int frm 1 to 6
        }
        //Constructor
        public Dice()
        {
            Throw();
        }
        //Properties
        public string StrFaceUp
        {
            get
            {
                switch (faceUp)
                {
                    case 1: return "1"; //break;
                    case 2: return "2"; //break;
                    case 3: return "3"; //break;
                    case 4: return "4"; //break;
                    case 5: return "5"; //break;
                    default: return "6"; //break;
                } 
            }
        }
    }
    class DiceMain
    {
        public static void Main()
        {
            Dice d1 = new OopcsWorkShops.Dice();
            d1.Throw(); Console.WriteLine(d1.StrFaceUp);
            d1.Throw(); Console.WriteLine(d1.StrFaceUp);
            d1.Throw(); Console.WriteLine(d1.StrFaceUp);
            int count = 0;
            for (int i = 0; i < 1000; i++)
            {
                d1.Throw();
                int dicethrow1 = d1.GetFaceUp();
                d1.Throw();
                int dicethrow2 = d1.GetFaceUp();
                if (dicethrow1 + dicethrow2 == 8)
                {
                    count++;
                }
            }
            Console.WriteLine("Probability of '8' is: {0}", (double)count / 1000);
        }
    }
}
