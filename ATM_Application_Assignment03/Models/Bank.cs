using ATM_Application_Assignment03.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Application_Assignment03.Models
{
    public class Bank
    {
        private List<IBankAccount> accounts;

        public Bank()
        {
            accounts = new List<IBankAccount>
        {
            new BankAccount(101, 1000.00, "Curly Smith", "password123"),
            new BankAccount(102, 2000.00, "Larry Jones", "password456"),
            new BankAccount(103, 1500.00, "Moe Howard", "password789")
        };
        }

        public IBankAccount Authenticate(int accountNumber, string password)
        {
            var account = accounts.FirstOrDefault(a => a is BankAccount && ((BankAccount)a).AccountNumber == accountNumber);
            if (account != null && ((BankAccount)account).ValidatePassword(password))
            {
                return account;
            }
            return null;
        }
    }
}
