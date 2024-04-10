using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Mission
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public int MissionType { get; set; }

        public Mission(string Name, string Description, int Value, int MissionType)
        {
            this.Name = Name;
            this.Description = Description;
            this.Value = Value;
            this.MissionType = MissionType;
        }

        public string ToJSON()
        {
            List<string> list = new() { this.Name, this.Description, this.Value.ToString(), this.MissionType.ToString() };
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        public static Mission FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string Name = list[0];
            string Description = list[1];
            int Value = Convert.ToInt32(list[2]);
            int MissionType = Convert.ToInt32(list[3]);
            Mission Mission = new(Name, Description, Value, MissionType);
            return Mission;
        }
    }
}
