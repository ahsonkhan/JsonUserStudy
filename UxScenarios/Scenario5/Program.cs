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
            string inputFile = "input.json";
            string outputFile = "output.json";
            string jsonString = File.ReadAllText(inputFile);

            using (FileStream fs = File.Create(outputFile))
            {
                ParseAndWriteIndented(jsonString, fs);
            }
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
    }
}
