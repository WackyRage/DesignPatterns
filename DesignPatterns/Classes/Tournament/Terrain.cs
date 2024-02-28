using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Terrain
    {
        public string Name { get; set; }
        public List<string> Rules { get; set; } = new();

        public Terrain(string Name)
        {
            this.Name = Name;
        }

        public void AddRule(string R)
        {
            Rules.Add(R);
        }

        public string GetRuleById(int Id)
        {
            return Rules[Id];
        }
    }
}
