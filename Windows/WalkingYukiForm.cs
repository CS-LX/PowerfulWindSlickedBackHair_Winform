using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
    public partial class WalkingYukiForm : Form
    {
        private readonly Bitmap walk1;
        private readonly Bitmap walk2;
        private readonly Bitmap walk3;
        private readonly Bitmap walk4;

        private long startFrame;
        private long endFrame;
        private int lastPosition;

        private long sustainLength;

        private Point startLocation;

        private int walkState;

        public WalkingYukiForm()
        {
            InitializeComponent();
            walk1 = new Bitmap("Assets\\Walk1.png");
            walk2 = new Bitmap("Assets\\Walk2.png");
            walk3 = new Bitmap("Assets\\Walk3.png");
            walk4 = new Bitmap("Assets\\Walk4.png");
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }

        public new Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set
            {
                base.BackgroundImage = value;
                if (IsHandleCreated)
                {
                    BeginInvoke((MethodInvoker)delegate { base.BackgroundImage = value; });
                }
            }
        }

        public void ShowDialog(Point pos, int endF, int lastPos)
        {
            startFrame = Tracker.frame;
            endFrame = endF;
            lastPosition = lastPos;
            sustainLength = endFrame - startFrame; // 持续时间

            Location = pos;
            startLocation = Location;

            Thread moveThread = new Thread(() =>
            {
                int f = endF;

                Thread walkAnim = new Thread(() =>
                {
                    while (true)
                    {
                        walkState++;
                        int s = walkState % 4;
                        switch (s)
                        {
                            case 0:
                                BackgroundImage = walk1;
                                break;
                            case 1:
                                BackgroundImage = walk2;
                                break;
                            case 2:
                                BackgroundImage = walk3;
                                break;
                            case 3:
                                BackgroundImage = walk4;
                                break;
                        }
                        Thread.Sleep(430);
                    }
                });

                walkAnim.Start();
                while (true)
                {
                    // 窗口移动
                    double k = (double)(Tracker.frame - startFrame) / (double)(sustainLength);
                    Location = new Point((int)(startLocation.X - (k * lastPosition)), startLocation.Y);
                    if (Tracker.frame > endF)
                    {
                        walkAnim.Abort();
                        this.Hide();
                        break;
                    }
                }
            });
            moveThread.Start();
            this.ShowDialog();
        }
    }
}
