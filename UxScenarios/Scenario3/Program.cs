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
        // 1) Deserialize the json string from the file, asynchronously, into an "account" object and return it.
        // Note: Feel free to open input.json to view its contents, but do NOT modify it.
        private static async Task<Account> Deserialize(Stream fileStream)
        {
            // <Add/modify code here>
            return null;
        }

        // TODO:
        // 2) Asynchronously serialize the entire "account" object we deserialized in (1) to a new file but omit any null values.
        // Note: Write the JSON indented.
        private static async Task Serialize(Account account, Stream fileStream)
        {
            // <Add code here>
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
