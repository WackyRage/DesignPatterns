using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Map
    {
        private string _name;
        private List<TerrainCoordinates> _terrains;
        public string name
        {
            get => _name;
            set => _name = value;
        }
        public List<TerrainCoordinates> terrains
        {
            get => _terrains;
            set => _terrains = value;
        }

        public Map(string name)
        {
            this._name = name;
            this._terrains = new();
        }

        public Map(string name, List<TerrainCoordinates> terrains)
        {
            this._name = name;
            this._terrains = terrains;
        }

        public void addTerrain(Terrain t, int x, int y)
        {
            _terrains.Add(new TerrainCoordinates(t, x, y));
        }

        public TerrainCoordinates getTerrainById(int id) 
        {
            return _terrains[id];
        }

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
