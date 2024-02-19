using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class TerrainCoordinates
    {
        private Terrain Terrain;
        private int XCoordinate;
        private int YCoordinate;

        public TerrainCoordinates(Terrain T, int X, int Y)
        {
            Terrain = T;
            XCoordinate = X;
            YCoordinate = Y;
        }

        public void SetTerrain(Terrain T)
        {
            Terrain = T;
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

        public Terrain GetTerrain()
        {
            return Terrain;
        }
    }
}
