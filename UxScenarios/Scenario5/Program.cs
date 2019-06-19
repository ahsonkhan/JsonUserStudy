using System;
using System.Buffers;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Scenario5
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = FindFullPath("input.json");
            string outputFile = FindFullPath("output.json");
            string jsonString = File.ReadAllText(inputFile);

            using (FileStream fs = File.Create(outputFile))
            {
                ParseAndWriteIndented(jsonString, fs);
            }

            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
        }

        // TODO:
        // 1) Use the JsonDocument to parse the json string and 
        //    re-write it to the file stream as properly formatted/indented (i.e. pretty printed).
        // Note: Feel free to open input.json to view its contents, but do NOT modify it.
        // Note: Assume the JSON schema is valid and will not change.
        private static void ParseAndWriteIndented(string jsonString, Stream fileStream)
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
                if (dir.EndsWith("Scenario5\\"))
                {
                    throw new FileNotFoundException($"The file necessary for this scenario could not be found (stopped searching at project root). Looking for {fileName}.");
                }
                fullPath = dir + "\\" + fileName;
                count++;
            }

            return fullPath;
        }
    }
}
