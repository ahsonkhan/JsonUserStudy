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

            string indentedJson = ReadAndWriteIndented(jsonString);
            File.WriteAllText(outputFile, indentedJson);
        }

        // TODO:
        // 1) Read the json string (which contains comments that should be ignored) and re-write it as properly formatted/indented (i.e. pretty printed).
        // Note: Feel free to open input.json to view its contents, but do NOT modify it.
        private static string ReadAndWriteIndented(string jsonString)
        {
            byte[] utf8Json = Encoding.UTF8.GetBytes(jsonString);

            string indentedJson = "";
            return indentedJson;
        }
    }
}
