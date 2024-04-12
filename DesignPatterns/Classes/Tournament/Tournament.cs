using DesignPatterns.Classes.Faction;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Tournament
    {
        private string _name;
        private Map _map;
        private GameType _gameType;
        private int _armyLimit;
        private List<Mission> _missions;
        private List<Log> _logs;
        private List<ArmyList> _armies;
        public string name
        {
            get => _name;
            set => _name = value;
        }
        public Map map
        {
            get => _map;
            set => _map = value;
        }
        public GameType gameType
        {
            get => _gameType;
            set => _gameType = value;
        }
        public int armyLimit
        {
            get => _armyLimit;
            set => _armyLimit = value;
        }
        public List<Mission> missions
        {
            get => _missions; 
            set => _missions = value;
        }
        public List<Log> logs
        {
            get => _logs;
            set => _logs = value;
        }
        public List<ArmyList> armies
        {
            get => _armies;
            set => _armies = value;
        }

        public Tournament(string name, Map map, GameType gameType, int armyLimit)
        {
            this._name = name;
            this._map = map;
            this._gameType = gameType;
            this._armyLimit = armyLimit;
            this._missions = new();
            this._logs = new();
            this._armies = new();
        }

        public Tournament(string name, Map map, GameType gameType, int armyLimit, List<Mission> missions, List<Log> logs, List<ArmyList> armies)
        {
            this._name = name;
            this._map = map;
            this._gameType = gameType;
            this._armyLimit = armyLimit;
            this._missions = missions;
            this._logs = logs;
            this._armies = armies;
        }

        public void addMission(Mission m)
        {
            this._missions.Add(m);
        }

        public void addLog(Log l)
        {
            this._logs.Add(l);
        }

        public void addArmy(ArmyList a)
        {
            if (a.getArmyValue() <= this.armyLimit)
            {
                this._armies.Add(a);
            }
            else
            {
                throw new InvalidOperationException("Adding the army exceeds the tournament's army limit.");
            }
        }
        public void addNewArmy(String armyName, String playerName)
        {
            try
            {
                this._armies.Add(new ArmyList(armyName, playerName));
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"An error occurred while adding a new army: {e.Message}");

            }
        }

        public void addUnitToArmy(string playerName, string armyName, AbstractUnit unit)
        {
            foreach (var army in this._armies)
            {
                if (army.armyName == armyName && army.playerName == playerName)
                {
                    int toBeValue = army.getArmyValue() + unit.Value;
                    if (toBeValue <= this.armyLimit)
                    {
                        army.addUnit(unit);
                        return;
                    }
                    else
                    {
                        throw new InvalidOperationException("Adding the unit exceeds the tournament's army limit.");
                    }
                }
            }

            throw new ArgumentException("Army not found for the specified player and army name.");
        }

        public Mission getMissionById(int id)
        {
            return this._missions[id];
        }

        public Log getLogById(int id)
        {
            return this._logs[id];
        }

        public ArmyList getArmyById(int id)
        {
            return this._armies[id];
        }

        public ArmyList getArmyByPlayer(string player)
        {
            foreach (var army in this._armies)
            {
                if (army.playerName == player)
                {
                    return army;
                }
            }

            throw new Exception("Army not found for the specified player.");
        }

        public ArmyList getArmyByName(string name)
        {
            foreach (var army in this._armies)
            {
                if (army.armyName == name)
                {
                    return army;
                }
            }

            throw new Exception("Army not found for the specified name.");
        }

        public string ToJSON()
        {
            List<string> missions = new();
            foreach (Mission mission in this._missions)
            {
                missions.Add(mission.ToJSON());
            }
            List<string> logs = new();
            foreach (Log log in this._logs)
            {
                logs.Add(log.ToJSON());
            }
            List<string> armies = new();
            foreach(ArmyList army in this._armies)
            {
                armies.Add(army.ToJSON());
            }
            List<string> list = new() { this._name, this._map.ToJSON(), this._gameType.ToJSON(), this._armyLimit.ToString(), JSONObject.ListToJSON(missions), JSONObject.ListToJSON(logs), JSONObject.ListToJSON(armies) };
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        public static Tournament FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string name = list[0];
            Map map = Map.FromJSON(list[1]);
            GameType gameType = GameType.FromJSON(list[2]);
            int armyLimit = Int32.Parse(list[3]);

            List<string> temp = JSONObject.JSONToList<string>(list[4]);
            List<Mission> missions = new();
            foreach (string m in temp)
            {
                missions.Add(Mission.FromJSON(m));
            }

            temp = JSONObject.JSONToList<string>(list[5]);
            List<Log> logs = new();
            foreach (string l in temp)
            {
                logs.Add(Log.FromJSON(l));
            }

            temp = JSONObject.JSONToList<string>(list[6]);
            List<ArmyList> armies = new();
            foreach (string a in temp)
            {
                armies.Add(ArmyList.FromJSON(a));
            }

            Tournament Tournament = new(name, map, gameType, armyLimit, missions, logs, armies);
            return Tournament;
        }

        public override string ToString()
        {
            return this._name + ", " + this._map.ToString() + ", " + this._gameType.ToString() + ", " + this._armyLimit + ", " + this._missions.Count + ", " + this._logs.Count + ", " + this._armies.Count;
        }
    }
}
