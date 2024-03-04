using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Faction
    {
        public string Name {  get; set; }
        public List<Unit> Units { get; set; }

        public Faction(string Name)
        {
            this.Name = Name;
            Units = new();
        }

        public Faction(string Name, List<Unit> Units)
        {
            this.Name = Name;
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

            List<string> list = new() { this.Name, JU };

            string returnString = JSONObject.ListToJSON(list);
            return returnString;
        }

        public static Faction FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string Name = list[0];
            List<Unit> Units = JSONObject.JSONToList<Unit>(list[1]);
            Faction Faction = new(Name, Units);

            return Faction;
        }

        public override string ToString()
        {
            return Name + ", " + Units.Count;
        }
    }
}
