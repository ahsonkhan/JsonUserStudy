using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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
        // 1) Deserialize the json string from the file into an "account" object and return it.
        // Note: Feel free to open input.json to view its contents, but do NOT modify it.
        private static async Task<Account> Deserialize(Stream fileStream)
        {
            return null;
        }

        // TODO:
        // 2) Serialize the "account" object to a new file, indented, without null values.
        private static async Task Serialize(Account account, Stream fileStream)
        {
        }
    }

    // Note: You CANNOT change the property names themselves, but can add attributes.
    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }
}
