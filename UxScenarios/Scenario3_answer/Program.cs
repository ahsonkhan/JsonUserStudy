using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Scenario3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string inputFile = FindFullPath("input.json");
            string outputFile = FindFullPath("output.json");

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

            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
        }

        // TODO:
        // 1) Deserialize the json string from the file, asynchronously, into an "account" object and return it.
        // Note: Feel free to open input.json to view its contents, but do NOT modify it.
        private static async Task<Account> Deserialize(Stream fileStream)
        {
            // 1a) Find the right async API overload to call, with the correct signature
            Account account = await JsonSerializer.ReadAsync<Account>(fileStream);
            return account;
        }

        // TODO:
        // 2) Asynchronously serialize the entire "account" object we deserialized in (1) to a new file but omit any null values.
        // Note: Write the JSON indented.
        private static async Task Serialize(Account account, Stream fileStream)
        {
            // 2a) Find the right async API overload to call, with the correct signature
            // await JsonSerializer.WriteAsync<Account>(account, fileStream);

            // 2b) Open output.json and realize the contents are not indented, and there are still null values.
            // 2c) Find the serializer options and the flag that would let you write indented and ignore null values.
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                IgnoreNullValues = true
            };

            await JsonSerializer.WriteAsync<Account>(fileStream, account, options);
        }

        private static string FindFullPath(string fileName)
        {
            string dir = Directory.GetCurrentDirectory();

            string fullPath = dir + "\\" + fileName;

            int count = 0;
            while (true)
            {
                if (count > 5)
                {
                    throw new FileNotFoundException($"The file necessary for this scenario could not be found. Looking for {fileName}.");
                }
                if (File.Exists(fullPath))
                {
                    break;
                }
                dir = Path.GetFullPath(Path.Combine(dir, @"..\"));
                if (dir.EndsWith("Scenario3\\"))
                {
                    throw new FileNotFoundException($"The file necessary for this scenario could not be found (stopped searching at project root). Looking for {fileName}.");
                }
                fullPath = dir + "\\" + fileName;
                count++;
            }

            return fullPath;
        }
    }

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
