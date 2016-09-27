using System;

namespace Testing
{

    class Customer : IComparable
    {
        private string name;
        private string address;
        private double balance;
        //public int CompareTo(object another)
        //{
        //    if (another is Customer)
        //    {
        //        Customer a = (Customer)another;
        //        //    return Name.CompareTo(a.Name);
        //        //}
        //        //return -1;
        //        if (Balance < a.Balance) { return -1; }
        //        else if (Balance == a.Balance) { return 0; }
        //        else { return 1; }
        //    }
        //    return 0;
        //}
        public int CompareTo(Object another)
        {
            if (another is Customer)
            {
                Customer c = (Customer)another;
            
                if (Balance < c.Balance) { return -1; }
                else if (Balance == c.Balance) { return 0; }
                else { return 1; }
            }
            return 0;
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
        }
        public double Balance
        {
            get
            {
                return balance;
            }
        }
        public Customer(string n, string a, double b)
        {
            name = n;
            address = a;
            balance = b;
        }
        public static bool operator < (Customer x, Customer y)
        {
            return x.CompareTo(y) < 0;
        }
        public static bool operator >(Customer x, Customer y)
        {
            return x.CompareTo(y) > 0;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Customer c = new Customer("Tan Ah Kow", "4 Short Street", 2000);
            Customer d = new Customer("Tan Ah Lian", "81 Berry Road", 1500);
            int n = 65;
            int m = 231;
            Console.WriteLine(n < m);
            Console.WriteLine(c<d);
        }
    }
}
