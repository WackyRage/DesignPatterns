using DesignPatterns.Classes.Faction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Infantry : AbstractUnit, UnitInterface
    {
        public Infantry(string Name, int Value) : base(string name, int value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        public string ToJSON()
        {
            return JSONObject.ObjectToJSON(this);
        }

        public override string ToString()
        {
            return "(" + Name + "," + Value.ToString() + ")";
        }
    }
}
