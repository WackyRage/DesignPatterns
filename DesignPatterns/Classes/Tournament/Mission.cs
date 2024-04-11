using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Mission
    {
        private string name;
        private string description;
        private int value;
        private int _missionType;
        public int missionType
        {
            get => _missionType;
            private set => _missionType = value;
        }

        public Mission(string name, string description, int value, int missionType)
        {
            this.name = name;
            this.description = description;
            this.value = value;
            this.missionType = missionType;
        }

        public string ToJSON()
        {
            List<string> list = new() { this.name, this.description, this.value.ToString(), this.missionType.ToString() };
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        public static Mission FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string name = list[0];
            string description = list[1];
            int value = Convert.ToInt32(list[2]);
            int missionType = Convert.ToInt32(list[3]);
            Mission mission = new(name, description, value, missionType);
            return mission;
        }
    }
}
