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

            double average = AverageGrades(jsonString);
            Console.WriteLine($"Science : {average}");
        }

        // TODO:
        // 1) Create a document object model (DOM) view of the json string and use it to calculate and 
        // return the Science class average of all the students' grades. If a student's grade is missing, assume it is 70.
        // Note: Feel free to open input.json to view its contents, but do NOT modify it.
        // Note: Assume the JSON schema is valid and will not change.
        private static double AverageGrades(string jsonString)
        {
            double sum = 0;
            int count = 0;

            // <Add code here>

            double average = sum / count;
            return average;
        }
    }
}
