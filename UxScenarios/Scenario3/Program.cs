using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Scenario3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string inputFile = "input.json";
            string outputFile = "output.json";

            Account account;
            using (FileStream fs = File.OpenRead(inputFile))
            {
                account = await Deserialize(fs);
            }
            
            using (FileStream fs = File.Create(outputFile))
            {
                await Serialize(account, fs);
            }
        }

        // TODO:
        // 1) Use JsonSerializer to deserialize the json string from the file, asynchronously, into an "account" object and return it.
        // Note: Feel free to open input.json to view its contents, but do NOT modify it.
        private static async Task<Account> Deserialize(Stream fileStream)
        {
            // <Add/modify code here using System.Text.Json.Serialization.JsonSerializer>
            return null;
        }

        // TODO:
        // 2) Use JsonSerializer to serialize the "account" object to a new file, asynchronously.
        // Note: Use JsonSerializerOptions to write the JSON indented and without null values.
        private static async Task Serialize(Account account, Stream fileStream)
        {
            // <Add code here using System.Text.Json.Serialization.JsonSerializer and JsonSerializerOptions>
        }
    }

    // Note: You CANNOT change the property names on the Account class, but you can add attributes such as JsonPropertyName.
    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }
}
