using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Class Mission, containing all information of a mission
    internal class Mission
    {
        private string _name;
        private string _description;
        private int _value;
        private int _missionType;

        public Mission(string name, string description, int value, int missionType)
        {
            this._name = name;
            this._description = description;
            this._value = value;
            this._missionType = missionType;
        }

        // Method for getting and setting the name of the Mission.
        public string name
        {
            get => _name;
            set => _name = value;
        }

        // Method for getting and setting the description of the Mission.
        public string description
        {
            get => _description;
            set => _description = value;
        }

        // Method for getting and setting the value of the Mission.
        public int value
        {
            get => _value;
            set => _value = value;
        }

        // Method for getting and setting the missionType of the mission.
        public int missionType
        {
            get => _missionType;
            private set => _missionType = value;
        }

        // Method to convert Mission to JSONString
        public string ToJSON()
        {
            List<string> list = new() { this._name, this._description, this._value.ToString(), this._missionType.ToString() };
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        // Method to covert JSONString back to a Mission
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
