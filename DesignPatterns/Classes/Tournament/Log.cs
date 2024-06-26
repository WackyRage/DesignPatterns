﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Class log, to record events.
    internal class Log
    {
        private string message;
        private DateTime date;
        private bool resolved;

        public Log(string message, DateTime date, bool resolved)
        {
            this.message = message;
            this.date = date;
            this.resolved = resolved;
        }

        // chack booloan to opposite value
        public void changeResolved()
        {
            if (this.resolved)
            {
                this.resolved = false;
            } 
            else
            {
                this.resolved = true;
            }
        }

        // Method to convert Log to JSONString
        public string ToJSON()
        {
            string date = JSONObject.ObjectToJSON(this.date);
            string resolved = JSONObject.ObjectToJSON(this.resolved);
            List<string> list = new() { this.message, date, resolved };

            string jsonString = JSONObject.ListToJSON(list);
            return jsonString; 
        }

        // Method to covert JSONString back to a Log
        public static Log FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string message = list[0];
            DateTime date = (DateTime)JSONObject.JSONToObject(list[1]);
            bool resolved = (bool)JSONObject.JSONToObject(list[2]);
            Log log = new(message, date, resolved);
            return log;
        }
    }
}
