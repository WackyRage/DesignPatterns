using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal interface UnitInterface
    {
        string ToJSON();

        public static UnitInterface FromJSON(string jsonString)
        {
            return (UnitInterface)JSONObject.JSONToObject(jsonString);
        }

    }
}
