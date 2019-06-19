using System;
using System.IO;
using System.Text.Json;

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
            // 1e) Expected output:
            // Science : 81.92

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

            // 1a) Find the right API overload to call, with the correct signature (no reader options are required).
            using (JsonDocument document = JsonDocument.Parse(jsonString))
            {
                JsonElement root = document.RootElement;

                // 1b) Query the document to find the list of students and enumerate the list using the EnumerateArray().
                JsonElement studentsElement = root.GetProperty("Students");
                foreach (JsonElement student in studentsElement.EnumerateArray())
                {
                    // 1c) Query each student for their grade, retrieve the value by calling GetDouble(), and keep track of the sum and student count.
                    if (student.TryGetProperty("Grade", out JsonElement gradeElement))
                    {
                        sum += gradeElement.GetDouble();
                    }
                    else
                    {
                        // 1d) Make sure to add 70 if "Grade" is not found (i.e. when TryGetProperty(() returns false)
                        sum += 70;
                    }
                    count++;
                }
            }

            double average = sum / count;
            return average;
        }

        // There are alternative solutions to this problem.
        // Instead of keeping track of count while enumerating the "Students" json array, use the "GetArrayLength()" method on "studentsElement".
        // The user may also call the Try* variations of the APIs.
        private static double AverageGrades_Alternative(string jsonString)
        {
            double sum = 0;
            int count = 0;

            using (JsonDocument document = JsonDocument.Parse(jsonString))
            {
                JsonElement root = document.RootElement;

                JsonElement studentsElement = root.GetProperty("Students");
                count = studentsElement.GetArrayLength();

                foreach (JsonElement student in studentsElement.EnumerateArray())
                {
                    if (student.TryGetProperty("Grade", out JsonElement gradeElement))
                    {
                        sum += gradeElement.GetDouble();
                    }
                    else
                    {
                        sum += 70;
                    }
                }
            }

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
