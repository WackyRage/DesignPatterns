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
        public List<Mission> Missions { get; set; }
        public Map Map { get; set; }
        public GameType GameType { get; set; }
        public List<Log> Logs { get; set; }
        public List<ArmyList> Armies { get; set; }

        public Tournament(Map Map, GameType GameType)
        {
            this.Map = Map;
            this.GameType = GameType;
            this.Missions = new();
            this.Logs = new();
            this.Armies = new();
        }

        public Tournament(Map Map, GameType GameType, List<Mission> Missions, List<Log> Logs, List<ArmyList> Armies)
        {
            this.Map = Map;
            this.GameType = GameType;
            this.Missions = Missions;
            this.Logs = Logs;
            this.Armies = Armies;
        }

        public void AddMission(Mission M)
        {
            Missions.Add(M);
        }

        public void AddLog(Log L)
        {
            Logs.Add(L);
        }

        public void AddArmy(ArmyList A)
        {
            Armies.Add(A);
        }

        public Mission GetMissionById(int Id)
        {
            return Missions[Id];
        }

        public Log GetLogById(int Id)
        {
            return Logs[Id];
        }

        public ArmyList GetArmyById(int Id)
        {
            return Armies[Id];
        }

        public string ToJSON()
        {
            List<string> Missions = new();
            foreach(Mission Mission in this.Missions)
            {
                Missions.Add(Mission.ToJSON());
            }
            List<string> Logs = new();
            foreach (Log Log in this.Logs)
            {
                Logs.Add(Log.ToJSON());
            }
            List<string> Armies = new();
            foreach(ArmyList Army in this.Armies)
            {
                Armies.Add(Army.ToJSON());
            }

            List<string> list = new() { this.Map.ToJSON(), this.GameType.ToJSON(), JSONObject.ListToJSON(Missions), JSONObject.ListToJSON(Logs), JSONObject.ListToJSON(Armies) };
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        public static Tournament FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            Map Map = Map.FromJSON(list[0]);
            GameType GameType = GameType.FromJSON(list[1]);

            List<string> Temp = JSONObject.JSONToList<string>(list[2]);
            List<Mission> Missions = new();
            foreach (string M in Temp)
            {
                Missions.Add(Mission.FromJSON(M));
            }

            Temp = JSONObject.JSONToList<string>(list[3]);
            List<Log> Logs = new();
            foreach (string L in Temp)
            {
                Logs.Add(Log.FromJSON(L));
            }

            Temp = JSONObject.JSONToList<string>(list[4]);
            List<ArmyList> Armies = new();
            foreach (string A in Temp)
            {
                Armies.Add(ArmyList.FromJSON(A));
            }

            Tournament Tournament = new(Map, GameType, Missions, Logs, Armies);
            return Tournament;
        }

        public override string ToString()
        {
            return this.Map.ToString() + ", " + this.GameType.ToString() + ", " + this.Missions.Count + ", " + this.Logs.Count + ", " + this.Armies.Count;
        }
    }
}
