using DesignPatterns.Classes.Faction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Class representing Infantry based on AbstractUnit and Unit
    internal class Infantry : AbstractUnit, Unit
    {
        // Constructor for initializing the name and value of the Infantry unit.
        public Infantry(string name, int value) : base(name, value) {}

        // Method to convert Infanty to JSONString
        public string ToJSON()
        {
            return JSONObject.ObjectToJSON(this);
        }

        // Method to covert JSONString back to a Infantry
        public override string ToString()
        {
            return "(" + this.name + "," + this.value.ToString() + ")";
        }
    }
}
