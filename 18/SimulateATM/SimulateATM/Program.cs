using System;

namespace SimulateATMApp
{
    struct Account
    {
        public string AccountNumber, OwnerName, PIN;
        public decimal Balance;
        public int WrongAttempts;
    }

    class Program
    {
        static void Withdraw(ref decimal balance, decimal amount)
        {
            if (amount % 50000 != 0) Console.WriteLine("Amount must be a multiple of 50,000.");
            else if (amount > balance) Console.WriteLine("Insufficient balance!");
            else { balance -= amount; Console.WriteLine("Withdrawal successful."); }
        }

        static void Main()
        {
            Console.WriteLine("LeThiThuHuyen_6551071037");
            Account acc = new Account { AccountNumber = "123", OwnerName = "John Doe", PIN = "0000", Balance = 1000000 };
            string[] history = new string[10];
            int historyCount = 0;

            for (int i = 1; i <= 3; i++)
            {
                Console.Write("Enter PIN: ");
                if (Console.ReadLine() == acc.PIN) goto MainMenu;
                Console.WriteLine($"Incorrect PIN attempt {i}");
            }
            Console.WriteLine("Account locked!"); return;

        MainMenu:
            while (true)
            {
                Console.WriteLine("\n1.Check Balance 2.Withdraw 3.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: Console.WriteLine($"Balance: {acc.Balance}"); break;
                    case 2:
                        try
                        {
                            Console.Write("Enter amount to withdraw: ");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            Withdraw(ref acc.Balance, amount);
                            if (historyCount < 10) history[historyCount++] = $"Withdrew {amount}";
                        }
                        catch { Console.WriteLine("Invalid number format!"); }
                        break;
                    case 3: return;
                }
            }
        }
    }
}