using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class GameType
    {
        private List<Faction> factions;
        private string name;

        public GameType(string name) 
        {
            this.name = name;
            this.factions = new();
        }

        public GameType(string name, List<Faction> factions) 
        {
            this.name = name;
            this.factions = factions;
        }


        public void addFaction(Faction faction)
        {
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
