﻿using DesignPatterns.Classes.Faction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Infantry : AbstractUnit, Unit
    {
        public Infantry(string name, int value) : base(name, value) {}

        public string ToJSON()
        {
            return JSONObject.ObjectToJSON(this);
        }

        public override string ToString()
        {
            return "(" + this.name + "," + this.value.ToString() + ")";
        }
    }
}
