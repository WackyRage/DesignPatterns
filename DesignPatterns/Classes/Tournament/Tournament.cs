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

        public Tournament(Map map, GameType gameType)
        {
            this.map = map;
            this.gameType = gameType;
            this.primaryMissions = new();
            this.secondaryMissions = new();
            this.logs = new();
            this.armies = new();
        }

        public Tournament(Map map, GameType gameType, List<Mission> primaryMissions, List<Mission> secondaryMissions, List<Log> logs, List<ArmyList> armies)
        {
            this.map = map;
            this.gameType = gameType;
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

            List<string> list = new() { this.map.ToJSON(), this.gameType.ToJSON(), JSONObject.ListToJSON(primaryMissions), JSONObject.ListToJSON(secondaryMissions), JSONObject.ListToJSON(logs), JSONObject.ListToJSON(armies) };
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        public static Tournament FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            Map Map = Map.FromJSON(list[0]);
            GameType GameType = GameType.FromJSON(list[1]);

            List<string> Temp = JSONObject.JSONToList<string>(list[2]);
            List<Mission> PrimaryMissions = new();
            foreach (string M in Temp)
            {
                PrimaryMissions.Add(Mission.FromJSON(M));
            }

            Temp = JSONObject.JSONToList<string>(list[3]);
            List<Mission> SecondaryMissions = new();
            foreach (string M in Temp)
            {
                SecondaryMissions.Add(Mission.FromJSON(M));
            }

            Temp = JSONObject.JSONToList<string>(list[4]);
            List<Log> Logs = new();
            foreach (string L in Temp)
            {
                Logs.Add(Log.FromJSON(L));
            }

            Temp = JSONObject.JSONToList<string>(list[5]);
            List<ArmyList> Armies = new();
            foreach (string A in Temp)
            {
                Armies.Add(ArmyList.FromJSON(A));
            }

            Tournament Tournament = new(Map, GameType, PrimaryMissions, SecondaryMissions, Logs, Armies);
            return Tournament;
        }

        public override string ToString()
        {
            return this.map.ToString() + ", " + this.gameType.ToString() + ", " + this.primaryMissions.Count + ", " + this.secondaryMissions.Count + ", " + this.logs.Count + ", " + this.armies.Count;
        }
    }
}
