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
        private List<Mission> primaryMissions { get; set; }
        private List<Mission> secondaryMissions { get; set; }
        private Map map { get; set; }
        private GameType gameType { get; set; }
        private List<Log> logs { get; set; }
        private List<ArmyList> armies { get; set; }
        private string name { get; set; }

        public Tournament(Map map, GameType gameType, string name)
        {
            this.map = map;
            this.gameType = gameType;
            this.name = name;
            this.primaryMissions = new();
            this.secondaryMissions = new();
            this.logs = new();
            this.armies = new();
        }

        public Tournament(Map map, GameType gameType, string name, List<Mission> primaryMissions, List<Mission> secondaryMissions, List<Log> logs, List<ArmyList> armies)
        {
            this.map = map;
            this.gameType = gameType;
            this.name = name;
            this.primaryMissions = primaryMissions;
            this.secondaryMissions = secondaryMissions;
            this.logs = logs;
            this.armies = armies;
        }

        public void addPrimaryMission(Mission m)
        {
            this.primaryMissions.Add(m);
        }

        public void addSecondaryMission(Mission m)
        {
            this.secondaryMissions.Add(m);
        }

        public void addLog(Log l)
        {
            this.logs.Add(l);
        }

        public void addArmy(ArmyList a)
        {
            this.armies.Add(a);
        }

        public Mission getPrimaryMissionById(int id)
        {
            return this.primaryMissions[id];
        }

        public Mission getSecondaryMissionById(int id)
        {
            return this.secondaryMissions[id];
        }

        public Log getLogById(int id)
        {
            return this.logs[id];
        }

        public ArmyList getArmyById(int id)
        {
            return this.armies[id];
        }

        public string ToJSON()
        {
            List<string> primaryMissions = new();
            foreach(Mission mission in this.primaryMissions)
            {
                primaryMissions.Add(mission.ToJSON());
            }
            List<string> secondaryMissions = new();
            foreach(Mission mission in this.secondaryMissions)
            {
                secondaryMissions.Add(mission.ToJSON());
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

            List<string> list = new() 
            { 
                this.map.ToJSON(), 
                this.gameType.ToJSON(),
                "\"" + this.name + "\"",
                JSONObject.ListToJSON(primaryMissions), 
                JSONObject.ListToJSON(secondaryMissions), 
                JSONObject.ListToJSON(logs), 
                JSONObject.ListToJSON(armies) 
            };
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        public static Tournament FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            Map map = Map.FromJSON(list[0]);
            GameType gameType = GameType.FromJSON(list[1]);
            string name = list[2];

            List<string> temp = JSONObject.JSONToList<string>(list[3]);
            List<Mission> primaryMissions = new();
            foreach (string m in temp)
            {
                primaryMissions.Add(Mission.FromJSON(m));
            }

            temp = JSONObject.JSONToList<string>(list[4]);
            List<Mission> secondaryMissions = new();
            foreach (string m in temp)
            {
                secondaryMissions.Add(Mission.FromJSON(m));
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

            Tournament tournament = new(map, gameType, name, primaryMissions, secondaryMissions, logs, armies);
            return tournament;
        }

        public override string ToString()
        {
            return this.map.ToString() + ", " + this.gameType.ToString() + ", " + this.primaryMissions.Count + ", " + this.secondaryMissions.Count + ", " + this.logs.Count + ", " + this.armies.Count;
        }
    }
}
