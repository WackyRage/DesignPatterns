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
        private UnitFactory unitFactory;

        public Faction(string N)
        {
            Name = N;
            Units = new List<Unit>();
            this.unitFactory = new UnitFactory();
        }

        public void SetName(string N)
        {
            Name = N;
        }

        public void AddUnit(string type, string name, int value)
        {
            Unit unit = unitFactory.CreateUnit(type, name, value);
            if(unit != null) 
            { 
                this.Units.Add(unit); 
            } else
            {
                throw new Exception(); // needs alternative method
            }
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
