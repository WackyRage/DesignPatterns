using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Faction
    {
        public string Name {  get; set; }
        public List<Unit> Units { get; set; } = new();

        public Faction(string Name)
        {
            this.Name = Name;
        }

        public void AddUnit(Unit Unit)
        {
            Units.Add(Unit);
        }

        public Unit GetUnitById(int Id)
        {
            return Units[Id];
        }
    }
}
