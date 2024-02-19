using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Map
    {
        private string Name;
        private List<TerrainCoordinates> Terrains;

        public Map(string N)
        {
            Name = N;
            Terrains = new List<TerrainCoordinates>();
        }

        public void SetName(string N)
        {
            Name = N;
        }

        public void AddTerrain(Terrain T, int X, int Y)
        {
            Terrains.Add(new TerrainCoordinates(T, X, Y));
        }

        public string GetName()
        {
            return Name;
        }

        public TerrainCoordinates GetTerrainById(int Id) 
        {
            return Terrains[Id];
        }
    }
}
