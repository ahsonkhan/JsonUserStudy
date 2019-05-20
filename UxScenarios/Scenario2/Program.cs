﻿using System;
using System.Collections.Generic;

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
        // 1) Deserialize the json string into an "account" object and return it.
        private static Account Deserialize(string jsonString)
        {
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