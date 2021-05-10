using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FantXC21
{
    public partial class frm_title : Form
    {
        private Season season;

        public frm_title()
        {
            season = new Season();
            InitializeComponent();
            showPanel("pnl_titleScreen");
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            showWorkoutPanel();
        }

        private void showPanel(string panelName)
        {
            foreach(Control c in Controls)
            {
                if (c is Panel)
                {
                    if (c.Name == panelName) { c.Show(); }
                    else { c.Hide(); }
                }
            }
        }

        private void showWorkoutPanel()
        {
            lbl_weekInfo.Text = "Week #" + season.weekNum.ToString();
            lbl_championshipInfo.Text = (13 - season.weekNum).ToString() + " races until the championship";

            Runner player = season.runners.Where(r => r.isPlayer).FirstOrDefault();
            bar_championshipPoints.Value = player.getTotalPoints();
            
            int numTopThrees = player.getNumTopThreeFinishes();
            if (numTopThrees > 4) { numTopThrees = 4; }
            
            for (int i = 0; i < numTopThrees; i += 1)
            {
                cbl_topThreeFinishes.SetItemChecked(i, true);
            }

            showPanel("pnl_workout");
        }

        private void btn_qualificationInfo_Click(object sender, EventArgs e)
        {
            string championshipStatus = 
                "To qualify, you must meet 1 of the following benchmarks:\n"
                + "Finish in the top 3 in " + Season.numTopThreeFinishesToQualify.ToString() + " different races\n"
                + "Accumulate a total of " + Season.pointsToQualify.ToString() + " points";
            MessageBox.Show(championshipStatus);
        }
    }
}
