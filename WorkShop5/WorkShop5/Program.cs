using System;
using System.Collections;
using System.Text;

namespace Bank
{
    public class Customer
    {
        // Attributes
        private string name;
        private string address;
        private string passport;
        private int age;

        // Constructor
        public Customer(string name, string address, string passport, int age)
        {
            this.name = name;
            this.address = address;
            this.passport = passport;
            this.age = age;
        }

        public Customer(string name)
            : this(name, "ThisAddress", "ThisPassport", 0)
        {
        }

        public Customer()
            : this("ThisName", "ThisAddress", "ThisPassport", 0)
        {
        }

        // Properties
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
            set
            {
                address = value;
            }
        }
        public string Passport
        {
            get
            {
                return passport;
            }
            set
            {
                passport = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        // Methods

        public void GrowOld()
        {
            age = age + 1;
        }

        public override string ToString()
        {
            string m = String.Format("[Customer:name={0},address={1},passport={2},age={3}]",
                Name, Address, Passport, Age);
            return (m);
        }
    }
    public class Account
    {

    }
    public class SavingsAccount : Account
    {

    }
    public class CurrentAccount : Account
    {

    }
    public class OverdraftAccount : Account
    {

    }
    class BankBranch
    {

    }
    public class App
    {
        public static void Main()
        {
            BankBranch branch = new BankBranch("KOKO Bank Branch", "Tan Mon Nee");
            Customer cus1 = new Customer("Tan Ah Kow", "2 Rich Street", "P345123", 40);
            Customer cus2 = new Customer("Lee Tee Kim", "88 Fatt Road", "P678678", 54);
            Customer cus3 = new Customer("Alex Gold", "91 Dream Cove", "P333221", 34);
            branch.AddAccount(new SavingsAccount("S1230123", cus1, 2000));
            branch.AddAccount(new OverdraftAccount("O1230124", cus1, 2000));
            branch.AddAccount(new CurrentAccount("C1230125", cus2, 2000));
            branch.AddAccount(new OverdraftAccount("O1230126", cus3, -2000));
            branch.PrintCustomers();
            branch.PrintAccounts();
            Console.WriteLine(branch.TotalInterestEarned());
            Console.WriteLine(branch.TotalInterestPaid());
            branch.CreditInterest();
            branch.PrintAccounts();
        }
    }
}