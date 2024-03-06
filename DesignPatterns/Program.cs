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

            List<string> Rules2 = new() { "Rule2", "Rule3", "Rule4" };
            Terrain T2 = new("Terrain2", Rules);
            TerrainCoordinates TC4 = new(T2, 4, 4);
            TerrainCoordinates TC5 = new(T2, 5, 5);
            TerrainCoordinates TC6 = new(T2, 6, 6);
            List<TerrainCoordinates> LTC2 = new() { TC4, TC5, TC6 };
            Map Map2 = new("Map2", LTC2);

            Unit U4 = new Beast("Beast2", 2);
            Unit U5 = new Infantry("Infantry2", 2);
            Unit U6 = new Vehicle("Vehicle2", 2);
            List<Unit> LU2 = new() { U4, U5, U6 };
            Faction F4 = new("Faction4", LU2);
            Faction F5 = new("Faction5", LU2);
            Faction F6 = new("Faction6", LU2);
            List<Faction> LF2 = new() { F4, F5, F6 };
            GameType GameType2 = new("GameType2", LF2);

            ArmyList army = new("ArmyList1", "Player1", LU);
            ArmyList army2 = new("ArmyList1", "Player1", LU);

            string jsonString1 = U1.ToJSON();
            string jsonString2 = U2.ToJSON();
            string jsonString3 = U3.ToJSON();
            string jsonString4 = U4.ToJSON();
            string jsonString5 = U5.ToJSON();
            string jsonString6 = U6.ToJSON();
            List<String> list = new() { jsonString1, jsonString2, jsonString3, jsonString4, jsonString5, jsonString6 };
            /*
            Console.WriteLine(jsonString);

            Tournament Tournament2 = Tournament.FromJSON(jsonString);
            Console.WriteLine(Tournament2.ToString());
            */

            JSONObject.WriteJSONToFile(list, "Units.json");
            List<string> jsonList = JSONObject.ReadJSONFile("Units.json");
            List<Unit> list2 = new();
            foreach (string item in jsonList)
            {
                Unit temp = Unit.FromJSON(item);
                list2.Add(temp);
            }

            foreach (Unit temp in list2)
            {
                Console.WriteLine(temp.ToString());
            }

        }
    }
}
