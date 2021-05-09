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
            pnl_titleScreen.Show();
            pnl_workout.Hide();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            pnl_titleScreen.Hide();
            pnl_workout.Show();
        }
    }
}
