using System;
using System.Collections;
using System.Text;

namespace OopcsWorkShops
{
    class BankAccount3
    {
        // Attributes
        private string accountNumber;
        private Customer accountHolder;
        private double balance;
        // Constructor
        public BankAccount3(string number, Customer holder, double bal)
        {
            accountNumber = number;
            accountHolder = holder;
            balance = bal;
        }
        public BankAccount3() : this("000-000-000", new Customer(), 0)
        {

        }
        // Properties
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public Customer AccountHolder
        {
            get
            {
                return accountHolder;
            }
            set
            {
                accountHolder = value;
            }
        }
        public double Balance
        {
            get
            {
                return balance;
            }
        }
        // Methods
        public void Deposit(double amount)
        {
            balance = balance + amount;
        }
        public bool Withdraw(double amount)
        {
            if (amount < balance)
            {
                balance = balance - amount;
                return true;
            }
            else
            {
                Console.Error.WriteLine("Withdrawal for {0} is unsuccessful", AccountHolder.Name); //?should it not be accountHolder instead of AccountHolder?
                return false;
            }

        }
        public bool TransferTo(double amount, BankAccount2 another)
        {
            if (Withdraw(amount))
            {
                another.Deposit(amount);
                return true;
            }
            else
            {
                Console.Error.WriteLine("TransferTo for {0} is unsuccessful", AccountHolder.Name);
                return false;
            }
        }
        public string Show()
        {
            string s = string.Format("[Account:accountNumber={0},accountHolder={1},balance={2}]", AccountNumber, AccountHolder.Show(), Balance);
            return s;
        }
    }
}

