using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Milestone_1
{
    public partial class HighScore : Form
    {
        private int Level;

        public HighScore(int Size)
        {
            InitializeComponent();

            this.Level = Size;
        }

        private void HighScore_Load(object sender, EventArgs e)
        {
            XElement root = XElement.Load("high_scores.xml");
            IEnumerable<PlayerStats> query =
                (from el in root.Elements("Play")
                let time = (long)el.Element("Time")
                let play = new PlayerStats((string)el.Element("Player"), (int)el.Element("Level"), (long)el.Element("Time"))
                orderby time
                select play).Take(5);

            List<PlayerStats> topScores = query.ToList();

            int i = 1;
            foreach(var play in topScores)
            {
                Label temp = new Label();
                temp.Text = play.Player + ": " + play.GetTimeSpan().ToString();
                temp.Location = new Point(20, 40 * i);

                this.Controls.Add(temp);

                i++;
            }
        }
    }
}
