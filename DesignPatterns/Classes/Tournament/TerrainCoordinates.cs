using System;
using System.Collections.Generic;
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
    }
}
