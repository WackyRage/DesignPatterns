using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Faction
    {
        private string name {  get; set; }
        private List<Unit> units { get; set; }
        private UnitFactory unitFactory = new UnitFactory();

        public Faction(string name)
        {
            this.name = name;
            units = new();
        }

        public Faction(string name, List<Unit> units)
        {
            this.name = name;
            this.units = units;
        }

        public void addUnit(Unit unit)
        {
            this.units.Add(unit);
        }

        public Unit getUnitById(int id)
        {
            return this.units[id];
        }

        public string ToJSON()
        {
            string JU = JSONObject.ListToJSON(this.units);

            List<string> list = new() { this.name, JU };

            string returnString = JSONObject.ListToJSON(list);
            return returnString;
        }

        public static Faction FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string name = list[0];
            List<Unit> units = JSONObject.JSONToList<Unit>(list[1]);
            Faction faction = new(name, units);

            return faction;
        }

        public override string ToString()
        {
            return this.name + ", " + this.units.Count;
        }
    }
}
