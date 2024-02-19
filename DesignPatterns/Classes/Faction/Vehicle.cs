using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Faction
{
    internal class Vehicle : Unit
    {
        private string Name;
        private int Value;

        public Vehicle(string N, int V)
        {
            Name = N;
            Value = V;
        }

        public void SetName(string N)
        {
            Name = N;
        }

        public void SetValue(int V)
        {
            Value = V;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetValue()
        {
            return Value;
        }
    }
}
