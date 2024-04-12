using DesignPatterns.Classes.Faction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Class representing Vehicle based on AbstractUnit and Unit
    internal class Vehicle : AbstractUnit, Unit
    {
        // Constructor for initializing the name and value of the Vehicle unit.
        public Vehicle(string name, int value) : base(name, value) {}

        // Method to convert Vehicle to JSONString
        public string ToJSON()
        {
            return JSONObject.ObjectToJSON(this);
        }

        // Method to covert JSONString back to a Vehicle
        public override string ToString()
        {
            return "(" + this.name + "," + this.value.ToString() + ")";
        }
    }
}
