using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal interface Unit
    {
        public string Name { get; set; }
        public int Value { get; set; }

        string ToJSON();

        public static Unit FromJSON(string jsonString)
        {
            return (Unit)JSONObject.JSONToObject(jsonString);
        }

    }
}
