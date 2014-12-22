using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        public static Bitmap EnhanceImage(CellularAutomata<bool> automata)
        {
            const int cellSize = 50;
            Brush skyBrush = new SolidBrush(Color.White);
            Brush groundBrush1 = new SolidBrush(Color.Black);
            Brush groundBrush2 = new SolidBrush(Color.DarkGray);

            var grid = automata.Data;

            int width = grid.GetLength(0), height = grid.GetLength(1);
            Bitmap bmp = new Bitmap(width * cellSize, height * cellSize);
            Graphics g = Graphics.FromImage(bmp);

            g.FillRectangle(skyBrush, 0, 0, width * cellSize, height * cellSize);

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    if (!grid[x, y])
                        continue; // spaces are always completely empty

                    var groundBrush = (x + y) % 2 == 0 ? groundBrush1 : groundBrush2;

                    // check each corner in turn, to decide how to draw
                    var tl = ShouldFillCorner(automata, x - 1, y, x, y - 1);
                    var tr = ShouldFillCorner(automata, x + 1, y, x, y - 1);
                    var bl = ShouldFillCorner(automata, x - 1, y, x, y + 1);
                    var br = ShouldFillCorner(automata, x + 1, y, x, y + 1);

                    if (!tl && !tr && !bl && !br)
                    {
                        g.FillRectangle(groundBrush, x * cellSize, y * cellSize, cellSize, cellSize);
                        continue;
                    }

                    var points = new Point[4];

                    if (tl)
                        points[0] = new Point(x * cellSize, y * cellSize);
                    else
                        points[0] = new Point(x * cellSize + cellSize / 2, y * cellSize + cellSize / 2);
                    
                    if (tr)
                        points[1] = new Point(x * cellSize + cellSize, y * cellSize);
                    else
                        points[1] = new Point(x * cellSize + cellSize / 2, y * cellSize + cellSize / 2);
                    
                    if (br)
                        points[2] = new Point(x * cellSize + cellSize, y * cellSize + cellSize);
                    else
                        points[2] = new Point(x * cellSize + cellSize / 2, y * cellSize + cellSize / 2);
                    
                    if (bl)
                        points[3] = new Point(x * cellSize, y * cellSize + cellSize);
                    else
                        points[3] = new Point(x * cellSize + cellSize / 2, y * cellSize + cellSize / 2);
                    
                    g.FillPolygon(groundBrush, points);
                }

            return bmp;
        }

        private static bool ShouldFillCorner(CellularAutomata<bool> automata, int x1, int y1, int x2, int y2)
        {
            bool leftRight = automata.Constrain(ref x1, ref y1) ? automata.Data[x1, y1] : true;
            bool topBottom = automata.Constrain(ref x2, ref y2) ? automata.Data[x2, y2] : true;

            if (leftRight)
                return true;
            return topBottom ? true : false;
        }
    }
}
