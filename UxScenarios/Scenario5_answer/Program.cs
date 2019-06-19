using System;
using System.Buffers;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;

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
            // 1g) Expected output.json file:
            // {
            //     "Class Name": "Science",
            //     "Teacher\u0027s Name": "Jane",
            //     "Semester": "2019-01-01",
            //     "Students": [
            //         {
            //             "Name": "John",
            //             "Grade": 94.3
            //         },
            //         {
            //             "Name": "James",
            //             "Grade": 81
            //         },
            //         {
            //             "Name": "Julia",
            //             "Grade": 91.9
            //         },
            //         {
            //             "Name": "Jessica",
            //             "Grade": 72.4
            //         },
            //         {
            //             "Name": "Johnathan"
            //         }
            //     ],
            //     "Final": true
            // }

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
            // 1a) Find the right Utf8JsonWriter API overload to call, with the correct signature and writer options.
            // 1b) Find the right JsonDocument API overload to call, with the correct signature and reader options.
            using (var writer = new Utf8JsonWriter(fileStream, options: new JsonWriterOptions { Indented = true }))
            using (JsonDocument document = JsonDocument.Parse(jsonString, new JsonReaderOptions { CommentHandling = JsonCommentHandling.Skip }))
            {
                // 1c) Get the root element and check that the Type matches JsonValueType. Otherwise, throwing or returning is fine.
                JsonElement root = document.RootElement;

                // 1d) Write the start object token and make sure to write the end object token once done.
                if (root.Type == JsonValueType.Object)
                {
                    writer.WriteStartObject();
                }
                else
                {
                    return;
                }

                // 1e) Use the JsonElement.EnumerateObject to enumerate through all the property-value pairs and
                // call the JsonElement API that takes the Utf8JsonWriter
                foreach (JsonProperty property in root.EnumerateObject())
                {
                    string propertyName = property.Name;
                    JsonElement value = property.Value;
                    value.WriteProperty(propertyName, writer);
                }

                writer.WriteEndObject();

                // 1f) Optionally flush the writer, or let the writer.Dispose() auto-flush
                writer.Flush();
            }
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
