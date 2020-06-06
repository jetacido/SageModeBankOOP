using System;

namespace SageModeBankOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            string tempUsername = string.Empty;
            string tempPassword = string.Empty;
            bool shouldExit = false;
            bool shouldLogout = false;
            decimal dAmount = 0;
            decimal wAmount = 0;
            Bank b = new Bank();
            Account a = new Account();
            b.Name = "SageMode";
            Console.WriteLine($"Welcome to {b.Name}");
            while (!shouldExit)
            {
                switch (ShowMenu("Register", "Login", "Exit"))
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("[Registration]");
                        Console.Write("Please enter your username: ");
                        tempUsername = Console.ReadLine();
                        if (b.IsAccountExist(tempUsername))
                        {
                            Console.WriteLine("Account already exist...");
                            Console.ReadKey();
                            continue;
                        }
                        else
                        {
                            Console.Write("Please enter your password: ");
                            tempPassword = Console.ReadLine();
                            b.Register(tempUsername, tempPassword);
                            Console.WriteLine($"Succesfully Registered Total: {b._TotalAccountsRegistered}, Please login!");
                            Console.ReadKey();
                        }
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("[Login]");
                        Console.Write("Please enter your username: ");
                        tempUsername = Console.ReadLine();
                        Console.Write("Please enter your password: ");
                        tempPassword = Console.ReadLine();
                        shouldLogout = false;
                        if (!b.IsLoggedin(tempUsername, tempPassword))
                        {
                            Console.WriteLine("Invalid Username or Password...");
                            Console.ReadKey();
                            continue;
                        }
                        while (!shouldLogout)
                        {
                            Console.Clear();
                            Console.WriteLine("[Login]");
                            Console.WriteLine($"Balance:  {a.Balances[b._CurrentAccountIndex]}");
                            switch (ShowMenu("Deposit", "Withdraw", "Logout"))
                            {
                                case '1':
                                    Console.Clear();
                                    Console.WriteLine("[Deposit]");
                                    Console.Write("Enter the amount to deposit: ");
                                    dAmount = 0;
                                    if (decimal.TryParse(Console.ReadLine(), out dAmount))
                                    {
                                        a.Balances[b._CurrentAccountIndex] += dAmount;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Amount!");
                                        Console.ReadKey();
                                    }
                                    break;
                                case '2':
                                    Console.Clear();
                                    Console.WriteLine("[Withdraw]");
                                    Console.Write("Enter the amount to deposit: ");
                                    wAmount = 0;
                                    if (decimal.TryParse(Console.ReadLine(), out wAmount))
                                    {
                                        if (wAmount > a.Balances[b._CurrentAccountIndex])
                                        {
                                            Console.WriteLine("Not enough funds!");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            a.Balances[b._CurrentAccountIndex] -= wAmount;
                                        }

                                    }
                                    break;
                                case '3':
                                    shouldLogout = true;
                                    continue;
                            }
                        }
                        break;
                    case '3':
                        Console.WriteLine("Thank you for Banking with us.");
                        Console.ReadKey();
                        shouldExit = true;
                        break;
                    default:
                        break;
                }
            }
        }
        static char ShowMenu(params string[] items)
        {
            string menuString = "Press ";
            for (int i = 0; i < items.Length; i++)
            {
                string postFix = i == items.Length - 1 ? string.Empty : ", ";
                menuString += $"{i + 1} to {items[i]}{postFix}";
            }
            Console.Write($"{menuString}: ");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            return key.KeyChar;
        }
    }
}
