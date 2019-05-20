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
            string inputFile = "input.json";
            string outputFile = "output.json";
            string jsonString = File.ReadAllText(inputFile);

            string indentedJson = ReadAndWriteIndented(jsonString);
            File.WriteAllText(outputFile, indentedJson);
            // 1h) Expected output.json file:
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
            //     "Final": true,
            //     "Student Count": 5
            // }
        }

        // TODO:
        // 1) Read the json string (which contains comments that should be ignored) and re-write it as properly formatted/indented (i.e. pretty printed).
        // Note: Feel free to open input.json to view its contents, but do NOT modify it.
        private static string ReadAndWriteIndented(string jsonString)
        {
            byte[] utf8Json = Encoding.UTF8.GetBytes(jsonString);

            // 1a) Find the right reader API overload to call, with the correct signature and reader options
            var state = new JsonReaderState(options: new JsonReaderOptions { CommentHandling = JsonCommentHandling.Skip });
            var reader = new Utf8JsonReader(utf8Json, isFinalBlock: true, state);

            // 1b) Find the right writer API overload to call, with the correct signature and writer options
            var output = new ArrayBufferWriter<byte>();
            var options = new JsonWriterOptions { Indented = true };

            using (var writer = new Utf8JsonWriter(output, options))
            {
                string property = null;

                // 1c) Create a reader loop to read through each JSON token
                while (reader.Read())
                {
                    // 1d) Create a switch over the JsonTokenType
                    switch (reader.TokenType)
                    {
                        // 1e) Call the right reader APIs to get strings, doubles, booleans, etc.
                        // 1e) Call the right reader APIs to write the different JSON tokens.
                        case JsonTokenType.PropertyName:
                            property = reader.GetString();
                            break;
                        case JsonTokenType.EndArray:
                            Debug.Assert(property == null);
                            writer.WriteEndArray();
                            break;
                        case JsonTokenType.EndObject:
                            Debug.Assert(property == null);
                            writer.WriteEndObject();
                            break;
                        case JsonTokenType.StartArray:
                            // 1f) Make sure to store the property name to be able to call the right API when the loop reaches the "value" tokens
                            if (property == null)
                            {
                                writer.WriteStartArray();
                            }
                            else
                            {
                                writer.WriteStartArray(property);
                                property = null;
                            }
                            break;
                        case JsonTokenType.StartObject:
                            if (property == null)
                            {
                                writer.WriteStartObject();
                            }
                            else
                            {
                                writer.WriteStartObject(property);
                                property = null;
                            }
                            break;
                        case JsonTokenType.Number:
                            double doubleValue = reader.GetDouble();
                            if (property == null)
                            {
                                writer.WriteNumberValue(doubleValue);
                            }
                            else
                            {
                                writer.WriteNumber(property, doubleValue);
                                property = null;
                            }
                            break;
                        case JsonTokenType.String:
                            string stringValue = reader.GetString();
                            if (property == null)
                            {
                                writer.WriteStringValue(stringValue);
                            }
                            else
                            {
                                writer.WriteString(property, stringValue);
                                property = null;
                            }
                            break;
                        case JsonTokenType.True:
                            if (property == null)
                            {
                                writer.WriteBooleanValue(true);
                            }
                            else
                            {
                                writer.WriteBoolean(property, true);
                                property = null;
                            }     
                            break;
                        case JsonTokenType.False:
                            if (property == null)
                            {
                                writer.WriteBooleanValue(false);
                            }
                            else
                            {
                                writer.WriteBoolean(property, false);
                                property = null;
                            }
                            break;
                        case JsonTokenType.Null:
                            if (property == null)
                            {
                                writer.WriteNullValue();
                            }
                            else
                            {
                                writer.WriteNull(property);
                                property = null;
                            }
                            break;
                    }
                }
            }

            // 1g) Dispose (and/or flush) the writer, get the written UTF-8 data, and transcode to UTF-16 string
            string indentedJson = Encoding.UTF8.GetString(output.WrittenMemory.Span);
            return indentedJson;
        }
    }
}
