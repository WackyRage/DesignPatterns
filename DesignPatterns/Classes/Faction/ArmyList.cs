using DesignPatterns.Classes.Faction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Class for army list, containing all army selected units.
    internal class ArmyList: Publisher
    {
        private List<Subscriber> subscribers = new();
        private string _armyName;
        private string _playerName;
        private List<AbstractUnit> _units;

        public List<AbstractUnit> units
        {
            get => _units;
            set => _units = value;
        }

        // Constructor for ArmyList without pre-defined army.
        public ArmyList(string armyName, string playerName)
        {
            this._armyName = armyName;
            this._playerName = playerName;
            this._units = new();
        }

        // Constructor for ArmyList with pre-defined army.
        public ArmyList(string armyName, string playerName, List<AbstractUnit> units)
        {
            this._armyName = armyName;
            this._playerName = playerName;
            this._units = units;
        }

        // Method for getting and setting the armyName.
        public string armyName
        {
            get { return _armyName; }
            set { _armyName = value; }
        }

        // Method for getting and setting the playerName.
        public string playerName
        {
            get { return _playerName; }
            set { _playerName = value; }
        }

        public void addUnit(AbstractUnit unit)
        {
            _units.Add(unit);
            this.notifySubscriber();
        }

        public void removeUnit(AbstractUnit unit)
        {
            _units.Remove(unit);
            this.notifySubscriber();
        }

        // Method for retrieving a unit from the army by its index.
        public AbstractUnit getUnitById(int id)
        {
            // Check if unit is in List
            if (id >= 0 && id < _units.Count)
            {
                return _units[id];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Invalid unit ID.");
            }
        }

        // Method for calculating the total value of the army.
        public int getArmyValue()
        {
            int value = 0;

            foreach (AbstractUnit unit in _units)
            {
                if (unit is AbstractUnit abstractUnit)
                {
                    value += unit.Value;
                }
            }
            return value;
        }

        // Method to return total amount of unit in the army.
        public int getArmyCount()
        {
            return _units.Count;
        }

        public void subscribe(Subscriber S)
        {
            this.subscribers.Add(S);
        }

        public void unsubscribe(Subscriber S)
        {
            this.subscribers.Remove(S);
        }

        public void notifySubscriber()
        {
            foreach (Subscriber s in this.subscribers)
            {
                s.update(this.getArmyValue(), this._armyName, this._playerName);
            }
        }

        public string ToJSON()
        {
            string JU = JSONObject.ListToJSON(this._units);

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
            return this.armyName + ", " + this.playerName + ", " + this._units.Count;
        }

        public bool equals(ArmyList other)
        {
            if (this._armyName == other.armyName) {
                if(this._playerName == other.playerName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
