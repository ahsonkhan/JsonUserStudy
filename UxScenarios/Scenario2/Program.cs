using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Scenario2
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = GetJsonString();

            Account account = Deserialize(jsonString);
            Console.WriteLine(account?.Email);
        }

        // TODO:
        // 1) Use JsonSerializer to deserialize the json string into an "account" object and return it.
        // Note: You can use JsonSerializerOptions to allow reading JSON with trailing commas.
        private static Account Deserialize(string jsonString)
        {
            // <Add/modify code here using System.Text.Json.Serialization.JsonSerializer and JsonSerializerOptions>
            return null;
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
