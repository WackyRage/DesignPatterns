using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class ArmyList
    {
        public string ArmyName { get; set; }
        public string PlayerName { get; set; }
        public List<Unit> Units { get; set; } = new();

        public ArmyList(string ArmyName, string PlayerName)
        {
            this.ArmyName = ArmyName;
            this.PlayerName = PlayerName;
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
