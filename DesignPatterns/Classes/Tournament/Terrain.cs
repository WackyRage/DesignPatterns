using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Terrain
    {
        private string Name;
        private List<string> Rules;

        public Terrain(string N)
        {
            Name = N;
            Rules = new List<string>();
        }

        public void SetName(string N)
        {
            Name = N;
        }

        public void AddRule(string R)
        {
            Rules.Add(R);
        }

        public string GetName()
        {
            return Name;
        }

        public string GetRuleById(int Id)
        {
            return Rules[Id];
        }
    }
}
