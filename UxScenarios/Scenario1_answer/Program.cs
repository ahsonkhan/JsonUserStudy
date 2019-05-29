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
            // 1) Expected output:
            // {"Email":"james@example.com","Active":true,"CreatedDate":"2013-01-20T00:00:00.0000000Z","Roles":["User","Admin"]}

            Console.WriteLine(SerializePrettyPrint(account));
            // 2) Expected output:
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

        // TODO: 1) Use JsonSerializer to serialize the "account" object to a JSON string and return it.
        private static string Serialize(Account account)
        {
            // Find the right API overload to call, with the correct signature
            string jsonString = JsonSerializer.ToString<Account>(account);
            return jsonString;
        }

        // TODO: 2) Use JsonSerializer and JsonSerializerOptions to serialize the "account" object to a "pretty-printed" JSON string and return it.
        private static string SerializePrettyPrint(Account account)
        {
            // Find the serializer options and the flag that would let you write indented
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;

            // Make sure to pass the options to the ToString method
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
