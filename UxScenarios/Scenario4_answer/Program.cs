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
            // 1f) Expected output:
            // Science : 81.92
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

            // 1a) Find the right API overload to call, with the correct signature and reader options.
            using (JsonDocument document = JsonDocument.Parse(jsonString, new JsonReaderOptions { AllowTrailingCommas = true } ))
            {
                JsonElement root = document.RootElement;

                // 1b) Query the document to find the class name element and call GetString() to retrieve its name.
                JsonElement classElement = root.GetProperty("Class Name");
                className = classElement.GetString();

                // 1c) Query the document to find the list of students and enumerate the list using the EnumerateArray().
                JsonElement studentsElement = root.GetProperty("Students");
                foreach(JsonElement student in studentsElement.EnumerateArray())
                {
                    // 1d) Query each student for their grade, retrieve the value by calling GetDouble(), and keep track of the sum and student count.
                    if (student.TryGetProperty("Grade", out JsonElement gradeElement))
                    {
                        sum += gradeElement.GetDouble();
                    }
                    else
                    {
                        // 1e) Make sure to add 70 if "Grade" is not found (i.e. when TryGetProperty(() returns false)
                        sum += 70;
                    }
                    count++;
                }
            }

            double average = sum / count;
            return (className, average);
        }

        // There are alternative solutions to this problem.
        // Instead of keeping track of count while enumerating the "Students" json array, read the "Student Count" property instead.
        // Another approach would be to use the "GetArrayLength()" method on "studentsElement".
        // The user may also call the Try* variations of the APIs.
        private static (string, double) AverageGrades_Alternative(string jsonString)
        {
            string className = "";
            double sum = 0;
            int count = 0;

            using (JsonDocument document = JsonDocument.Parse(jsonString, new JsonReaderOptions { AllowTrailingCommas = true } ))
            {
                JsonElement root = document.RootElement;
                JsonElement classElement = root.GetProperty("Class Name");
                className = classElement.GetString();

                JsonElement studentCountElement = root.GetProperty("Student Count");
                count = studentCountElement.GetInt32();

                JsonElement studentsElement = root.GetProperty("Students");
                // count = studentsElement.GetArrayLength();

                foreach(JsonElement student in studentsElement.EnumerateArray())
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
            return (className, average);
        }
    }
}
