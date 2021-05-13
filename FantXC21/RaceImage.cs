using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FantXC21
{
    class RaceImage : System.Windows.Forms.PictureBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.  
            base.OnPaint(e);
            // Call methods of the System.Drawing.Graphics object.  

            SolidBrush whiteBrush = new SolidBrush(Color.White);

            e.Graphics.FillRectangle(whiteBrush, new Rectangle(10, 10, this.Width - 20, this.Height - 20));
        }
    }
}
