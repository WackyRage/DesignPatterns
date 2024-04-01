using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Classes.Faction
{
    internal abstract class AbstractUnit
    {
        protected string Name { get; set; }
        protected int Value { get; set; }

        public AbstractUnit(string name, int value) 
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
