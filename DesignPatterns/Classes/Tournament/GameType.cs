using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Class for GameType, containing all Factions.
    internal class GameType
    {
        private List<Faction> factions;
        private string name;

        // Constructor for GameType without pre-defined factions.
        public GameType(string name) 
        {
            this.name = name;
            this.factions = new();
        }

        // Constructor for GameType with pre-defined factions.
        public GameType(string name, List<Faction> factions) 
        {
            this.name = name;
            this.factions = factions;
        }

        // Method of adding a faction.
        public void addFaction(Faction faction)
        {
            foreach (Faction existingFaction in factions)
            {
                // Check if loped faction has the same name.
                if (existingFaction.name == faction.name)
                {
                    // If a faction name already exists, throw an exception.
                    throw new ArgumentException($"Faction with name '{faction.name}' already exists.");
                }
            }

            // If no faction with the same name exists, add the new faction.
            this.factions.Add(faction);
        }

        public Faction getFactionById(int id)
        {
            return this.factions[id];
        }

        public string ToJSON() 
        {
            List<string> list = new() { this.name };
            foreach (Faction faction in factions)
            {
                list.Add(faction.ToJSON());
            }
            string returnString = JSONObject.ListToJSON(list);
            return returnString;
        }

        public static GameType FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string name = list[0];
            List<Faction> factions = new();
            for (int i = 1; i < list.Count; i++)
            {
                Faction faction = Faction.FromJSON(list[i]);
                factions.Add(faction);
            }
            GameType gameType = new(name, factions);
            return gameType;
        }

        public override string ToString()
        {
            return this.name + ", " + this.factions.Count;
        }
    }
}
