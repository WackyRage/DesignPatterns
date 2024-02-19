using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Mission
    {
        private string Name;
        private string Description;
        private int Value;

        public Mission(string N, string D, int V)
        {
            Name = N;
            Description = D;
            Value = V;
        }

        public void SetName(string N)
        {
            Name = N;
        }

        public void SetDescription(string D)
        {
            Description = D;
        }

        public void SetValue(int V)
        {
            Value = V;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetDescription()
        {
            return Description;
        }

        public int GetValue()
        {
            return Value;
        }
    }
}
