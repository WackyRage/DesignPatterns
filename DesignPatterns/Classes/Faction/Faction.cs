using DesignPatterns.Classes.Faction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Class for Faction, containing all unit concepts.
    internal class Faction
    {
        private string _name;
        private List<AbstractUnit> _units;
        private UnitFactory unitFactory;

        // Constructor for Faction without pre-defined army.
        public Faction(string name)
        {
            this._name = name;
            this.unitFactory = new UnitFactory();
            _units = new();
        }

        // Constructor for Faction with pre-defined army.
        public Faction(string name, List<AbstractUnit> units)
        {
            this._name = name;
            this.unitFactory = new UnitFactory();
            this._units = units;
        }

        // Method for getting and setting the faction name.
        public string name
        {
            get => _name;
            set => _name = value;
        }

        // Method for getting and setting the units list.
        public List<AbstractUnit> units
        {
            get => _units;
            set => _units = value;
        }

        // Method for adding pre-defined unit
        public void addUnit(AbstractUnit unit)
        {
            this._units.Add(unit);
        }

        // Method to create unit based on unput
        public void addUnit(string type, string name, int value)
        {
            // Create unit
            AbstractUnit unit = unitFactory.CreateUnit(type, name, value);
            // Check if unit is created, if true: add unit to list
            if (unit != null)
            {
                this._units.Add(unit);
            }
            else
            {
                throw new ArgumentException($"Failed to add unit with type '{type}'.");
            }
        }

        // Method for retrieving a unit from the Faction by its index.
        public AbstractUnit getUnitById(int id)
        {
            // Check if unit is in List
            if (id >= 0 && id < getUnitCount())
            {
                return this._units[id];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Invalid unit ID.");
            }
        }

        // Method to return total amount of unit in the Faction.
        public int getUnitCount()
        {
            return _units.Count;
        }

        // Method to convert Faction to JSONString
        public string ToJSON()
        {
            string JU = JSONObject.ListToJSON(this._units);

            List<string> list = new() { this._name, JU };

            string returnString = JSONObject.ListToJSON(list);
            return returnString;
        }


        // Method to covert JSONString back to a Faction
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
