using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactionSystem
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Pin { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public decimal Balance { get; set; }

        public User(string username, string password, string pin, string fullName, string phone, decimal balance)
        {
            Username = username;
            Password = password;
            Pin = pin;
            FullName = fullName;
            Phone = phone;
            Balance = balance;
        }
    }
}
