using ATM_Application_Assignment03.Models;

public class Program
{
    
        private static Dictionary<int, string> validAccounts = new Dictionary<int, string>
        {
            { 101, "password1" },
            { 102, "password2" },
            { 103, "password3" }
        };

        private static Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>
        {
            { 101, new BankAccount(101, 500.00, "John Doe") },
            { 102, new BankAccount(102, 1000.00, "Jane Smith") },
            { 103, new BankAccount(103, 750.00, "Bob Johnson") }
        };

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the ATM Application");

            Console.Write("Enter Account Number: ");
            int accountNumber;
            if (!int.TryParse(Console.ReadLine(), out accountNumber) || !validAccounts.ContainsKey(accountNumber))
            {
                Console.WriteLine("Invalid account number.");
                return;
            }

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (validAccounts[accountNumber] != password)
            {
                Console.WriteLine("Authentication failed.");
                return;
            }

            BankAccount userAccount = accounts[accountNumber];
            Console.WriteLine($"Welcome, {userAccount.AccountHolderName}!");

            while (true)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. View Account Statement");
                Console.WriteLine("5. Exit");

                Console.Write("Choose an option: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Current Balance: ${userAccount.Balance}");
                        break;
                    case 2:
                        Console.Write("Enter deposit amount: ");
                        double depositAmount;
                        if (double.TryParse(Console.ReadLine(), out depositAmount))
                        {
                            userAccount.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;
                    case 3:
                        Console.Write("Enter withdrawal amount: ");
                        double withdrawAmount;
                        if (double.TryParse(Console.ReadLine(), out withdrawAmount))
                        {
                            userAccount.Withdraw(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;
                    case 4:
                        userAccount.DisplayAccountStatement();
                        break;
                    case 5:
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
}
