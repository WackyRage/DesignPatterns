using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers.Provider;

namespace DesignPatterns
{
    internal class Faction
    {
        private string Name;
        private List<Unit> Units;

        public Faction(string N)
        {
            Name = N;
            Units = new List<Unit>();
        }

        public void SetName(string N)
        {
            Name = N;
        }

        public void AddUnit(Unit Unit)
        {
            Units.Add(Unit);
        }

        public string GetName()
        {
            return Name;
        }

        public Unit GetUnitById(int Id)
        {
            return Units[Id];
        }
    }
}
