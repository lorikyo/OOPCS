using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopcsWorkShops
{
    class Customer
    {
        //Attributes
        private string name;
        private string address;
        private string passport;
        private DateTime dateOfBirth;
        //constructors
        public Customer(string name, string address, string passport, DateTime dob):this(name, address, passport)
        {
            dateOfBirth = dob;
        }
        public Customer(string name, string address, string passport, int age):this(name, address, passport)
        {
            dateOfBirth = new DateTime(DateTime.Now.Year - age, 1, 1);
        }
        public Customer(string name, string address, string passport)
        {
            this.name = name;
            this.address = address;
            this.passport = passport;
        }
        public Customer():this("NoName", "NoAddress", "NoPassport", new DateTime(1980, 1, 1))
        {

        }
        //properties
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
                return DateTime.Now.Year - dateOfBirth.Year;
            }
        }
        //methods
        public string Show()
        {
            return string.Format("[Customer:name={0},address={1},passport={2},age={3}]",Name,Address,Passport,Age);
        }
    }
}
