using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Classes.Faction
{
    // Abstract class, containing basic information for all units
    internal abstract class AbstractUnit
    {
        protected string name;
        protected int value;

        public AbstractUnit(string name, int value) 
        {
            this.name = name;
            this.value = value;
        }

        // Method for getting and setting the name of the unit.
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Method for getting and setting the value of the unit.
        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

    }
}
