using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DesignPatterns
{
    internal class Program
    {
        public static void Main()
        {
            List<string> Rules = new() { "Rule1", "Rule2", "Rule3" };
            Terrain T1 = new("Terrain1", Rules);
            TerrainCoordinates TC1 = new(T1, 1, 1);
            TerrainCoordinates TC2 = new(T1, 2, 2);
            TerrainCoordinates TC3 = new(T1, 3, 3);
            List<TerrainCoordinates> LTC = new() { TC1, TC2, TC3 };
            Map Map = new("Map1", LTC);

            Unit U1 = new Beast("Beast1", 1);
            Unit U2 = new Infantry("Infantry1", 1);
            Unit U3 = new Vehicle("Vehicle1", 1);
            List<Unit> LU = new() { U1, U2, U3 };
            Faction F1 = new("Faction1", LU);
            Faction F2= new("Faction2", LU);
            Faction F3 = new("Faction3", LU);
            List<Faction> LF = new() { F1, F2, F3 };
            GameType GameType = new("GameType1", LF);

            ArmyList AL1 = new("ArmyList1", "Player1", LU);
            ArmyList AL2 = new("ArmyList2", "Player2", LU);
            ArmyList AL3 = new("ArmyList3", "Player3", LU);
            List<ArmyList> Armies = new() { AL1, AL2, AL3 };

            Mission M1 = new("Mision1", "MissionDescription1", 1);
            Mission M2 = new("Mision2", "MissionDescription2", 2);
            Mission M3 = new("Mision3", "MissionDescription3", 3);

            List<Mission> Missions = new() { M1, M2, M3 };

            Log L1 = new("Log1", DateTime.Now, true);
            Log L2 = new("Log2", DateTime.Now, false);
            Log L3 = new("Log3", DateTime.Now, true);
            List<Log> Logs = new() { L1, L2, L3 };

            Tournament Tournament = new(Map, GameType, Missions, Missions, Logs, Armies);

            string jsonString = Tournament.ToJSON();
            Console.WriteLine(jsonString);

            Tournament Tournament2 = Tournament.FromJSON(jsonString);
            Console.WriteLine(Tournament2.ToString());


        }
    }
}
