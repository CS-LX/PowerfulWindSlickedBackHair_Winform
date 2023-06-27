using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
    public partial class PigeonPeekF : Form
    {
        private long startFrame;
        private long endFrame;
        private Size lastPosition;

        private long sustainLength;

        private Point startLocation;

        Bitmap peek1;
        Bitmap peek2;
        public PigeonPeekF()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            peek1 = new Bitmap("Assets\\PigeonPeek.png");
            peek2 = new Bitmap("Assets\\PigeonPeek2.png");
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
        public void ShowDialog(Point pos, int endF, Size lastPos)
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

                Thread peekAnim = new Thread(() =>
                {
                    while (true)
                    {
                        long remain = Tracker.frame % 4;
                        BackgroundImage = remain < 2 ? peek1 : peek2;
                        Thread.Sleep(5);
                    }
                });

                peekAnim.Start();

                while (true)
                {
                    // 窗口移动
                    double k = (double)(Tracker.frame - startFrame) / (double)(sustainLength);
                    Location = new Point((int)(startLocation.X - 1 * lastPos.Width), (int)(startLocation.Y - F(k) * lastPos.Height));
                    //F(k);
                    if (k > 0.95f)
                    {
                        peekAnim.Abort();
                        this.Hide();
                        break;
                    }
                    Thread.Sleep(1);
                }
            });
            moveThread.Start();
            this.ShowDialog();
        }

        double F(double x)
        {
            double a = -Math.E * x * Math.Log(x);
            double b = -Math.Pow(a, 0.4);
            double c = Math.Abs(b);
            return c;
        }
    }
}
