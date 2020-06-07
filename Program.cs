using System;

namespace SageModeBankOOP
{
    class Program
    {
        static string tempUsername = string.Empty;
        static string tempPassword = string.Empty;
        static bool shouldLogout = false;
        static bool shouldExit = false;
        static Bank b = new Bank();
        static Account CurrentAccount;

        static void Main(string[] args)
        {
            Console.Clear();
            b.Name = "J.A.";
            Console.WriteLine($"Welcome to {b.Name}\n");
            while (!shouldExit)
            {
                switch (ShowMenu("Register", "Login", "Exit"))
                {
                    case '1':
                        DisplayRegistration();
                        break;
                    case '2':
                        DisplayLogin();
                        break;
                    case '3':
                        Console.Clear();
                        Console.Write("Thank you for Banking with us.");
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
        static void DisplayRegistration()
        {
            Console.Clear();
            Console.WriteLine("[Registration]");
            Console.Write("Please enter your username: ");
            tempUsername = Console.ReadLine();
            if (b.IsAccountExist(tempUsername))
            {
                Console.Write("Account already exist...");
                ReadandClear();
            }
            else if (tempUsername == "" || tempUsername == " ")
            {
                Console.Write("Invalid entry");
                ReadandClear();
            }
            else
            {
                Console.Write("Please enter your password: ");
                tempPassword = Console.ReadLine();
                b.Register(tempUsername, tempPassword);
                Console.Write("Succesfully Registered. Please login!");
                ReadandClear();
            }
        }
        static void DisplayLogin()
        {
            Console.Clear();
            Console.WriteLine("[Home]");
            Console.Write("Please enter your username: ");
            tempUsername = Console.ReadLine();
            Console.Write("Please enter your password: ");
            tempPassword = Console.ReadLine();
            CurrentAccount = b.Login(tempUsername, tempPassword);

            if (CurrentAccount != null)
            {
                shouldLogout = false;

                while (!shouldLogout)
                {
                    Console.Clear();
                    Console.WriteLine("[Login]");
                    Console.WriteLine($"Balance: P{CurrentAccount.Balance}");

                    switch (ShowMenu("Deposit", "Withdraw", "Transactions", "Transfer", "Logout"))
                    {
                        case '1':
                            ShowDeposit();
                            break;
                        case '2':
                            ShowWithdraw();
                            break;
                        case '3':
                            ShowTransactionHistory();
                            break;
                        case '4':
                            ShowTransfer();
                            break;
                        case '5':
                            Console.Clear();
                            Console.Write("Thank you for Banking with us.");
                            ReadandClear();
                            shouldLogout = true;
                            continue;
                        default:
                            break;
                    }

                }
            }
            else
            {
                Console.Write("Invalid Username/Password");
                ReadandClear();
            }
        }
        static void ShowWithdraw()
        {
            Console.Clear();
            Console.WriteLine("[Withdraw]");
            Console.Write("Enter the amount to withdraw: ");
            decimal wAmount = 0;
            if (decimal.TryParse(Console.ReadLine(), out wAmount))
            {
                if (wAmount > CurrentAccount.Balance)
                {
                    Console.Write("Insufficient funds!");
                    Console.ReadKey();
                }
                else
                {
                    CurrentAccount.Withdraw(wAmount);
                }
            }
            else
            {
                Console.Write("Invalid Amount entered!");
                Console.ReadKey();
            }
        }
        static void ShowDeposit()
        {
            Console.Clear();
            Console.WriteLine("[Deposit]");
            Console.Write("Enter the amount to deposit: ");
            decimal dAmount = 0;
            if (decimal.TryParse(Console.ReadLine(), out dAmount))
            {
                CurrentAccount.Deposit(dAmount);
            }
            else
            {
                Console.WriteLine("Invalid Amount!");
                Console.ReadKey();
            }
        }
        static void ShowTransactionHistory()
        {
            Console.Clear();
            Console.WriteLine("[Transaction History]");
            Console.WriteLine("Action\t\tDate\t\t\tAmount\tReceiver");
            foreach (Transaction transact in CurrentAccount.GetTransactions())
            {
                if (transact.Receiver != null)
                {
                    string receiver = transact.Receiver.Username;
                    Console.WriteLine($"{transact.Type}\t\t{transact.Date}\t {transact.Amount}\t {receiver}");
                }
            }
            Console.ReadKey();
        }
        static void ShowTransfer()
        {
            Console.Clear();
            Console.WriteLine("[Transfer]");
            Console.Write("Enter Account ID: ");
            int receiverID = -1;
            if (int.TryParse(Console.ReadLine(), out receiverID))
            {
                Console.Write("Enter amount to transfer: ");
                decimal transferAmount = decimal.Parse(Console.ReadLine());
                if (transferAmount > 0)
                {
                    if (!b.Transfer(CurrentAccount, receiverID, transferAmount))
                    {
                        Console.Write("Transfer unsuccessful!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Write("Transfer Successful!");
                        Console.ReadKey();
                    }
                }
            }
        }
        static void ReadandClear()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}