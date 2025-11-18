using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyTransactionSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // initial data
            List<User> users = new List<User>()
            {
                new User("abdullah01", "abdullah11", "1111", "Abdullah ElDawy", "01011073637", 30000),
                new User("nourah02", "nourhan22", "2222", "Nourhan Ahmed", "01033334444", 20000),
                new User("marwan03", "marwan33", "3333", "Marwan Mohamed", "01055556666", 10000),
                new User("anas04", "anas44", "4444", "Anas Mohamed", "01077778888", 2000),
                new User("dawy05", "dawy55", "5555", "ElDawy", "01099990000", 8000),
                new User("nada06", "nada66", "6666", "Nada Fathy", "01012345678", 4500),
                new User("khaled07", "khaled77", "7777", "Khaled Sami", "01087654321", 6000),
                new User("fatma08", "fatma88", "8888", "Fatma Adel", "01011223344", 3500),
                new User("youssef09", "youssef99", "9999", "Youssef Samir", "01022334455", 9000),
                new User("dina10", "dina1010", "1010", "Dina Mohamed", "01033445566", 2500),
                new User("mohamed11", "mohamed11", "1111", "Mohamed Nabil", "01044556677", 7000),
                new User("ramadan13", "ramadan13", "1313", "Ramadan ElDawy", "01055667788", 4000)
            };

            List<Transaction> transactions = new List<Transaction>();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n==== Money Transaction System ====");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SignUp(users);
                        break;
                    case "2":
                        Login(users, transactions);
                        break;
                    case "3":
                        running = false;
                        Console.WriteLine("Exiting... Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
        static void SignUp(List<User> usersList)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            if (usersList.Any(u => u.Username == username))
            {
                Console.WriteLine("Welcome back!");
                return;
            }
            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();
            Console.Write("Enter phone: ");
            string phone = Console.ReadLine();
            Console.Write("Set a password: ");
            string password = Console.ReadLine();
            Console.Write("Set a 4-digit PIN: ");
            string pin = Console.ReadLine();

            usersList.Add(new User(username, password, pin, fullName, phone, 0));
            Console.WriteLine("Account created successfully!");
        }
        static void Login(List<User> usersList, List<Transaction> transactionsList)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            var user = usersList.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            if (user.Password != password)
            {
                Console.WriteLine("Incorrect password!");
                return;
            }
            Console.WriteLine($"Welcome, {user.FullName}!");
            UserMenu(user, usersList, transactionsList);
        }
        static void UserMenu(User user, List<User> usersList, List<Transaction> transactionsList)
        {
            bool logout = false;
            while (!logout)
            {
                Console.WriteLine($"\n--- {user.Username}'s Menu ---");
                Console.WriteLine("1. View Balance");
                Console.WriteLine("2. Send Money");
                Console.WriteLine("3. Deposit Money");
                Console.WriteLine("4. Withdraw Money");
                Console.WriteLine("5. Transaction Summary");
                Console.WriteLine("6. Update Profile");
                Console.WriteLine("7. Logout");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": ViewBalance(user); break;
                    case "2": SendMoney(user, usersList, transactionsList); break;
                    case "3": Deposit(user); break;
                    case "4": Withdraw(user); break;
                    case "5": TransactionSummary(user, transactionsList); break;
                    case "6": UpdateProfile(user); break;
                    case "7": logout = true; break;
                    default: Console.WriteLine("Invalid choice!"); break;
                }
            }
        }
        static void ViewBalance(User user)
        {
            Console.Write("Enter PIN to confirm: ");
            string pin = Console.ReadLine();
            if (pin != user.Pin) { Console.WriteLine("Incorrect PIN!"); return; }
            Console.WriteLine($"Your balance is: {user.Balance} EGP");
        }
        static void SendMoney(User sender, List<User> usersList, List<Transaction> transactionsList)
        {
            Console.Write("Enter receiver username: ");
            string receiverName = Console.ReadLine();
            var receiver = usersList.FirstOrDefault(u => u.Username == receiverName);
            if (receiver == null) { Console.WriteLine("Receiver not found!"); return; }

            Console.Write("Enter amount to send: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid amount!");
                return;
            }
            if (amount <= 0 || amount > sender.Balance)
            {
                Console.WriteLine("Insufficient balance!");
                return;
            }

            Console.Write("Enter your PIN to confirm: ");
            string pin = Console.ReadLine();
            if (pin != sender.Pin) { Console.WriteLine("Incorrect PIN!"); return; }

            sender.Balance -= amount;
            receiver.Balance += amount;
            transactionsList.Add(new Transaction(sender.Username, receiver.Username, amount));
            Console.WriteLine($"Sent {amount} EGP to {receiver.Username} successfully!");
        }
        static void Deposit(User user)
        {
            Console.Write("Enter amount to deposit: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount!");
                return;
            }

            Console.Write("Enter PIN to confirm: ");
            string pin = Console.ReadLine();
            if (pin != user.Pin) { Console.WriteLine("Incorrect PIN!"); return; }

            user.Balance += amount;
            Console.WriteLine($"Successfully deposited {amount} EGP. New balance: {user.Balance} EGP");
        }
        static void Withdraw(User user)
        {
            Console.Write("Enter amount to withdraw: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount!");
                return;
            }
            if (amount > user.Balance)
            {
                Console.WriteLine("Insufficient balance!");
                return;
            }

            Console.Write("Enter PIN to confirm: ");
            string pin = Console.ReadLine();
            if (pin != user.Pin) { Console.WriteLine("Incorrect PIN!"); return; }

            user.Balance -= amount;
            Console.WriteLine($"Successfully withdrew {amount} EGP. New balance: {user.Balance} EGP");
        }
        static void TransactionSummary(User user, List<Transaction> transactionsList)
        {
            Console.Write("Enter PIN to confirm: ");
            string pin = Console.ReadLine();
            if (pin != user.Pin) { Console.WriteLine("Incorrect PIN!"); return; }

            var sent = transactionsList.Where(t => t.Sender == user.Username).ToList();
            var received = transactionsList.Where(t => t.Receiver == user.Username).ToList();

            Console.WriteLine("\n--- Transactions Sent ---");
            foreach (var t in sent) Console.WriteLine($"{t.Amount} EGP -> {t.Receiver}");
            Console.WriteLine("Total Sent: " + sent.Sum(t => t.Amount));

            Console.WriteLine("\n--- Transactions Received ---");
            foreach (var t in received) Console.WriteLine($"{t.Amount} EGP <- {t.Sender}");
            Console.WriteLine("Total Received: " + received.Sum(t => t.Amount));
        }
        static void UpdateProfile(User user)
        {
            Console.Write("Enter new full name (leave empty to keep): ");
            string fullName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(fullName)) user.FullName = fullName;

            Console.Write("Enter new phone (leave empty to keep): ");
            string phone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(phone)) user.Phone = phone;

            Console.WriteLine("Profile updated successfully!");
        }
    }
}