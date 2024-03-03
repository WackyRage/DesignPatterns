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

            List<Unit> LU = new();
            LU.Add(U1); 
            LU.Add(U2);
            LU.Add(U3);

            string jsonString = JSONObject.ListToJSON<Unit>(LU);
            Console.WriteLine(jsonString);

            List<Unit> LU2 = JSONObject.JSONToList<Unit>(jsonString);
            foreach (Unit u in LU2)
            {
                Console.WriteLine(u.ToString());
            }

            /*
            Unit U2 = (Unit)JSONObject.JSONToObject(jsonString);
            Console.WriteLine(U2.ToString());
            */
        }
    }
}
