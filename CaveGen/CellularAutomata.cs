using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveGen
{
    public class CellularAutomata<T> where T : struct
    {
        public T[,] Data { get; private set; }
        public bool LoopHorizontal { get; set; }
        public bool LoopVertical { get; set; }
        public T BoundaryState { get; set; }
        public T? CornerState { get; set; }

        public CellularAutomata(T[,] data)
        {
            Data = data;
        }

        public CellularAutomata(int width, int height, Func<T> populateFunc)
        {
            Data = new T[width, height];
            for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                    Data[x, y] = populateFunc();
        }

        public void Iterate(Func<CellInfo, T> stepFunc, int numSteps)
        {
            int width = Data.GetLength(0), height = Data.GetLength(1);
            T[,] dataCopy = new T[width, height];

            var cellInfo = new CellInfo(this, 0, 0);
            for (int step=1; step<=numSteps; step++)
            {
                Array.Copy(Data, dataCopy, Data.Length); // for now, ALWAYS update Data based on dataCopy. Could be made more efficient by swapping them about, but hey.
                cellInfo.Data = dataCopy;

                for (var x = 0; x < width; x++)
                {
                    cellInfo.X = x;
                    for (var y = 0; y < height; y++)
                    {
                        cellInfo.Y = y;
                        Data[x, y] = stepFunc(cellInfo);
                    }
                }
            }
        }

        public class CellInfo
        {
            internal CellInfo(CellularAutomata<T> automata, int x, int y)
            {
                Automata = automata;
                X = x; Y = y;
            }

            private CellularAutomata<T> Automata { get; set; }
            public int X { get; internal set; }
            public int Y { get; internal set; }
            public int Width { get; private set; }
            public int Height { get; private set; }

            private T[,] data;
            internal T[,] Data { set { data = value; Width = data.GetLength(0); Height = data.GetLength(1); } }

            public T State { get { return data[X, Y]; } }
            public IEnumerable<T> GetNeighbours(int distX, int distY, bool inclusive = false)
            {
                for (var x = X - distX; x <= X + distX; x++)
                    for (var y = Y - distY; y <= Y + distY; y++)
                        if (inclusive || (Math.Abs(x - X) == distX || Math.Abs(y - Y) == distY))
                        {
                            int i = x, j = y;
                            if (i < 0)
                                if (Automata.LoopHorizontal)
                                    i += Width;
                                else
                                {
                                    yield return Automata.BoundaryState;
                                    continue;
                                }
                            else if (i >= Width)
                                if (Automata.LoopHorizontal)
                                    i -= Width;
                                else
                                {
                                    yield return Automata.BoundaryState;
                                    continue;
                                }

                            if (j < 0)
                                if (Automata.LoopVertical)
                                    j += Height;
                                else
                                {
                                    yield return Automata.BoundaryState;
                                    continue;
                                }
                            else if (j >= Height)
                                if (Automata.LoopVertical)
                                    j -= Height;
                                else
                                {
                                    yield return Automata.BoundaryState;
                                    continue;
                                }

                            yield return data[i, j];
                        }
            }

            public bool IsCorner
            {
                get
                {
                    if (X == 0)
                        return Y == 0 || Y == Height - 1;
                    else if (X == Width - 1)
                        return Y == 0 || Y == Height - 1;
                    return false;
                }
            }

            private int Distance(int x1, int y1, int x2, int y2)
            {
                return Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));
            }
        }
    }
}
