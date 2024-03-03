using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class ArmyList
    {
        public string ArmyName { get; set; }
        public string PlayerName { get; set; }
        public List<Unit> Units { get; set; } = new();

        public ArmyList(string ArmyName, string PlayerName)
        {
            this.ArmyName = ArmyName;
            this.PlayerName = PlayerName;
        }

        public void AddUnit(Unit Unit)
        {
            Units.Add(Unit);
        }

        public Unit GetUnitById(int Id)
        {
            return Units[Id];
        }

        public string ToJSON()
        {
            string JAN = JSONObject.ObjectToJSON(this.ArmyName);
            string JPN = JSONObject.ObjectToJSON(this.PlayerName);
            string JU = JSONObject.ListToJSON(this.Units);

            List<string> list = new() { JAN, JPN, JU };

            string returnString = JSONObject.ListToJSON(list);
            return returnString;
        }

        public static ArmyList FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string ArmyName = (string)JSONObject.JSONToObject(list[0]);
            string PlayerName = (string)JSONObject.JSONToObject(list[1]);
            ArmyList ArmyList = new(ArmyName, PlayerName);

            List<Unit> Units = JSONObject.JSONToList<Unit>(list[2]);
            foreach (Unit Unit in Units)
            {
                ArmyList.AddUnit(Unit);
            }
            return ArmyList;
        }

        public override string ToString()
        {
            return ArmyName + ", " + PlayerName + ", " + Units.Count;
        }
    }
}
