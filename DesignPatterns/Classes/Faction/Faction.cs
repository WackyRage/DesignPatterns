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
        private List<UnitInterface> units { get; set; }
        private UnitFactory unitFactory = new UnitFactory();

        public Faction(string name)
        {
            this.name = name;
            units = new();
        }

        public Faction(string name, List<UnitInterface> units)
        {
            this.name = name;
            this.units = units;
        }

        public void addUnit(UnitInterface unit)
        {
            this.units.Add(unit);
        }

        public UnitInterface getUnitById(int id)
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
            List<UnitInterface> units = JSONObject.JSONToList<UnitInterface>(list[1]);
            Faction Faction = new(name, units);

            return Faction;
        }

        public override string ToString()
        {
            return this.name + ", " + this.units.Count;
        }
    }
}
