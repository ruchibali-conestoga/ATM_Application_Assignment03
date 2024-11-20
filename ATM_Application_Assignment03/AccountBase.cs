using ATM_Application_Assignment03.Interface;
using ATM_Application_Assignment03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ATM_Application_Assignment03
{
    public abstract class AccountBase
    {
        public int AccountNumber { get; protected set; }
        public double Balance { get; protected set; }
        public double InterestRate { get; protected set; }
        public string AccountHolderName { get; protected set; }
        protected string Password { get; set; }

        public abstract bool ValidatePassword(string password);
        public abstract void Deposit(double amount);
        public abstract bool Withdraw(double amount);
        public abstract string GetAccountStatement();
        public abstract double CalculateInterest();
    }

}