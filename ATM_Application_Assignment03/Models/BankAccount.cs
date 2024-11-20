using ATM_Application_Assignment03.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Application_Assignment03.Models
{
    public class BankAccount : AccountBase, IBankAccount
    {
        public BankAccount(int accountNumber, double initialBalance, string accountHolderName, string password)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            InterestRate = 0.03; // 3% interest rate
            AccountHolderName = accountHolderName;
            Password = password;
        }

        public override bool ValidatePassword(string password)
        {
            return Password == password;
        }

        public override void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        public override bool Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public override double CalculateInterest()
        {
            return Balance * InterestRate;
        }

        public override string GetAccountStatement()
        {
            return $"Account Holder: {AccountHolderName}\n" +
                   $"Account Number: {AccountNumber}\n" +
                   $"Interest Rate: {InterestRate * 100}%\n" +
                   $"Current Balance: {Balance:C}\n" +
                   $"Interest Earned: {CalculateInterest():C}";
        }
    }
}
