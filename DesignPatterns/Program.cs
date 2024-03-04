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
            List<string> R1 = new() { "Rule1", "Rule2", "Rule3" };
            Terrain T1 = new("Terrain1", R1);
            TerrainCoordinates TC1 = new(T1, 1, 1);

            string jsonString = TC1.ToJSON();
            Console.WriteLine(jsonString);

            TerrainCoordinates TC2 = TerrainCoordinates.FromJSON(jsonString);
            Console.WriteLine(TC2.ToString());
        }
    }
}
