using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_1
{
    public class Cell : System.Windows.Forms.Button
    {
        int Row = -1;
        int Column = -1;
        bool Visited = false;
        bool Live = false;
        int Neighbors = 0;

        public Cell()
        {

        }

        public Cell(int row, int col, bool visited, bool live, int neighbors)
        {
            this.Row = row;
            this.Column = col;
            this.Visited = visited;
            this.Live = live;
            this.Neighbors = neighbors;
        }

        public int GetRow()
        {
            return this.Row;
        }

        public void SetRow(int row)
        {
            this.Row = row;
        }

        public int GetColumn()
        {
            return this.Column;
        }

        public void SetColumn(int column)
        {
            this.Column = column;
        }

        public bool GetVisited()
        {
            return this.Visited;
        }

        public void SetVisited(bool visited)
        {
            this.Visited = visited;

            if(visited)
            {
                this.BackColor = System.Drawing.Color.DimGray;
            }
        }

        public bool GetLive()
        {
            return this.Live;
        }

        public void SetLive(bool live)
        {
            this.Live = live;
        }

        public int GetNeighbors()
        {
            return this.Neighbors;
        }

        public void SetNeighbors(int neighbors)
        {
            this.Neighbors = neighbors;
        }

        override public String ToString()
        {
            if(this.Live)
            {
                return "[ * ]";
            } else
            {
                return String.Format("[{0,3:000}]", this.GetNeighbors());
            }
        }

        public void MakeLive()
        {
            this.Live = true;
        }

        public String MineSweeper()
        {
            if (!this.Visited)
            {
                return "[ ? ]";
            }
            else
            {
                if(this.GetNeighbors() > 0)
                {
                    return String.Format("[{0,3:000}]", this.GetNeighbors());
                } else
                {
                    return "[ ~ }";
                }
            }
        }

        // UI Methods
        public void Reveal(bool Win)
        {
            if(this.Live)
            {
                if (Win)
                {
                    this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Flag));
                } else
                {
                    this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bomb));
                }
            } else
            {
                this.Text = this.GetNeighbors().ToString();
            }
        }

        public void ShowNeighbors()
        {
            if(this.GetNeighbors() > 0)
            {
                this.Text = this.GetNeighbors().ToString();
            }
        }
    }
}
