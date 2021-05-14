﻿using System;
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
        public void SetCourse(Course raceCourse)
        {
            this.raceCourse = raceCourse;
        }

        private Course raceCourse;

        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.  
            base.OnPaint(e);
            // Call methods of the System.Drawing.Graphics object.  

            SolidBrush forestGreenBrush = new SolidBrush(Color.ForestGreen);
            SolidBrush lawnGreenBrush = new SolidBrush(Color.LawnGreen);

            e.Graphics.FillRectangle(forestGreenBrush, new Rectangle(0, 0, this.Width, this.Height));

            int rect_pad_height = Convert.ToInt32(Math.Round(this.Height * 0.05));
            int rect_height = Convert.ToInt32(Math.Round(this.Height * 0.14));

            for (int i = 0; i < 5; i += 1)
            {
                //Padding between rectangles, (and screen edges) = 5% of rectangle height
                //5 rectangles means 6 units of padding, 30% of screen space
                //Rectangle Width = 14% of screen space
                e.Graphics.FillRectangle(lawnGreenBrush, new Rectangle(
                    rect_pad_height, rect_pad_height + i * (rect_height + rect_pad_height),
                    this.Width - 2*rect_pad_height, rect_height)
                );
                
                if (i < 4)
                {
                    e.Graphics.FillRectangle(lawnGreenBrush, new Rectangle(
                        (i%2 == 0) ? this.Width - rect_pad_height - rect_height : rect_pad_height,
                         (i + 1) * (rect_pad_height + rect_height),
                        rect_height,
                        rect_pad_height)
                    );
                }

                if (raceCourse != null)
                {
                    //test
                }
            }
        }
    }
}