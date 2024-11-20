using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Application_Assignment03.Interfaces
{
    public interface IBankAccount
    {
        void Deposit(double amount);
        bool Withdraw(double amount);
        string GetAccountStatement();
        double CalculateInterest();
    }
}
