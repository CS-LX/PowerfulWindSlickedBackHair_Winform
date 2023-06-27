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
    public partial class DogWalkF : Form
    {
        Bitmap walk1;
        Bitmap walk2;
        public DogWalkF()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            walk1 = new Bitmap("Assets\\DogWalk1.png");
            walk2 = new Bitmap("Assets\\DogWalk2.png");
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            TopMost = true;
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
        public void ShowDialog(Point pos, int endF)
        {
            TopMost = true;
            Location = pos;
            Thread backSwitcher = new Thread(() =>
            {
                while (true)
                {
                    long remain = Tracker.frame % 6;
                    BackgroundImage = remain < 3 ? walk1 : walk2;
                    Thread.Sleep(8);
                }
            });
            Thread moveThread = new Thread(() =>
            {
                int f = endF;
                backSwitcher.Start();
                while (true)
                {
                    Thread.Sleep(8);
                    if (Tracker.frame > endF)
                    {
                        backSwitcher.Abort();
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
