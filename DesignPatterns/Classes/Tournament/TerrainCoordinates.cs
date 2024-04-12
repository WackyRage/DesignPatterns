using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Class containing information of a terrain and coordinates
    internal class TerrainCoordinates
    {
        private Terrain terrain;
        private int xCoordinate;
        private int yCoordinate;

        public TerrainCoordinates(Terrain terrain, int xCoordinate, int yCoordinate)
        {
            this.terrain = terrain;
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }

        // Method to set X and Y coordinats
        public void setCoordinates(int x, int y)
        {
            this.xCoordinate = x;
            this.yCoordinate = y;
        }

        // Method to get coordinates as a list
        public List<int> getCoordinates()
        {
            // Return with index 0 as X and index 1 as Y
            return new List<int> { xCoordinate, yCoordinate };
        }

        // Method to convert TeraainCoodinates to JSONString
        public string ToJSON()
        {
            string terrain = this.terrain.ToJSON();
            List<string> list = new() { terrain, this.xCoordinate.ToString(), this.yCoordinate.ToString() };
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        // Method to covert JSONString back to a TerrainCoordinates
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
