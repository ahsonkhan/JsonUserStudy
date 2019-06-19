using System;
using System.IO;

namespace Scenario4
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = FindFullPath("input.json");
            string jsonString = File.ReadAllText(inputFile);

            double average = AverageGrades(jsonString);
            Console.WriteLine($"Science : {average}");

            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
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
                if (dir.EndsWith("Scenario4\\"))
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
