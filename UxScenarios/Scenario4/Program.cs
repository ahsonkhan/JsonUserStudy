using System;
using System.IO;

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
        // 1) Parse the json string (which contains trailing commas) and query it.
        // The goal is to return the class average for all the students, along with the class name. If a student's grade is missing, assume 70.
        // Note: Feel free to open input.json to view its contents, but do NOT modify it.
        // Note: Assume the JSON schema is valid and will not change.
        private static (string, double) AverageGrades(string jsonString)
        {
            string className = "";
            double sum = 0;
            int count = 0;

            double average = sum / count;
            return (className, average);
        }
    }
}
