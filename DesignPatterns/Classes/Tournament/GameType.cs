using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class GameType
    {
        public List<Faction> Factions { get; set; } = new();
        public string Name {  get; set; }

        public GameType(string Name) 
        {
            this.Name = Name;
        }

        public void AddFaction(Faction Faction)
        {
            Factions.Add(Faction);
        }

        public Faction GetFactionById(int Id)
        {
            return Factions[Id];
        }
    }
}
