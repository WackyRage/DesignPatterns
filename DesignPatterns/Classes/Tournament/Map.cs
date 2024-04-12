using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Class representing a map, containing terrains
    internal class Map
    {
        private string _name;
        private List<TerrainCoordinates> _terrains;

        // Constructor for Map without pre-defined terrains.
        public Map(string name)
        {
            this._name = name;
            this._terrains = new();
        }

        // Constructor for Map with pre-defined terrains.
        public Map(string name, List<TerrainCoordinates> terrains)
        {
            this._name = name;
            this._terrains = terrains;
        }

        // Method for getting and setting the name of the Map.
        public string name
        {
            get => _name;
            set => _name = value;
        }

        // Method for getting and setting the name of the Map.
        public List<TerrainCoordinates> terrains
        {
            get => _terrains;
            set => _terrains = value;
        }

        // Method adding new terrain to map, with coordinates.
        public void addTerrain(Terrain t, int x, int y)
        {
            // Check if the coordinates already exist in the map
            foreach (TerrainCoordinates terrain in _terrains)
            {
                if (terrain.getCoordinates()[0] == x && terrain.getCoordinates()[1] == y)
                {
                    // If the coordinates already exist, throw an exception or handle it as desired
                    throw new ArgumentException($"Terrain with coordinates ({x}, {y}) already exists in the map.");
                }
            }

            // If the coordinates do not exist, add the new terrain to the map
            _terrains.Add(new TerrainCoordinates(t, x, y));
        }

        // Method to get specific terrain from terrain list
        public TerrainCoordinates getTerrainById(int id) 
        {
            return _terrains[id];
        }

        // Method to convert Map to JSONString
        public string ToJSON()
        {
            List<string> list = new() { this._name };
            foreach (TerrainCoordinates terrain in _terrains)
            {
                list.Add(terrain.ToJSON());
            }
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        // Method to covert JSONString back to a Map
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
            return this._name + ", " + this._terrains.Count;
        }

        public static implicit operator Map(string v)
        {
            throw new NotImplementedException();
        }
    }
}
