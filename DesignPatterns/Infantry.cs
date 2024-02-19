using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Infantry: Unit
    {
        private String Name;
        private int Value;

        public Infantry(string N, int V)
        {
            Name = N;
            Value = V;
        }

        public void SetName(String N)
        {
            Name = N;
        }

        public void SetValue(int V)
        {
            Value = V;
        }

        public String GetName()
        {
            return Name;
        }

        public int GetValue()
        {
            return Value;
        }
    }
}
