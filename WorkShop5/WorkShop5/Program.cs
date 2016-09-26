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
        private string accountNumber;
        private Customer accountHolder;
        private double balance;

        public Account() : this("000-000-000", new Customer(), 0)
        {

        }
        public Account(string accountNumber, Customer accountHolder, double balance)
        {
            this.accountNumber = accountNumber;
            this.accountHolder = accountHolder;
            this.balance = balance;
        }

        protected string AccountNumber //try protected instead of public constructor
        {
            get { return accountNumber; }
        }
        public Customer AccountHolder
        {
            get { return accountHolder; }
            set { accountHolder = value; }
        }
        public double Balance
        {
            get { return balance; }
            protected set { balance = value; }
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }
        public virtual bool Withdraw(double amount)
        {
            Balance -= amount;
            return true;
        }
        public void TransferTo(double amount, Account another)
        {
            Withdraw(amount);
            another.Deposit(amount);
        }
        public virtual double CalculateInterest()
        {
            return 0;
        }
        public void CreditInterest()
        {
            Deposit(CalculateInterest());
        }
        public override string ToString()
        {
            string a = string.Format("[Account Number={0}, AccountHolder={1}, Balance={2}]", AccountNumber, AccountHolder.ToString(), Balance);
            return a;
        }
    }
    public class SavingsAccount : Account
    {
        private static double interestRate = 1;

        public SavingsAccount(string accountNumber, Customer accountHolder, double balance) : base(accountNumber, accountHolder, balance)
        {

        }

        public override double CalculateInterest()
        {
            return interestRate / 100 * Balance;
        }
        public override bool Withdraw(double amount)
        {
            if (amount < Balance)
            {
                return base.Withdraw(amount);
            }
            else
            {
                Console.Error.WriteLine("Error! Withdraw amount > Balance");
                return false;
            }
        }
        public override string ToString()
        {
            string s = string.Format("[SavingsAccount Number={0}, AccountHolder={1}, Balance={2}]", AccountNumber, AccountHolder.ToString(), Balance);
            return s;
        }
    }
    public class CurrentAccount : Account
    {
        private static double interestRate = 0.25;

        public CurrentAccount(string accountNumber, Customer accountHolder, double balance) : base(accountNumber, accountHolder, balance)
        {

        }

        public override double CalculateInterest()
        {
            return interestRate / 100 * Balance;
        }
        public override bool Withdraw(double amount)
        {
            if (amount < Balance)
            {
                return base.Withdraw(amount);
            }
            else
            {
                Console.Error.WriteLine("Error! Withdraw amount > Balance");
                return false;
            }
        }
        public override string ToString()
        {
            string c = string.Format("[CurrentAccount Number={0}, AccountHolder={1}, Balance={2}]", AccountNumber, AccountHolder.ToString(), Balance);
            return c;
        }
    }
    public class OverdraftAccount : Account
    {
        private static double interestRate = 0.25;
        private static double overdraftInterest = 6;

        public OverdraftAccount(string accountNumber, Customer accountHolder, double balance) : base(accountNumber, accountHolder, balance)
        {

        }
        public override double CalculateInterest()
        {
            return (Balance > 0) ? (interestRate / 100 * Balance) : (overdraftInterest / 100 * Balance);
        }
        public override string ToString()
        {
            string o = string.Format("[OverdraftAccount Number={0}, AccountHolder={1}, Balance={2}]", AccountNumber, AccountHolder.ToString(), Balance);
            return o;
        }
    }
    class BankBranch
    {
        private string name;
        private string manager;
        private ArrayList accounts;

        public string Name
        {
            get { return name; }
        }
        public string Manager
        {
            get { return manager; }
        }

        public BankBranch(string n, string m)
        {
            name = n;
            manager = m;
            accounts = new ArrayList();
        }

        public void AddAccount(Account a)
        {
            accounts.Add(a);
        }
        public void PrintAccounts()
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                string a = accounts[i].ToString();
                Console.WriteLine(a);
            }
        }
        public void PrintCustomers()
        {
            ArrayList cust = new ArrayList();
            Account a;
            Customer c;
            for (int i = 0; i < accounts.Count; i++)
            {
                a = (Account)accounts[i];
                c = a.AccountHolder;
                if (cust.IndexOf(c) < 0)
                {
                    cust.Add(c);
                }
            }
            for (int j = 0; j < cust.Count; j++)
            {
                Console.WriteLine(cust[j].ToString());
            }
        }
        public void CreditInterest()
        {
            for (int j = 0; j < accounts.Count; j++)
            {
                Account a = (Account)accounts[j];
                a.CreditInterest();
            }
        }
        public double TotalDeposits()
        {
            double totalBalance = 0;
            for(int i=0; i<accounts.Count; i++)
            {
                Account a = (Account)accounts[i];
                if (a.Balance > 0)
                {
                    totalBalance += a.Balance;
                }
            }
            return totalBalance;
        }
        public double TotalInterestPaid()
        {
            double totalInterest = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                Account a = (Account)accounts[i];
                if (a.CalculateInterest() > 0)
                {

                    totalInterest += a.CalculateInterest();
                }
            }
            return totalInterest;
        }
        public double TotalInterestEarned()
        {
            double totalEarn = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                Account a = (Account)accounts[i];
                if (a.CalculateInterest() < 0)
                {

                    totalEarn += a.CalculateInterest();
                }
            }
            return Math.Abs(totalEarn);
        }
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