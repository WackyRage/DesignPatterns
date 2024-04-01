using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Faction
    {
        private string Name {  get; set; }
        private List<UnitInterface> Units { get; set; }
        private UnitFactory unitFactory = new UnitFactory();

        public Faction(string Name)
        {
            this.Name = Name;
            Units = new();
        }

        public Faction(string Name, List<UnitInterface> Units)
        {
            this.Name = Name;
            this.Units = Units;
        }

        public void AddUnit(UnitInterface Unit)
        {
            Units.Add(Unit);
        }

        public UnitInterface GetUnitById(int Id)
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
            List<UnitInterface> Units = JSONObject.JSONToList<UnitInterface>(list[1]);
            Faction Faction = new(Name, Units);

            return Faction;
        }

        public override string ToString()
        {
            return Name + ", " + Units.Count;
        }
    }
}
