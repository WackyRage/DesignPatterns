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
        public List<Mission> PrimaryMissions { get; set; }
        public List<Mission> SecondaryMissions { get; set; }
        public Map Map { get; set; }
        public GameType GameType { get; set; }
        public List<Log> Logs { get; set; }
        public List<ArmyList> Armies { get; set; }
        public String Name {  get; set; }

        public Tournament(Map Map, GameType GameType, String name)
        {
            this.Map = Map;
            this.GameType = GameType;
            this.Name = name;
            this.PrimaryMissions = new();
            this.SecondaryMissions = new();
            this.Logs = new();
            this.Armies = new();
        }

        public Tournament(Map Map, GameType GameType, String name, List<Mission> PrimaryMissions, List<Mission> SecondaryMissions, List<Log> Logs, List<ArmyList> Armies)
        {
            this.Map = Map;
            this.GameType = GameType;
            this.Name = name;
            this.PrimaryMissions = PrimaryMissions;
            this.SecondaryMissions = SecondaryMissions;
            this.Logs = Logs;
            this.Armies = Armies;
        }

        public void AddPrimaryMission(Mission M)
        {
            PrimaryMissions.Add(M);
        }

        public void AddSecondaryMission(Mission M)
        {
            SecondaryMissions.Add(M);
        }

        public void AddLog(Log L)
        {
            Logs.Add(L);
        }

        public void AddArmy(ArmyList A)
        {
            Armies.Add(A);
        }

        public Mission GetPrimaryMissionById(int Id)
        {
            return PrimaryMissions[Id];
        }

        public Mission GetSecondaryMissionById(int Id)
        {
            return SecondaryMissions[Id];
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
            List<string> PrimaryMissions = new();
            foreach(Mission Mission in this.PrimaryMissions)
            {
                PrimaryMissions.Add(Mission.ToJSON());
            }
            List<string> SecondaryMissions = new();
            foreach(Mission mission in this.SecondaryMissions)
            {
                SecondaryMissions.Add(mission.ToJSON());
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

            List<string> list = new() { this.Map.ToJSON(), this.GameType.ToJSON(), JSONObject.ListToJSON(PrimaryMissions), JSONObject.ListToJSON(SecondaryMissions), JSONObject.ListToJSON(Logs), JSONObject.ListToJSON(Armies) };
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
            return this.Map.ToString() + ", " + this.GameType.ToString() + ", " + this.PrimaryMissions.Count + ", " + this.SecondaryMissions.Count + ", " + this.Logs.Count + ", " + this.Armies.Count;
        }
    }
}
