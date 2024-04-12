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
        private string _name;
        private List<AbstractUnit> _units;
        private UnitFactory unitFactory;
        public string name
        {
            get => _name; 
            set => _name = value;
        }
        public List<AbstractUnit> units
        {
            get => _units;
            set => _units = value;
        }
        public Faction(string name)
        {
            this._name = name;
            this.unitFactory = new UnitFactory();
            _units = new();
        }

        public Faction(string name, List<AbstractUnit> units)
        {
            this._name = name;
            this.unitFactory = new UnitFactory();
            this._units = units;
        }

        public void addUnit(AbstractUnit unit)
        {
            this._units.Add(unit);
        }

        public void addUnit(string type, string name, int value)
        {
            AbstractUnit unit = unitFactory.CreateUnit(type, name, value);
            if (unit != null)
            {
                this._units.Add(unit);
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
                return this._units[id];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Invalid unit ID.");
            }
        }

        public int getUnitCount()
        {
            return _units.Count;
        }

        public string ToJSON()
        {
            string JU = JSONObject.ListToJSON(this._units);

            List<string> list = new() { this._name, JU };

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
            return this._name + ", " + this._units.Count;
        }
    }
}
