using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISS.RV.LIB;
//can use the properties Balance in console.error.writeline statements instead of the private attribute names balance.
//console.error.writeline
//initializing contructor have to pass in actual physical data
//dun ve to this.show() or this.Withdraw
//in this case BankAccount dun ve to be public
namespace OopcsWorkShops
{
    class BankAccount
    {
        // Attributes
        private string accountNumber;
        private string accountHolder;
        private double balance;
        // Constructor
        public BankAccount(string number, string holder, double bal)
        {
            accountNumber = number;
            accountHolder = holder;
            balance = bal;
        }
        public BankAccount() : this("000-000-000", "NONAME", 0)
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
        public string AccountHolder
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
            if(amount < balance)
            {
                balance = balance - amount;
                return true;
            }
            else
            {
                Console.Error.WriteLine("Withdrawal for {0} is unsuccessful", AccountHolder); //?should it not be accountHolder instead of AccountHolder?
                return false;
            }
            
        }
        public bool TransferTo(double amount, BankAccount another)
        {
            if (Withdraw(amount))
            {
                another.Deposit(amount);
                return true;
            }
            else
            {
                Console.Error.WriteLine("TransferTo for {0} is unsuccessful", AccountHolder);
                return false;
            }
        }
        public string Show()
        {
            string s = string.Format("[Account:accountNumber={0},accountHolder={1},balance={2}]",AccountNumber, AccountHolder, Balance);
            return s;
        }
    }
}
