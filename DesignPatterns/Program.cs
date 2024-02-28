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

            JsonSerializerOptions O = new JsonSerializerOptions { IncludeFields = true };
            string jsonString = JsonSerializer.Serialize<Unit>(U1, O);
            Console.WriteLine(jsonString);

            Beast B1 = JsonSerializer.Deserialize<Beast>(jsonString);
            Console.WriteLine(B1.ToString());
        }
    }
}
