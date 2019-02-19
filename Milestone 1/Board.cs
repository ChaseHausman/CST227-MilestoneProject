using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_1
{
    public abstract class Board
    {
        public Cell[,] GameBoard;
        public int Size;

        public Board()
        {
            GameBoard = new Cell[8, 8];
            this.Size = 8;

            for (int x = 0; x < this.Size; x++)
            {
                for (int y = 0; y < this.Size; y++)
                {
                    GameBoard[x, y] = new Cell();
                }
            }
        }

        public Board (int Size)
        {
            GameBoard = new Cell[Size, Size];
            this.Size = Size;

            for (int x = 0; x < this.Size; x++)
            {
                for (int y = 0; y < this.Size; y++)
                {
                    GameBoard[x, y] = new Cell();
                    GameBoard[x, y].SetRow(x);
                    GameBoard[x, y].SetColumn(y);
                }
            }
        }

        public void ActivateCells()
        {
            Random Generator = new Random();

            int NumberOfActive = Generator.Next(0, (int) (Size * .5)) + Size;

            for(int x = 0; x < this.Size; x++)
            {
                for(int y = 0; y < this.Size; y++)
                {
                    if(NumberOfActive > 0)
                    {
                        if(Generator.Next(0, 100) > 80)
                        {
                            GameBoard[x, y].MakeLive();

                            NumberOfActive--;
                        }                 
                    }
                }
            }
        }

        public void CountNeighbors()
        {
            for (int y = 0; y < this.Size; y++)
            {
                for (int x = 0; x < this.Size; x++)
                {
                    if(GameBoard[x, y].GetLive())
                    {
                        GameBoard[x, y].SetNeighbors(9);
                    } else
                    {
                        int Count = CountInternals(GameBoard, x, y);

                        GameBoard[x, y].SetNeighbors(Count);
                    }
                }
            }
        }

        virtual public void DisplayBoard()
        {
            for (int y = 0; y < this.Size; y++)
            {
                for (int x = 0; x < this.Size; x++)
                {
                    Console.Write(GameBoard[x, y] + " ");
                }

                Console.WriteLine();
            }
        } 

        public bool InArrayBounds(int x, int y)
        {
            return (x >= 0 && x < this.Size) && (y >= 0 && y < this.Size);
        }

        private int CountInternals(Cell[,] GameBoard, int x, int y)
        {
            // Brute force checking each neighbor...
            int Count = 0;
            // Upper Left
            int r = x - 1;
            int s = y - 1;

            if (InArrayBounds(r, s))
            {
                if (GameBoard[r, s].GetLive())
                {
                    Count++;
                }
            }

            // Upper Center
            r++;
            if (InArrayBounds(r, s))
            {
                if (GameBoard[r, s].GetLive())
                {
                    Count++;
                }
            }

            // Upper Right
            r++;
            if (InArrayBounds(r, s))
            {
                if (GameBoard[r, s].GetLive())
                {
                    Count++;
                }
            }

            // Left
            r = x - 1;
            s = y;
            if (InArrayBounds(r, s))
            {
                if (GameBoard[r, s].GetLive())
                {
                    Count++;
                }
            }

            // Right
            r++;
            r++;
            if (InArrayBounds(r, s))
            {
                if (GameBoard[r, s].GetLive())
                {
                    Count++;
                }
            }

            // Lower Left
            r = x - 1;
            s = y + 1;
            if (InArrayBounds(r, s))
            {
                if (GameBoard[r, s].GetLive())
                {
                    Count++;
                }
            }

            // Lower Center
            r++;
            if (InArrayBounds(r, s))
            {
                if (GameBoard[r, s].GetLive())
                {
                    Count++;
                }
            }

            // Lower Right
            r++;
            if (InArrayBounds(r, s))
            {
                if (GameBoard[r, s].GetLive())
                {
                    Count++;
                }
            }

            return Count;
        }

        public Cell[,] RecursiveNeighborSearch(Cell[,] GB, int x, int y)
        {
            int Count = CountInternals(GB, x, y);

            GB[x, y].SetNeighbors(Count);

            if(GB[x, y].GetVisited() || Count > 0)
            {
                GB[x, y].SetVisited(true);
                GB[x, y].BackColor = System.Drawing.Color.DimGray;
                GB[x, y].Text = GB[x, y].GetNeighbors().ToString();
                return GB;
            }

            GB[x, y].SetVisited(true);
            GB[x, y].BackColor = System.Drawing.Color.DimGray;
            Console.WriteLine("Checking " + x.ToString() + ", " + y.ToString());

            if (InArrayBounds(x - 1, y - 1))
            {
                GB = RecursiveNeighborSearch(GB, x - 1, y - 1);
            }
            if (InArrayBounds(x, y - 1))
            {
                GB = RecursiveNeighborSearch(GB, x, y - 1);
            }
            if (InArrayBounds(x + 1, y - 1))
            {
                GB = RecursiveNeighborSearch(GB, x + 1, y - 1);
            }
            if (InArrayBounds(x - 1, y))
            {
                GB = RecursiveNeighborSearch(GB, x - 1, y);
            }
            if (InArrayBounds(x + 1, y))
            {
                GB = RecursiveNeighborSearch(GB, x + 1, y);
            }
            if (InArrayBounds(x - 1, y + 1))
            {
                GB = RecursiveNeighborSearch(GB, x - 1, y + 1);
            }
            if (InArrayBounds(x, y + 1))
            {
                GB = RecursiveNeighborSearch(GB, x, y + 1);
            }
            if (InArrayBounds(x + 1, y + 1))
            {
                GB = RecursiveNeighborSearch(GB, x + 1, y + 1);
            }

            return GB;
        }
    }
}
