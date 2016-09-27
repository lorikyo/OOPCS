using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop6
{
    public interface IInvestment
    {
        string Description
        {
            get;
        }
        double Cost
        {
            get;
        }
        double EstimatedValue
        {
            get;
        }
        DateTime Acquired
        {
            get;
        }
        double Profit();
    }
    public class Coin : IInvestment
    {
        string description;
        double cost;
        double estimatedValue;
        DateTime acquired;
        public Coin(string desc, double cost, double estimatedValue, int y)
        {
            description = desc;
            this.cost = cost;
            this.estimatedValue = estimatedValue;
            acquired = new DateTime(DateTime.Now.Year - y, 1, 1);
        }
        public string Description
        {
            get { return description; }
        }
        public double Cost
        {
            get { return cost; }
        }
        public double EstimatedValue
        {
            get { return estimatedValue; }
        }
        public DateTime Acquired
        {
            get { return acquired; }
        }
        public double Profit()
        {
            return EstimatedValue - Cost;
        }
    }
    public class Test
    {
        public static void Main()
        {
            //   List<IInvestment> list = new List<IInvestment>();
            //   list.Add(new Coin("Gold coin 1965", 1000, 1200, 3));
            //   // more objects may be added
            //   foreach (IInvestment c in list)
            //   {
            //       Console.WriteLine("{0}:+{1} {2}y", c.Description,
            //                                   c.Profit(), DateTime.Now.Year - c.Acquired.Year);
            //   }
            List<IInvestment> list = new List<IInvestment>();
            Coin c = new Coin("Gold coin 1965", 1000, 1200, 3);
            list.Add(c);
            foreach(IInvestment a in list)
            {
                Console.WriteLine("Description={0}, Cost={1}, EstimatedValue={2}", a.Description, a.Cost, a.EstimatedValue);
            }
        }
    }
}
