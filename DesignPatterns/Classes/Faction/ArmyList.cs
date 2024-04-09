using DesignPatterns.Classes.Faction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class ArmyList
    {
        private string _armyName;
        private string _playerName;
        private List<AbstractUnit> units { get; set; }

        public ArmyList(string armyName, string playerName)
        {
            this._armyName = armyName;
            this._playerName = playerName;
            this.units = new();
        }

        public ArmyList(string armyName, string playerName, List<AbstractUnit> units)
        {
            this._armyName = armyName;
            this._playerName = playerName;
            this.units = units;
        }

        public string armyName
        {
            get { return _armyName; }
            set { _armyName = value; }
        }

        public string playerName
        {
            get { return _playerName; }
            set { _playerName = value; }
        }

        public void addUnit(AbstractUnit unit)
        {
            units.Add(unit);
        }

        public AbstractUnit getUnitById(int id)
        {
            if (id >= 0 && id < units.Count)
            {
                return units[id];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Invalid unit ID.");
            }
        }

        public int getArmyValue()
        {
            int value = 0;

            foreach (AbstractUnit unit in units)
            {
                if (unit is AbstractUnit abstractUnit)
                {
                    value += unit.getValue();
                }
            }
            return value;
        }

        public int getArmyCount()
        {
            return units.Count;
        }

        public string ToJSON()
        {
            string JU = JSONObject.ListToJSON(this.units);

            List<string> list = new() { this.armyName, this.playerName, JU };

            string returnString = JSONObject.ListToJSON(list);
            return returnString;
        }

        public static ArmyList FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string armyName = list[0];
            string playerName = list[1];
            List<AbstractUnit> units = JSONObject.JSONToList<AbstractUnit>(list[2]);
            ArmyList armyList = new(armyName, playerName, units);

            return armyList;
        }

        public override string ToString()
        {
            return this.armyName + ", " + this.playerName + ", " + this.units.Count;
        }
    }
}
