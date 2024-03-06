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
        public List<TerrainCoordinates> Terrains { get; set; }

        public Map(string Name)
        {
            this.Name = Name;
            this.Terrains = new();
        }

        public Map(string Name, List<TerrainCoordinates> Terrains)
        {
            this.Name = Name;
            this.Terrains = Terrains;
        }

        public void AddTerrain(Terrain T, int X, int Y)
        {
            Terrains.Add(new TerrainCoordinates(T, X, Y));
        }

        public TerrainCoordinates GetTerrainById(int Id) 
        {
            return Terrains[Id];
        }

        public string ToJSON()
        {
            List<string> list = new() { Name };
            foreach (TerrainCoordinates Terrain in Terrains)
            {
                list.Add(Terrain.ToJSON());
            }
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        public static Map FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string Name = list[0];
            List<TerrainCoordinates> Terrains = new();
            for(int i = 1; i < list.Count; i++)
            {
                Terrains.Add(TerrainCoordinates.FromJSON(list[i]));
            }
            Map Map = new(Name, Terrains);
            return Map;
        }

        public override string ToString()
        {
            return this.Name + ", " + this.Terrains.Count;
        }
    }
}
