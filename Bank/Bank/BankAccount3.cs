using System;
using System.Collections;
using System.Text;

namespace Bank
{
    public class Account
    {
        private string accountNumber;
        private Customer accountHolder;
        protected double balance;

        public Account(string acNum, Customer acHolder, double bal)
        {
            accountNumber = acNum;
            accountHolder = acHolder;
            balance = bal;
        }
        public Account() : this("NONAME", new Customer(), 0)
        {

        }

        public string AccountNumber
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
            protected set { balance = value; } //new syntax protected set
        }
        public void Deposit(double amount)
        {
            Balance = Balance + amount; //using Balance instead of balance
        }
        public bool Withdraw(double amount)
        {
            if (amount < Balance)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                Console.Error.WriteLine("amount > balance, cannot withdraw!");
                return false;
            }
        }
        public void TransferTo(double amount, Account another)
        {
            if (Withdraw(amount))
            {
                another.Deposit(amount);
            }
        }
        public double CalculateInterest()
        {
            double interest = 1 / 100 * Balance;
            return interest;
        }
        public void CreditInterest()
        {
            Deposit(CalculateInterest());
        }
        public string Show()
        {
            string m = string.Format("[SavingsAccount Number={0}, AccountHolder={1}, Balance={2}]", AccountNumber, AccountHolder.Show(), Balance);
            return m;
        }
    }
    public class CurrentAccount : Account
    {
        public CurrentAccount(string acNum, Customer acHolder, double bal) : base(acNum, acHolder, bal)
        {

        }

        public new double CalculateInterest()
        {
            double interest = 0.25 / 100 * Balance;
            return interest;
        }
        new public string Show()
        {
            string m = string.Format("[CurrentAccount number={0}, AccountHolder={1}, Balance={2}]", AccountNumber, AccountHolder.Show(), Balance);
            return m;
        }
    }
    public class OverdraftAccount : Account
    {
        private static double interestRate = 0.25;
        private static double overdraftInterest = 6;

        public OverdraftAccount(string acNum, Customer acHolder, double bal) : base(acNum, acHolder, bal)
        {

        }

        public new bool Withdraw(double amount)
        {
            Balance -= amount;
            return true;
        }
        public new double CalculateInterest()
        {
            return (Balance > 0) ? (interestRate / 100 * Balance) : (overdraftInterest / 100 * Balance);
        }
        public new string Show()
        {
            string m = string.Format("[OverDraftAccount number={0}, AccountHolder={1}, Balance={2}]", AccountNumber, AccountHolder.Show(), Balance);
            return m;
        }
    }
    public class Customer
    {
        private string name;
        private string address;
        private string passport;
        private DateTime dateOfBirth;

        public Customer()
        {

        }
        public Customer(string name, string address, string passport)
        {
            this.name = name;
            this.address = address;
            this.passport = passport;
        }
        public Customer(string name, string address, string passport, DateTime dob) : this(name, address, passport)
        {
            dateOfBirth = dob;
        }
        public Customer(string name, string address, string passport, int age) : this(name, address, passport)
        {
            dateOfBirth = new DateTime((DateTime.Now.Year - age), 1, 1);
        }

        public string Name
        {
            get { return name; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Passport
        {
            get { return passport; }
            set { passport = value; }
        }
        public int Age //note here that a variable age has not even been defined
        {
            get { return (DateTime.Now.Year - dateOfBirth.Year); }
        }
        public string Show()
        {
            string m = string.Format("[CustomerName={0}, Address={1}, Passport={2}, Age={3}]", Name, Address, Passport, Age);
            return m;
        }
    }
    public class App
    {
        static void Main(string[] args)
        {
            Customer cus1 = new Customer("Tan Ah Kow", "2 Rich Street", "P123123", 20);
            Customer cus2 = new Customer("Kim May Mee", "89 Gold Road", "P334412", 60);

            Account a1 = new Account("S0000223", cus1, 2000);
            Console.WriteLine(a1.CalculateInterest());
            OverdraftAccount a2 = new OverdraftAccount("O1230124", cus1, 2000);
            Console.WriteLine(a2.CalculateInterest());
            CurrentAccount a3 = new CurrentAccount("C1230125", cus2, 2000);
            Console.WriteLine(a3.CalculateInterest());

            Console.WriteLine(a2.Show());
            a2.Withdraw(5000);
            //a2.TransferTo(445, a2); //OverdraftAccount does not have TransferTo method redefined, got error
            Console.WriteLine(a2.CalculateInterest());
            Console.WriteLine(a2.Show());
        }
    }
}
