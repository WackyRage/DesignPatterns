using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Infantry : Unit
    {
        public string Name {  get; set; }
        public int Value { get; set; }

        public Infantry(string Name, int Value)
        {
            this.Name = Name;
            this.Value = Value;
        }
    }
}
