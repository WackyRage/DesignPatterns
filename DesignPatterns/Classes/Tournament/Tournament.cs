using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Tournament
    {
        public List<Mission> PrimaryMissions { get; set; }
        public List<Mission> SecondaryMissions { get; set; } = new();
        public Map Map { get; set; }
        public GameType GameType { get; set; }
        public List<Log> Logs { get; set; } = new();
        public List<ArmyList> Armies { get; set; } = new();

        public Tournament(Map Map, GameType GameType)
        {
            this.Map = Map;
            this.GameType = GameType;
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
    }
}
