using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Mission
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public int Value { get; set; }

        public Mission(string Name, string Description, int Value)
        {
            this.Name = Name;
            this.Description = Description;
            this.Value = Value;
        }
    }
}
