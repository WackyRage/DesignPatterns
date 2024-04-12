using DesignPatterns.Classes.Faction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{    
    // Class representing Beast based on AbstractUnit and Unit
    internal class Beast: AbstractUnit, Unit
    {
        // Constructor for initializing the name and value of the Beast unit.
        public Beast(string name, int value) : base(name, value) {}

        // Method to convert Beast to JSONString
        public string ToJSON()
        {
            return JSONObject.ObjectToJSON(this);
        }

        // Method to covert JSONString back to a Beast
        public override string ToString()
        {
            return "(" + this.name + "," + this.value.ToString() + ")";
        }
    }
}
