using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Class Terrain, containing rule information of terrain
    internal class Terrain
    {
        private string name;
        private List<string> rules;

        // Constructor for Terrain without pre-defined rules.
        public Terrain(string name)
        {
            this.name = name;
            this.rules = new();
        }

        // Constructor for Terrain with pre-defined rules.
        public Terrain(string name, List<string> rules)
        {
            this.name = name;
            this.rules = rules;
        }

        // Method to add new rule
        public void addRule(string r)
        {
            // Check if the new rule already exists in the list of rules
            foreach (string rule in rules)
            {
                if (rule == r)
                {
                    // If the rule already exists, throw an exception or handle it as desired
                    throw new ArgumentException($"Rule '{r}' already exists.");
                }
            }

            // If the rule does not exist, add it to the list of rules
            rules.Add(r);
        }

        // Method to getRule by index
        public string getRuleById(int id)
        {
            return rules[id];
        }

        // Method to convert Terrain to JSONString
        public string ToJSON()
        {
            string rules = JSONObject.ListToJSON(this.rules);
            List<string> list = new() { this.name, rules };
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        // Method to covert JSONString back to a Terrain
        public static Terrain FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string name = list[0];
            List<string> rules = JSONObject.JSONToList<string>(list[1]);
            Terrain terrain = new(name, rules);
            return terrain;
        }

        public override string ToString()
        {
            string returnString = "" + name;
            foreach (string rule in rules)
            {
                returnString = returnString + ", " + rule;
            }
            return returnString;
        }
    }
}
