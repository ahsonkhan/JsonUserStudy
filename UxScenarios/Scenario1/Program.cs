using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Scenario1
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = GetAccount();

            Console.WriteLine(Serialize(account));
        }

        // TODO:
        // 1) Use JsonSerializer to serialize the "account" object to a JSON string and return it.
        // 2) Then, modify the code to "pretty-print" the JSON so it is indented, using JsonSerializerOptions.
        private static string Serialize(Account account)
        {
            // <Add/modify code here using System.Text.Json.Serialization.JsonSerializer and JsonSerializerOptions>
            return "";
        }

        private static Account GetAccount()
        {
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
