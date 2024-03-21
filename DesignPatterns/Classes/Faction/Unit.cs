using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// Respresents a Unit in the game
    /// <summary>
    internal interface Unit
    {
        // Properties required by all Unit subvariants

        /// <summary>
        /// Gets and sets the name of the unit.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the unit.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Converts Unit to a Json string.
        /// </summary>
        /// <returns> A JSON formatted representation of the Unit.</returns>
        string ToJSON();

        /// <summary>
        /// Converts JSON format into a Unit object
        /// </summary>
        /// <param name="jsonString">JSON string representing the Unit object</param>
        /// <returns>A Unit object converted from the JSON string.</returns>
        public static Unit FromJSON(string jsonString)
        {
            return (Unit)JSONObject.JSONToObject(jsonString);
        }

    }
}
