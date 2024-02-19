using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class ArmyList
    {
        private string ArmyName;
        private string PlayerName;
        private List<Unit> Units;

        public ArmyList(string A, string P)
        {
            ArmyName = A;
            PlayerName = P;
            Units = new List<Unit>();
        }

        public void SetArmyName(string A)
        {
            ArmyName = A;
        }

        public void SetPlayerName(string P)
        {
            PlayerName = P;
        }

        public void AddUnit(Unit Unit)
        {
            Units.Add(Unit);
        }

        public string GetArmyName()
        {
            return ArmyName;
        }

        public string GetPlayerName()
        {
            return PlayerName;
        }

        public Unit GetUnitById(int Id)
        {
            return Units[Id];
        }
    }
}
