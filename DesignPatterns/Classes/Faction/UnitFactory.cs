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

        public Unit CreateUnit(string Type, string Name, int Value)
        {
            Type = Type.Replace(" ", "").ToLower();

            switch (Type)
            {
                case "vehicle":
                    return new Vehicle(Name, Value);

                case "infantry":
                    return new Infantry(Name, Value);

                case "beast":
                    return new Beast(Name, Value);

                default:
                    return null;
            }
            
        }
    }
}
