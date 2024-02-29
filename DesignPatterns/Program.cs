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

            string jsonString = JSONObject.ToJSON(U1);
            Console.WriteLine(jsonString);

            Unit U2 = (Unit)JSONObject.JSONToObject(jsonString);
            Console.WriteLine(U2.ToString());
        }
    }
}
