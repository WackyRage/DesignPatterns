using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Terrain
    {
        public string Name { get; set; }
        public List<string> Rules { get; set; }

        public Terrain(string Name)
        {
            this.Name = Name;
            this.Rules = new();
        }

        public Terrain(string Name, List<string> Rules)
        {
            this.Name = Name;
            this.Rules = Rules;
        }

        public void AddRule(string R)
        {
            Rules.Add(R);
        }

        public string GetRuleById(int Id)
        {
            return Rules[Id];
        }

        public string ToJSON()
        {
            string Rules = JSONObject.ListToJSON(this.Rules);
            List<string> list = new() { Name, Rules };
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        public static Terrain FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string Name = list[0];
            List<string> Rules = JSONObject.JSONToList<string>(list[1]);
            Terrain Terrain = new(Name, Rules);
            return Terrain;
        }

        public override string ToString()
        {
            string returnString = "" + Name;
            foreach (string rule in Rules)
            {
                returnString = returnString + ", " + rule;
            }
            return returnString;
        }
    }
}
