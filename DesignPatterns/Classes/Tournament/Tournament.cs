using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Tournament
    {
        private List<Mission> PrimaryMissions;
        private List<Mission> SecondaryMissions;
        private Map Map;
        private GameType GameType;
        private List<Log> Logs;
        private List<ArmyList> Armies;

        public Tournament(Map M, GameType G)
        {
            Map = M;
            GameType = G;
            PrimaryMissions = new List<Mission>();
            SecondaryMissions = new List<Mission>();
            Logs = new List<Log>();
            Armies = new List<ArmyList>();
        }

        public void SetMap(Map M)
        {
            Map = M;
        }

        public void SetGameType(GameType G)
        {
            GameType = G;
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

        public Map GetMap()
        {
            return Map;
        }

        public GameType GetGameType()
        {
            return GameType;
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
    }
}
