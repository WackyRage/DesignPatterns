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
        private List<Mission> missions { get; set; }
        private Map map { get; set; }
        private GameType gameType { get; set; }
        private List<Log> logs { get; set; }
        private List<ArmyList> armies { get; set; }
        private int armyLimit { get; set; }
        private string name { get; set; }

        public Tournament(Map map, GameType gameType, string name, int armyLimit)
        {
            this.map = map;
            this.gameType = gameType;
            this.name = name;
            this.armyLimit = armyLimit;
            this.missions = new();
            this.logs = new();
            this.armies = new();
        }

        public Tournament(Map map, GameType gameType, string name, int armyLimit, List<Mission> missions, List<Log> logs, List<ArmyList> armies)
        {
            this.map = map;
            this.gameType = gameType;
            this.name = name;
            this.armyLimit = armyLimit;
            this.missions = missions;
            this.logs = logs;
            this.armies = armies;
        }

        public void addMission(Mission m)
        {
            this.missions.Add(m);
        }

        public void addLog(Log l)
        {
            this.logs.Add(l);
        }

        public void addArmy(ArmyList a)
        {
            if (a.getArmyValue() <= this.armyLimit)
            {
                this.armies.Add(a);
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
                this.armies.Add(new ArmyList(armyName, playerName));
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"An error occurred while adding a new army: {e.Message}");

            }
        }

        public void addUnitToArmy(string playerName, string armyName, AbstractUnit unit)
        {
            foreach (var army in this.armies)
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
            return this.missions[id];
        }

        public Log getLogById(int id)
        {
            return this.logs[id];
        }

        public ArmyList getArmyById(int id)
        {
            return this.armies[id];
        }

        public ArmyList getArmyByPlayer(string player)
        {
            foreach (var army in this.armies)
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
            foreach (var army in this.armies)
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
            foreach (Mission mission in this.missions)
            {
                missions.Add(mission.ToJSON());
            }
            List<string> logs = new();
            foreach (Log log in this.logs)
            {
                logs.Add(log.ToJSON());
            }
            List<string> armies = new();
            foreach(ArmyList army in this.armies)
            {
                armies.Add(army.ToJSON());
            }
            List<string> list = new() { this.map.ToJSON(), this.gameType.ToJSON(), JSONObject.ListToJSON(missions), JSONObject.ListToJSON(logs), JSONObject.ListToJSON(armies) };
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        public static Tournament FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            Map map = Map.FromJSON(list[0]);
            GameType gameType = GameType.FromJSON(list[1]);

            List<string> temp = JSONObject.JSONToList<string>(list[2]);
            List<Mission> missions = new();
            foreach (string m in temp)
            {
                missions.Add(Mission.FromJSON(m));
            }

            temp = JSONObject.JSONToList<string>(list[3]);
            List<Log> logs = new();
            foreach (string l in temp)
            {
                logs.Add(Log.FromJSON(l));
            }

            temp = JSONObject.JSONToList<string>(list[4]);
            List<ArmyList> armies = new();
            foreach (string a in temp)
            {
                armies.Add(ArmyList.FromJSON(a));
            }

            Tournament Tournament = new(map, gameType, missions, logs, armies);
            return Tournament;
        }

        public override string ToString()
        {
            return this.map.ToString() + ", " + this.gameType.ToString() + ", " + this.missions.Count + ", " + this.logs.Count + ", " + this.armies.Count;
        }
    }
}
