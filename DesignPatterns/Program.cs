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

            ArmyList AL = new("Army1", "Player1");
            AL.AddUnit(U1);
            AL.AddUnit(U2);
            AL.AddUnit(U3);

            string jsonString = AL.ToJSON();
            Console.WriteLine(jsonString);

            ArmyList AL2 = ArmyList.FromJSON(jsonString);
            Console.WriteLine(AL2.ToString());
        }
    }
}
