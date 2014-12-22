using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveGen
{
    public class CaveGenerator
    {
        public CaveGenerator(int width, int height, int initialFillPercentage)
        {
            Random r = new Random();
            var automata = new CellularAutomata<bool>(width, height, () => r.Next(100) < initialFillPercentage);
            automata.BoundaryState = true;
            automata.LoopHorizontal = true;
            automata.LoopVertical = false;

            automata.Iterate(GrowAndContract, 4);
            automata.Iterate(Contract, 3);
        }

        public static bool GrowAndContract(CellularAutomata<bool>.CellInfo cellInfo)
        {
            if (cellInfo.IsCorner)
                return true; // corners should always stay solid

            var numWalls = cellInfo.GetNeighbours(1, 1).Count(b => b) + (cellInfo.State ? 1 : 0);
            if (numWalls >= 5)
                return true;

            // make stuff appear in the middle of large spaces
            numWalls += cellInfo.GetNeighbours(2, 2).Count(b => b);
            return numWalls <= 1;
        }

        public static bool Contract(CellularAutomata<bool>.CellInfo cellInfo)
        {
            if (cellInfo.IsCorner)
                return true; // corners should always stay solid

            var numWalls = cellInfo.GetNeighbours(1, 1).Count(b => b) + (cellInfo.State ? 1 : 0);
            return numWalls >= 5;
        }
    }
}
