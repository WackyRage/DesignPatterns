using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Classes.Faction
{
    internal abstract class AbstractUnit
    {
        protected string name;
        protected int value;

        public AbstractUnit(string name, int value) 
        {
            this.name = name;
            this.value = value;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

    }
}
