using System;
using System.IO;
using System.Text.Json;

namespace Scenario4
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "input.json";
            string jsonString = File.ReadAllText(inputFile);

            (string className, double average) = AverageGrades(jsonString);
            Console.WriteLine(className + " : " + average);
        }

        // TODO:
        // 1) Use the JsonDocument to parse the json string (which contains trailing commas) into a document object model (DOM) and query it.
        // The goal is to return the class average for all the students, along with the class name. If a student's grade is missing, assume 70.
        // Note: Feel free to open input.json to view its contents, but do NOT modify it.
        // Note: Assume the JSON schema is valid and will not change.
        // Note: You can use JsonReaderOptions to allow reading trailing commas.
        private static (string, double) AverageGrades(string jsonString)
        {
            string className = "";
            double sum = 0;
            int count = 0;

            // <Add code here using System.Text.Json.JsonDocument, JsonElement, and JsonReaderOptions>

            double average = sum / count;
            return (className, average);
        }
    }
}
