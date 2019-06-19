using System;
using System.Collections.Generic;

namespace Scenario1
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = GetAccount();

            Console.WriteLine(Serialize(account));
            Console.WriteLine(SerializePrettyPrint(account));
        }

        // TODO: 1) Serialize the "account" object to a JSON string and return it.
        private static string Serialize(Account account)
        {
            // <Add/modify code here>
            return "";
        }

        // TODO: 2) Serialize the "account" object to a "pretty-printed" JSON string and return it.
        private static string SerializePrettyPrint(Account account)
        {
            // <Add/modify code here>
            return "";
        }

        private static Account GetAccount()
        {
            // Note: Do NOT modify the Account object creation.
            Account account = new Account
            {
                Email = "james@example.com",
                Active = true,
                CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string>
                {
                    "User",
                    "Admin"
                }
            };

            return account;
        }
    }

    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }
}
