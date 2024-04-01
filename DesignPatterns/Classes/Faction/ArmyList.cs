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
        private string armyName { get; set; }
        private string playerName { get; set; }
        private List<UnitInterface> units { get; set; }
        
        public ArmyList(string armyName, string playerName)
        {
            this.armyName = armyName;
            this.playerName = playerName;
            this.units = new();
        }

        public ArmyList(string armyName, string playerName, List<UnitInterface> units)
        {
            this.armyName = armyName;
            this.playerName = playerName;
            this.units = units;
        }

        public void addUnit(UnitInterface unit)
        {
            units.Add(unit);
        }

        public UnitInterface getUnitById(int id)
        {
            return units[id];
        }

        public string ToJSON()
        {
            string JU = JSONObject.ListToJSON(this.units);

            List<string> list = new() { this.armyName, this.playerName, JU };

            string returnString = JSONObject.ListToJSON(list);
            return returnString;
        }

        public static ArmyList FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string armyName = list[0];
            string playerName = list[1];
            List<UnitInterface> units = JSONObject.JSONToList<UnitInterface>(list[2]);
            ArmyList armyList = new(armyName, playerName, units);

            return armyList;
        }

        public override string ToString()
        {
            return this.armyName + ", " + this.playerName + ", " + this.units.Count;
        }
    }
}
