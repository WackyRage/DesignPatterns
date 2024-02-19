using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Faction
{
    internal interface Unit
    {
        void SetName(string Name);
        void SetValue(int Value);
        string GetName();

        int GetValue();

    }
}
