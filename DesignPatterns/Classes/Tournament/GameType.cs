using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class GameType
    {
        private List<Faction> Factions { get; set; }
        private string Name {  get; set; }

        public GameType(string Name) 
        {
            this.Name = Name;
            this.Factions = new();
        }

        public GameType(string Name, List<Faction> Factions) 
        {
            this.Name = Name;
            this.Factions = Factions;
        }


        public void AddFaction(Faction Faction)
        {
            Factions.Add(Faction);
        }

        public Faction GetFactionById(int Id)
        {
            return Factions[Id];
        }

        public string ToJSON() 
        {
            List<string> list = new() { Name };
            foreach (Faction Faction in Factions)
            {
                list.Add(Faction.ToJSON());
            }
            string returnString = JSONObject.ListToJSON(list);
            return returnString;
        }

        public static GameType FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string Name = list[0];
            List<Faction> Factions = new();
            for(int i = 1; i < list.Count; i++)
            {
                Faction Faction = Faction.FromJSON(list[i]);
                Factions.Add(Faction);
            }
            GameType GameType = new(Name, Factions);
            return GameType;
        }

        public override string ToString()
        {
            return Name + ", " + Factions.Count;
        }
    }
}
