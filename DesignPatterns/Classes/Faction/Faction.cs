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
        public List<Unit> Units { get; set; } = new();

        public Faction(string Name)
        {
            this.Name = Name;
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
            string JN = JSONObject.ObjectToJSON(this.Name);
            string JU = JSONObject.ListToJSON(this.Units);

            List<string> list = new() { JN, JU };

            string returnString = JSONObject.ListToJSON(list);
            return returnString;
        }

        public static Faction FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string Name = (string)JSONObject.JSONToObject(list[0]);
            Faction Faction = new(Name);

            List<Unit> Units = JSONObject.JSONToList<Unit>(list[1]);
            foreach (Unit Unit in Units)
            {
                Faction.AddUnit(Unit);
            }
            return Faction;
        }
    }
}
