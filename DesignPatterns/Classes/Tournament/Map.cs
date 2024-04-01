using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Map
    {
        private string name { get; set; }
        private List<TerrainCoordinates> terrains { get; set; }

        public Map(string name)
        {
            this.name = name;
            this.terrains = new();
        }

        public Map(string name, List<TerrainCoordinates> terrains)
        {
            this.name = name;
            this.terrains = terrains;
        }

        public void addTerrain(Terrain t, int x, int y)
        {
            terrains.Add(new TerrainCoordinates(t, x, y));
        }

        public TerrainCoordinates getTerrainById(int id) 
        {
            return terrains[id];
        }

        public string ToJSON()
        {
            List<string> list = new() { this.name };
            foreach (TerrainCoordinates terrain in terrains)
            {
                list.Add(terrain.ToJSON());
            }
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        public static Map FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string name = list[0];
            List<TerrainCoordinates> terrains = new();
            for(int i = 1; i < list.Count; i++)
            {
                terrains.Add(TerrainCoordinates.FromJSON(list[i]));
            }
            Map map = new(name, terrains);
            return map;
        }

        public override string ToString()
        {
            return this.name + ", " + this.terrains.Count;
        }
    }
}
