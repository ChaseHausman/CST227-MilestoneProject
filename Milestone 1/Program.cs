using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();

            // We'll first prompt for the complexity level.
            ComplexityForm complexity = new ComplexityForm();
            complexity.ShowDialog();

            int Size = complexity.GetSetting();

            Console.WriteLine(Size);

            MinesweeperGame Game = new MinesweeperGame(Size);

            BoardForm boardForm = new BoardForm(Game);

            Application.Run(boardForm);

            //Game.playGame();
        }
    }
}
