using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_1
{
    public class MinesweeperGame : Board, IPlayable
    {
        public MinesweeperGame(int Size) : base(Size)
        {
        }

        public void playGame()
        {
            bool Playing = true;

            this.ActivateCells();

            this.CountNeighbors();

            while(Playing)
            {
                this.DisplayBoard();

                Console.WriteLine("Choose a spot please.");

                int[] cells = GetCellFromString(Console.ReadLine());

                if (!InArrayBounds(cells[0], cells[1]))
                {
                    Console.WriteLine("That is not a valid cell to visit.");
                    continue;
                }

                Cell current = GameBoard[cells[0], cells[1]];

                if(current.GetLive())
                {
                    Console.Clear();
                    Console.WriteLine("Game Over!");
                    base.DisplayBoard();
                    Playing = false;
                } else
                {
                    //GameBoard[cells[0], cells[1]].SetVisited(true);
                    RecursiveNeighborSearch(GameBoard, cells[0], cells[1]);
                }
            }
        }

        override public void DisplayBoard()
        {
            Console.Clear();

            for (int y = 0; y < this.Size; y++)
            {
                for (int x = 0; x < this.Size; x++)
                {
                    Console.Write(GameBoard[x, y].MineSweeper() + " ");
                }

                Console.WriteLine();
            }
        }

        private int[] GetCellFromString(String text)
        {
            char[] deliniators = { ',', '.' };
            String[] cells = text.Split(deliniators);

            if(cells.Length != 2)
            {
                return new int[] { 0, 0 };
            }

            return new int[]
            {
                Convert.ToInt16(cells[0]) - 1,
                this.Size - Convert.ToInt16(cells[1])
            };
        }
    }
}
