using DesignPatterns.Classes.Faction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Faction
    {
        private string name;
        private List<AbstractUnit> units;
        private UnitFactory unitFactory;

        public Faction(string name)
        {
            this.name = name;
            this.unitFactory = new UnitFactory();
            units = new();
        }

        public Faction(string name, List<AbstractUnit> units)
        {
            this.name = name;
            this.unitFactory = new UnitFactory();
            this.units = units;
        }

        public void addUnit(AbstractUnit unit)
        {
            this.units.Add(unit);
        }

        public void addUnit(string type, string name, int value)
        {
            AbstractUnit unit = unitFactory.CreateUnit(type, name, value);
            if (unit != null)
            {
                this.units.Add(unit);
            }
            else
            {
                throw new ArgumentException($"Failed to add unit with type '{type}'.");
            }
        }

        public AbstractUnit getUnitById(int id)
        {
            if (id >= 0 && id < getUnitCount())
            {
                return this.units[id];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Invalid unit ID.");
            }
        }

        public int getUnitCount()
        {
            return units.Count;
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
            List<AbstractUnit> units = JSONObject.JSONToList<AbstractUnit>(list[1]);
            Faction Faction = new(name, units);

            return Faction;
        }

        public override string ToString()
        {
            return this.name + ", " + this.units.Count;
        }
    }
}
