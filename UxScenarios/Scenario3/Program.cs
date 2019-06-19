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

            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
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
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }
}
