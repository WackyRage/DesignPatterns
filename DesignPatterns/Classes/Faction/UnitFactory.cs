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

        public Unit CreateUnit(string type, string name, int value)
        {
            type = type.Replace(" ", "").ToLower();
            switch (type)
            {
                case "vehicle":
                    return new Vehicle(name, value);

                case "infantry":
                    return new Infantry(name, value);

                case "beast":
                    return new Beast(name, value);

                default:
                    return null;
            }
        }
    }
}
