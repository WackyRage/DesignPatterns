using DesignPatterns.Classes.Faction;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Class Tournament, contains all information of a tournament, including collections
    internal class Tournament: Subscriber
    {
        private string _name;
        private Map _map;
        private GameType _gameType;
        private int _armyLimit;
        private List<Mission> _missions;
        private List<Log> _logs;
        private List<ArmyList> _armies;

        // Constructor for Tournament without pre-defined missions, logs and armies.
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

        // Constructor for Tournament with pre-defined missions, logs and armies.
        public Tournament(string name, Map map, GameType gameType, int armyLimit, List<Mission> missions, List<Log> logs, List<ArmyList> armies)
        {
            this._name = name;
            this._map = map;
            this._gameType = gameType;
            this._armyLimit = armyLimit;
            this._missions = missions;
            this._logs = logs;
            this._armies = armies;
            foreach(ArmyList army in this._armies)
            {
                army.subscribe(this);
            }
        }

        // Method for getting and setting the name of the Tournament.
        public string name
        {
            get => _name;
            set => _name = value;
        }

        // Method for getting and setting the map of the Tournament.
        public Map map
        {
            get => _map;
            set => _map = value;
        }

        // Method for getting and setting the gameType of the Tournament.
        public GameType gameType
        {
            get => _gameType;
            set => _gameType = value;
        }

        // Method for getting and setting the armyLimit of the Tournament.
        public int armyLimit
        {
            get => _armyLimit;
            set => _armyLimit = value;
        }

        // Method for getting and setting the missions of the Tournament.
        public List<Mission> missions
        {
            get => _missions;
            set => _missions = value;
        }

        // Method for getting and setting the logs of the Tournament.
        public List<Log> logs
        {
            get => _logs;
            set => _logs = value;
        }

        // Method for getting and setting the armies of the Tournament.
        public List<ArmyList> armies
        {
            get => _armies;
            set => _armies = value;
        }

        // Method to add a new mission.
        public void addMission(Mission m)
        {
            this._missions.Add(m);
        }

        // Method to add new log.
        public void addLog(Log l)
        {
            this._logs.Add(l);
        }

        // Method to add new army.
        public void addArmy(ArmyList a)
        {
            // Check to see if army exceeds tournement limit.
            if (a.getArmyValue() <= this.armyLimit)
            {
                this._armies.Add(a);
                a.subscribe(this);
            }
            else
            {
                throw new InvalidOperationException("Adding the army exceeds the tournament's army limit.");
            }
        }

        // Method to create a new army.
        public void addNewArmy(String armyName, String playerName)
        {
            try
            {
                // Create new army object and add to armies list.
                ArmyList army = new ArmyList(armyName, playerName);
                this._armies.Add(army);
                army.subscribe(this);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"An error occurred while adding a new army: {e.Message}");

            }
        }

        // Method to add unit to a army.
        public void addUnitToArmy(string playerName, string armyName, AbstractUnit unit)
        {
            // Loop through armies, to select right army.
            foreach (var army in this._armies)
            {
                // Check is army and player names match.
                if (army.armyName == armyName && army.playerName == playerName)
                {
                    // Calculate new possible army value.
                    int toBeValue = army.getArmyValue() + unit.Value;
                    // Check if toBeValue is lower than limit.
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

        // Method to select mission bij index.
        public Mission getMissionById(int id)
        {
            return this._missions[id];
        }

        // Method to select log bij index.
        public Log getLogById(int id)
        {
            return this._logs[id];
        }

        // Method to select army bij index.
        public ArmyList getArmyById(int id)
        {
            return this._armies[id];
        }

        // Method to select mission bij player.
        public ArmyList getArmyByPlayer(string player)
        {
            // Loop to find army.
            foreach (var army in this._armies)
            {
                if (army.playerName == player)
                {
                    return army;
                }
            }

            throw new Exception("Army not found for the specified player.");
        }

        // Method to get army bij name.
        public ArmyList getArmyByName(string name)
        {
            // Loop to find army.
            foreach (var army in this._armies)
            {
                if (army.armyName == name)
                {
                    return army;
                }
            }

            throw new Exception("Army not found for the specified name.");
        }

        public void hasArmy(ArmyList army)
        {
            for(int i = 0; i < this._armies.Count; i++)
            {
                if (_armies[i].equals(army))
                {
                    _armies[i] = army;
                }
            }
        }

        public void update(int value, string armyName, string playerName)
        {
            if(value > this._armyLimit)
            {
                string message = "Army: " + armyName + " of player: " + playerName + " has exceded the limit size for armies in tournament: " + this._name + ".";
                Log L = new(message, DateTime.Now, false);
                this._logs.Add(L);
            }
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
