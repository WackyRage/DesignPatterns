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
        public Terrain Terrain { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate {  get; set; }

        public TerrainCoordinates(Terrain Terrain, int XCoordinate, int YCoordinate)
        {
            this.Terrain = Terrain;
            this.XCoordinate = XCoordinate;
            this.YCoordinate = YCoordinate;
        }

        public void SetCoordinates(int X, int Y)
        {
            XCoordinate = X;
            YCoordinate = Y;
        }

        public List<int> GetCoordinates()
        {
            return new List<int> { XCoordinate, YCoordinate };
        }

        public string ToJSON()
        {
            string Terrain = this.Terrain.ToJSON();
            List<string> list = new() { Terrain, this.XCoordinate.ToString(), this.YCoordinate.ToString() };
            string jsonString = JSONObject.ListToJSON(list);
            return jsonString;
        }

        public static TerrainCoordinates FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            Terrain Terrain = Terrain.FromJSON(list[0]);
            int XCoordinate = Convert.ToInt32(list[1]);
            int YCoordinate = Convert.ToInt32(list[2]);
            TerrainCoordinates TerrainCoordinates = new(Terrain, XCoordinate, YCoordinate);
            return TerrainCoordinates;
        }

        public override string ToString()
        {
            return Terrain.ToString() + ", " + XCoordinate + ", " + YCoordinate;
        }
    }
}
