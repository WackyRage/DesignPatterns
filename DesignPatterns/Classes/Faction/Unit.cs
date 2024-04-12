using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Interface unit, providing necessary methods for JSON.
    internal interface Unit
    {
        string ToJSON();

        public static Unit FromJSON(string jsonString)
        {
            return (Unit)JSONObject.JSONToObject(jsonString);
        }

    }
}
