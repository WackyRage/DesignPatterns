using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Mission
    {
        private string name {  get; set; }
        private string description { get; set; }
        private int value { get; set; }

        public Mission(string name, string description, int value)
        {
            this.name = name;
            this.description = description;
            this.value = value;
        }

        public string ToJSON()
        {
            List<string> list = new() { this.name, this.description, this.value.ToString() };
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        public static Mission FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string name = list[0];
            string description = list[1];
            int value = Convert.ToInt32(list[2]);
            Mission mission = new(name, description, value);
            return mission;
        }
    }
}
