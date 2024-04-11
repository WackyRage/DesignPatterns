using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Terrain
    {
        private string name { get; set; }
        private List<string> rules { get; set; }

        public Terrain(string name)
        {
            this.name = name;
            this.rules = new();
        }

        public Terrain(string name, List<string> rules)
        {
            this.name = name;
            this.rules = rules;
        }

        public void addRule(string r)
        {
            rules.Add(r);
        }

        public string getRuleById(int id)
        {
            return rules[id];
        }

        public string ToJSON()
        {
            string rules = JSONObject.ListToJSON(this.rules);
            List<string> list = new() { this.name, rules };
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

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
