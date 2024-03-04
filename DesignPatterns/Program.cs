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
            Unit U1 = new Beast("Beast1", 1);
            Unit U2 = new Infantry("Infantry1", 2);
            Unit U3 = new Vehicle("Vehicle1", 3);
            List<Unit> UL = new () { U1, U2, U3 };
            Faction F1 = new("Faction1", UL);
            Faction F2 = new("Faction2", UL);
            Faction F3 = new("Faction3", UL);
            List<Faction> FL = new() { F1, F2, F3 };
            GameType GT = new("GameType1", FL);

            string jsonString = GT.ToJSON();
            Console.WriteLine(jsonString);

            GameType GT2 = GameType.FromJSON(jsonString);
            Console.WriteLine(GT2.Factions[0].ToString());
        }
    }
}
