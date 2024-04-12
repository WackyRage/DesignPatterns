using DesignPatterns.Classes.Faction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Class UnitFactory, for creating all unit types
    internal class UnitFactory
    {
        public UnitFactory() { }

        // Method to create a unit based on type, name, and value 
        public AbstractUnit CreateUnit(string type, string name, int value)
        {
            // Normalize the type string for comparison
            type = type.Replace(" ", "").ToLower();

            // Switch to select appropriate type of unit
            switch (type)
            {
                case "vehicle":
                    return new Vehicle(name, value);

                case "infantry":
                    return new Infantry(name, value);

                case "beast":
                    return new Beast(name, value);

                default:
                    // Throw an exception for unknown unit types
                    throw new ArgumentException($"Unknown unit type '{type}'.");
            }
        }
    }
}
