using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;   // 1a) Find and add new namespace

namespace Scenario1
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = GetAccount();

            Console.WriteLine(Serialize(account));
            // 1c) Expected output:
            // {"Email":"james@example.com","Active":true,"CreatedDate":"2013-01-20T00:00:00.0000000Z","Roles":["User","Admin"]}

            // 2c) Expected output:
            // {
            //     "Email": "james@example.com",
            //     "Active": true,
            //     "CreatedDate": "2013-01-20T00:00:00Z",
            //     "Roles": [
            //         "User",
            //         "Admin"
            //     ]
            // }
        }

        // TODO:
        // 1) Serialize the "account" object to a JSON string and return it.
        // 2) Then, modify the code to "pretty-print" the JSON so it is indented.
        private static string Serialize(Account account)
        {
            // 1b) Find the right type and API overload to call, with the correct signature
            // string jsonString = JsonSerializer.ToString<Account>(account);
            // return jsonString;

            // 2a) Find the serializer options and the flag that would let you write indented
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;

            // 2b) Make sure to pass the options to the ToString method
            string jsonString = JsonSerializer.ToString<Account>(account, options);
            return jsonString;
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
