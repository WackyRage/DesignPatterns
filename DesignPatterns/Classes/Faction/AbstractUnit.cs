using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Classes.Faction
{
    internal abstract class AbstractUnit
    {
        protected string name { get; set; }
        protected int value { get; set; }

        public AbstractUnit(string name, int value) 
        {
            this.name = name;
            this.value = value;
        }
    }
}
