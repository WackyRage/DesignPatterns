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

        public string getName() 
        {
            return this.name;     
        }

        public int getValue()
        {
            return this.value;
        }
        
        public void setValue(int value)
        {
            this.value = value;
        }

        public void setName(string name)
        { 
            this.name = name; 
        }

    }
}
