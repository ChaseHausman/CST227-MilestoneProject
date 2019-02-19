using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone_1
{
    public partial class ComplexityForm : Form
    {
        private int setting;

        public ComplexityForm()
        {
            InitializeComponent();
        }

        public int GetSetting()
        {
            return setting;
        }

        private void LowComplexity_CheckedChanged(object sender, EventArgs e)
        {
            setting = 5;
            PlayButton.Enabled = true;
        }

        private void MedComplexity_CheckedChanged(object sender, EventArgs e)
        {
            setting = 8;
            PlayButton.Enabled = true;
        }

        private void HighComplexity_CheckedChanged(object sender, EventArgs e)
        {
            setting = 12;
            PlayButton.Enabled = true;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {

        }
    }
}
