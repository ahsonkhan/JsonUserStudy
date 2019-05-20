using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;   // 1a) Find and add new namespace

namespace Scenario2
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = GetJsonString();

            Account account = Deserialize(jsonString);
            Console.WriteLine(account?.Email);
            // 1d) Expected output:
            // james@example.com
        }

        // TODO:
        // 1) Deserialize the json string into an "account" object and return it.
        private static Account Deserialize(string jsonString)
        {
            // 1b) Find the right type and API overload to call, with the correct signature
            //return JsonSerializer.Parse<Account>(jsonString);
            
            // 1c) Observe the exception and find the serializer options to allow trailing commas
            var options = new JsonSerializerOptions();
            options.AllowTrailingCommas = true;
            return JsonSerializer.Parse<Account>(jsonString, options);
        }

        private static string GetJsonString()
        {
            // Note: There is a trailing comma in this JSON which is technically invalid.
            // Do NOT modify the JSON string.
            string json = @"{
                ""Email"": ""james@example.com"",
                ""Active"": true,
                ""CreatedDate"": ""2013-01-20T00:00:00Z"",
                ""Roles"": [
                    ""User"",
                    ""Admin"",
                ]
            }";

            return json;
        }
    }

    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }
}
