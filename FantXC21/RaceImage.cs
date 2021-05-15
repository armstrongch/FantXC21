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
        public void SetCourse(Course raceCourse)
        {
            this.raceCourse = raceCourse;
        }

        public void SetRunnerPositionList(List<Runner> runnerList)
        {
            Runner player = runnerList.Find(r => r.isPlayer);
            playerPosition = player.turnStartPosition;
            foreach (Runner runner in runnerList)
            {
                runnerPositionList.Add(runner.turnStartPosition);
            }
        }

        private Course raceCourse;
        private int playerPosition;
        private List<int> runnerPositionList;

        public RaceImage() : base()
        {
            runnerPositionList = new List<int>();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.  
            base.OnPaint(e);
            // Call methods of the System.Drawing.Graphics object.  

            if (!DesignMode)
            {
                SolidBrush forestGreenBrush = new SolidBrush(Color.ForestGreen);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                SolidBrush lawnGreenBrush = new SolidBrush(Color.LawnGreen);
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                Pen blackPen = new Pen(Color.Black);
                Pen redPen = new Pen(Color.Red);

                e.Graphics.FillRectangle(forestGreenBrush, new Rectangle(0, 0, this.Width, this.Height));

                int rect_pad_height = Convert.ToInt32(Math.Round(this.Height * 0.05));
                int rect_height = Convert.ToInt32(Math.Round(this.Height * 0.14));
                int segment_width = Convert.ToInt32(Math.Round((this.Width - 3 * rect_pad_height) * 0.05));

                for (int i = 0; i < 5; i += 1)
                {
                    //Padding between rectangles, (and screen edges) = 5% of rectangle height
                    //5 rectangles means 6 units of padding, 30% of screen space
                    //Rectangle Width = 14% of screen space
                    e.Graphics.FillRectangle(whiteBrush, new Rectangle(
                        rect_pad_height, rect_pad_height + i * (rect_height + rect_pad_height),
                        this.Width - 2 * rect_pad_height, rect_height)
                    );

                    if (i < 4)
                    {
                        e.Graphics.FillRectangle(whiteBrush, new Rectangle(
                            (i % 2 == 0) ? this.Width - rect_pad_height - rect_height : rect_pad_height,
                             (i + 1) * (rect_pad_height + rect_height),
                            rect_height,
                            rect_pad_height)
                        );
                    }

                    int rectangleCenterY = rect_pad_height + i * (rect_height + rect_pad_height) + rect_height / 2;

                    for (int j = 0; j < 20; j += 1)
                    {
                        int segmentDrawX = (i % 2 == 0) ? rect_pad_height * 3 / 2 + segment_width * j : this.Width - rect_pad_height * 3 / 2 - segment_width * j;
                        int segmentDrawX2 = (i % 2 == 0) ? segmentDrawX + segment_width : segmentDrawX - segment_width;

                        int halfSlopeHeightChange = rect_height / 6;
                        SegmentType segmentTypeToDraw = (i % 2 == 0) ? raceCourse.segments[i * 20 + j] : raceCourse.segments[i * 20 + 19 - j];
                        if (segmentTypeToDraw == SegmentType.FLAT)
                        {
                            e.Graphics.DrawLine(blackPen,
                                new Point(segmentDrawX, rectangleCenterY + halfSlopeHeightChange),
                                new Point(segmentDrawX2, rectangleCenterY + halfSlopeHeightChange));
                            e.Graphics.DrawLine(blackPen,
                                new Point(segmentDrawX, rectangleCenterY - halfSlopeHeightChange),
                                new Point(segmentDrawX2, rectangleCenterY - halfSlopeHeightChange));
                        }
                        else if (((segmentTypeToDraw == SegmentType.UPHILL) && (i % 2 == 0))
                            || ((segmentTypeToDraw == SegmentType.DOWNHILL) && (i % 2 == 1)))
                        {
                            e.Graphics.DrawLine(blackPen,
                                    new Point(segmentDrawX, rectangleCenterY + halfSlopeHeightChange),
                                    new Point(segmentDrawX2, rectangleCenterY - halfSlopeHeightChange));
                        }
                        else if (((segmentTypeToDraw == SegmentType.DOWNHILL) && (i % 2 == 0))
                            || ((segmentTypeToDraw == SegmentType.UPHILL) && (i % 2 == 1)))
                        {
                            e.Graphics.DrawLine(blackPen,
                                    new Point(segmentDrawX, rectangleCenterY - halfSlopeHeightChange),
                                    new Point(segmentDrawX2, rectangleCenterY + halfSlopeHeightChange));
                        }
                        else if (segmentTypeToDraw == SegmentType.ROUGH)
                        {
                            e.Graphics.DrawLine(blackPen,
                                    new Point(segmentDrawX, rectangleCenterY + halfSlopeHeightChange),
                                    new Point(segmentDrawX2, rectangleCenterY - halfSlopeHeightChange));
                            e.Graphics.DrawLine(blackPen,
                                    new Point(segmentDrawX, rectangleCenterY - halfSlopeHeightChange),
                                    new Point(segmentDrawX2, rectangleCenterY + halfSlopeHeightChange));
                        }

                    }

                    int courseLength = this.Width - 3 * rect_pad_height;
                    int runnerSize = segment_width * 8 / 10;

                    foreach (int position in runnerPositionList.Where(r => r >= i * 200 && r < (i + 1) * 200))
                    {
                        int runnerXPosition = (i % 2 == 0)
                            ? Convert.ToInt32(Math.Round(rect_pad_height * 1.5 + ((position % 200) / 200) * courseLength))
                            : Convert.ToInt32(Math.Round(this.Width - rect_pad_height * 1.5 - ((position % 200) / 200) * courseLength));

                        Pen runnerPen = position == playerPosition ? redPen : blackPen;

                        e.Graphics.DrawEllipse(runnerPen, new Rectangle(
                            runnerXPosition - runnerSize / 2,
                            rectangleCenterY - runnerSize / 2,
                            runnerSize,
                            runnerSize));
                    }
                }
            }
        }
    }
}