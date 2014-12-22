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
            var numWalls = cellInfo.GetNeighbours(2, 1, true).Count(b => b);
            if (numWalls >= 8)
                return true;

            // make stuff appear in the middle of large spaces
            numWalls += cellInfo.GetNeighbours(3, 2).Count(b => b);
            return numWalls <= 1;
        }

        public static bool Contract(CellularAutomata<bool>.CellInfo cellInfo)
        {
            var numWalls = cellInfo.GetNeighbours(2, 1, true).Count(b => b);
            return numWalls >= 8;
        }
    }
}
