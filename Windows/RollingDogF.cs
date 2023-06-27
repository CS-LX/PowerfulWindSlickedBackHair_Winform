using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
    public partial class RollingDogF : Form
    {
        Bitmap dogWalk1;
        Bitmap dogWalk2;
        Bitmap dogRolling;

        long switchF;

        private long startFrame;
        private long endFrame;
        private int lastPosition;

        private long sustainLength;

        private Point startLocation;
        private bool isShowMsg;

        public RollingDogF()
        {
            InitializeComponent();
            dogRolling = new Bitmap("Assets\\RollingDog.png");
            dogWalk1 = new Bitmap("Assets\\DogWalk1.png");
            dogWalk2 = new Bitmap("Assets\\DogWalk2.png");
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            TopMost = true;
            StartPosition = FormStartPosition.Manual;

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

        public void ShowDialog(Point pos, long endF, int lastPos, bool isShowMsg)
        {
            startFrame = Tracker.frame;
            endFrame = endF;
            lastPosition = lastPos;
            sustainLength = endFrame - startFrame; // 持续时间
            startLocation = pos;
            Location = pos;
            this.isShowMsg = isShowMsg;
            switchF = endF - 30;

            Thread thread = new Thread(() =>
            {
                long f = endF;
                //走动动画
                Thread animThread = new Thread(() =>
                {
                    while (true)
                    {
                        if (Tracker.frame < switchF)
                        {
                            long remain = Tracker.frame % 6;
                            BackgroundImage = remain < 3 ? dogWalk1 : dogWalk2;
                        }
                        else
                        {
                            if (this.isShowMsg)
                            {
                                NotifyIcon notifyIcon = new NotifyIcon();
                                notifyIcon.Visible = true;
                                notifyIcon.BalloonTipText = "风力实在是太强了！\r\n我整条狗都快被吹飞了！";
                                notifyIcon.Icon = new Icon("Assets\\Cross.ico");
                                notifyIcon.ShowBalloonTip(1000, "风力实在是太强了！", "我整条狗都快被吹飞了！", ToolTipIcon.Warning);
                                this.isShowMsg = false;
                            }
                            //if (Tracker.frame % 6 == 1)
                            //{
                            Bitmap bitmap = new Bitmap(dogRolling);
                            bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            dogRolling = bitmap;
                            BackgroundImage = bitmap;
                            Thread.Sleep(100);
                            //}
                        }
                        Thread.Sleep(8);
                    }
                });
                animThread.Start();
                while (true)
                {
                    double k = (double)(Tracker.frame - startFrame) / (double)(sustainLength);
                    Location = new Point((int)(startLocation.X + (k * lastPosition)), startLocation.Y);
                    if (Tracker.frame > endF)
                    {
                        this.Hide();
                        animThread.Abort();
                        break;
                    }
                    Thread.Sleep(1);
                }
            });
            thread.Start();
            this.ShowDialog();
        }
    }
}
