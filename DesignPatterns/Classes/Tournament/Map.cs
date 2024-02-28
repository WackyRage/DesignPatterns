using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Map
    {
        public string Name { get; set; }
        public List<TerrainCoordinates> Terrains { get; set; } = new();

        public Map(string Name)
        {
            this.Name = Name;
        }

        public void AddTerrain(Terrain T, int X, int Y)
        {
            Terrains.Add(new TerrainCoordinates(T, X, Y));
        }

        public TerrainCoordinates GetTerrainById(int Id) 
        {
            return Terrains[Id];
        }
    }
}
