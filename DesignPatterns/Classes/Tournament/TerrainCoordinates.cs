using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class TerrainCoordinates
    {
        private Terrain terrain { get; set; }
        private int xCoordinate { get; set; }
        private int yCoordinate {  get; set; }

        public TerrainCoordinates(Terrain terrain, int xCoordinate, int yCoordinate)
        {
            this.terrain = terrain;
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }

        public void setCoordinates(int x, int y)
        {
            this.xCoordinate = x;
            this.yCoordinate = y;
        }

        public List<int> getCoordinates()
        {
            return new List<int> { xCoordinate, yCoordinate };
        }

        public string ToJSON()
        {
            string terrain = this.terrain.ToJSON();
            List<string> list = new() { terrain, this.xCoordinate.ToString(), this.yCoordinate.ToString() };
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        public static TerrainCoordinates FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            Terrain terrain = Terrain.FromJSON(list[0]);
            int xCoordinate = Convert.ToInt32(list[1]);
            int yCoordinate = Convert.ToInt32(list[2]);
            TerrainCoordinates terrainCoordinates = new(terrain, xCoordinate, yCoordinate);
            return terrainCoordinates;
        }

        public override string ToString()
        {
            return terrain.ToString() + ", " + xCoordinate + ", " + yCoordinate;
        }
    }
}
