using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class UnitFactory
    {
        public UnitFactory() { }

        public Unit CreateUnit(String Type, String Name, int Value)
        {
            Type = Type.Replace(" ", "").ToLower();
            if (Type.Equals("vehicle"))
            {
                return new Vehicle(Name, Value);
            } else if (Type.Equals("infantry"))
            {
                return new Infantry(Name, Value);
            } else if (Type.Equals("beast"))
            {
                return new Beast(Name, Value);
            } else
            {
                return null;
            }
        }
    }
}
