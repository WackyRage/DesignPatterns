using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class GameType
    {
        private List<Faction> Factions;
        private string Name;

        public GameType(string N) 
        {
            Name = N;
            Factions = new List<Faction>();
        }

        public void SetName(string N)
        {
            Name = N;
        }

        public void AddFaction(Faction Faction)
        {
            Factions.Add(Faction);
        }

        public string GetName()
        {
            return Name;
        }

        public Faction GetFactionById(int Id)
        {
            return Factions[Id];
        }
    }
}
