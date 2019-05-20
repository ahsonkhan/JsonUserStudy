using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json.Serialization;   // 1a) Find and add new namespace

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
            // 2f) Expected output.json file:
            // {
            //     "E-mail": "james@example.com",
            //     "Active": true,
            //     "CreatedDate": "2013-01-20T00:00:00Z"
            // }
        }

        // TODO:
        // 1) Deserialize the json string from the file into an "account" object and return it.
        // Note: Feel free to open input.json to view its contents, but do NOT modify it.
        private static async Task<Account> Deserialize(Stream fileStream)
        {
            // 1b) Find the right type and async API overload to call, with the correct signature
            Account account = await JsonSerializer.ReadAsync<Account>(fileStream);
            return account;
        }

        // TODO:
        // 2) Serialize the "account" object to a new file, indented, without null values.
        private static async Task Serialize(Account account, Stream fileStream)
        {
            // 2a) Find the right type and async API overload to call, with the correct signature
            // await JsonSerializer.WriteAsync<Account>(account, fileStream);

            // 2b) Open output.json and realize the contents are not indented, and there are still null values.
            // 2c) Find the serializer options and the flag that would let you write indented and ignore null values
            var options = new JsonSerializerOptions();
                options.WriteIndented = true;
                options.IgnoreNullValues = true;
            
            await JsonSerializer.WriteAsync<Account>(account, fileStream, options);
        }
    }

    // Note: You CANNOT change the property names themselves, but can add attributes.
    public class Account
    {
        // 2d) Observe that the "Email" property is not being set because the payload contains the property name with a hyphen (i.e. "E-mail")
        // 2e) Find the write attribute to set on the property so that it can match the input json string and serialized correctly.
        [JsonPropertyName("E-mail")]
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }
}
