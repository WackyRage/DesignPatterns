using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class ArmyList
    {
        public string ArmyName { get; set; }
        public string PlayerName { get; set; }
        public List<Unit> Units { get; set; }
        
        public ArmyList(string ArmyName, string PlayerName)
        {
            this.ArmyName = ArmyName;
            this.PlayerName = PlayerName;
            Units = new();
        }

        public ArmyList(string ArmyName, string PlayerName, List<Unit> Units)
        {
            this.ArmyName = ArmyName;
            this.PlayerName = PlayerName;
            this.Units = Units;
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
            string JU = JSONObject.ListToJSON(this.Units);

            List<string> list = new() { this.ArmyName, this.PlayerName, JU };

            string returnString = JSONObject.ListToJSON(list);
            return returnString;
        }

        public static ArmyList FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string ArmyName = list[0];
            string PlayerName = list[1];
            List<Unit> Units = JSONObject.JSONToList<Unit>(list[2]);
            ArmyList ArmyList = new(ArmyName, PlayerName, Units);

            return ArmyList;
        }

        public override string ToString()
        {
            return ArmyName + ", " + PlayerName + ", " + Units.Count;
        }
    }
}
