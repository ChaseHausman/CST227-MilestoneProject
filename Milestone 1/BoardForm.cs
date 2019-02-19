using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Milestone_1
{
    public partial class BoardForm : Form
    {
        MinesweeperGame Game;
        System.Diagnostics.Stopwatch stopWatch;

        public BoardForm(MinesweeperGame game)
        {
            InitializeComponent();

            this.Game = game;

            this.Game.ActivateCells();

            this.stopWatch = new System.Diagnostics.Stopwatch();
            this.stopWatch.Start();
        }

        private void BoardForm_Load(object sender, EventArgs e)
        {
            for(int x = 0; x < Game.Size; x++)
            {
                for(int y = 0; y < Game.Size; y++)
                {
                    Game.GameBoard[x, y].Size = new Size(55, 55);
                    Game.GameBoard[x, y].Location = new Point(x * 57, y * 57);

                    this.Controls.Add(Game.GameBoard[x, y]);

                    Game.GameBoard[x, y].Click += new EventHandler(ButtonPress_Click);
                    Game.GameBoard[x, y].MouseUp += new MouseEventHandler(ButtonPress_MouseUp);
                }
            }

            this.Size = new Size(Game.Size * 57 + 15, Game.Size * 57 + 40);
        }

        private void ButtonPress_Click(object sender, EventArgs e)
        {
            Cell ClickedButton = (Cell)sender;

            Console.WriteLine("Displaying [" + ClickedButton.GetRow() + ", " + ClickedButton.GetColumn() + "]");

            ClickedButton.BackColor = Color.DimGray;

            if (ClickedButton.GetLive())
            {
                Game.CountNeighbors();

                for (int x = 0; x < Game.Size; x++)
                {
                    for (int y = 0; y < Game.Size; y++)
                    {
                        Game.GameBoard[x, y].Reveal(false);
                    }
                }

                this.stopWatch.Stop();
                TimeSpan gameTime = this.stopWatch.Elapsed;

                string Message = String.Format("Game Over. You played for {0:00}:{1:00}:{2:00}.", gameTime.Hours, gameTime.Minutes, gameTime.Seconds);

                MessageBox.Show(Message, "Not Minesweeper");
            } else
            {
                Game.RecursiveNeighborSearch(Game.GameBoard, ClickedButton.GetRow(), ClickedButton.GetColumn());
            }

            int TotalCells = this.Game.Size ^ 2;

            for (int x = 0; x < Game.Size; x++)
            {
                for (int y = 0; y < Game.Size; y++)
                {
                    if(Game.GameBoard[x, y].GetLive() || Game.GameBoard[x, y].BackColor == Color.DimGray)
                    {
                        TotalCells--;
                    }
                }
            }

            if(TotalCells == 0)
            {
                for (int x = 0; x < Game.Size; x++)
                {
                    for (int y = 0; y < Game.Size; y++)
                    {
                        Game.GameBoard[x, y].Reveal(true);
                    }
                }

                this.stopWatch.Stop();
                TimeSpan gameTime = this.stopWatch.Elapsed;

                string Message = String.Format("Game Over. You played for {0:00}:{1:00}:{2:00}.", gameTime.Hours, gameTime.Minutes, gameTime.Seconds);

                StoreScore(gameTime);

                DisplayHighScores();

                MessageBox.Show("You Win! " + Message, "Not Minesweeper");
            }
        }

        private void StoreScore(TimeSpan time)
        {
            XDocument xml;

            try
            {
                xml = XDocument.Load("high_scores.xml");
            } catch(System.IO.FileNotFoundException)
            {
                xml = new XDocument();
                xml.Add(new XElement("Plays"));
            }

            xml.Element("Plays").Add(
                new XElement("Play", 
                    new XElement("Player", "player1"),
                    new XElement("Time", time.Ticks),
                    new XElement("Level", this.Game.Size)));

            xml.Save("high_scores.xml");
        }

        private void DisplayHighScores()
        {
            HighScore highScore = new HighScore(this.Game.Size);

            highScore.Show();
        }

        private void ButtonPress_MouseUp(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = (MouseEventArgs)e;
            Cell ClickedButton = (Cell)sender;

            Console.WriteLine("Clicked on [" + ClickedButton.GetRow() + ", " + ClickedButton.GetColumn() + "]");

            if (mouseEventArgs.Button == MouseButtons.Right)
            {
                ClickedButton.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Flag));
                return;
            }
        }
    }
}
