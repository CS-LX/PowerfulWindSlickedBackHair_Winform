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
    public partial class BirdWaveF : Form
    {
        bool isFlip;
        Bitmap wave1;
        Bitmap wave2;
        Bitmap wave1F;
        Bitmap wave2F;
        public BirdWaveF(bool isWhite)
        {
            InitializeComponent();
            wave1 = !isWhite ? new Bitmap("Assets\\BlackBirdWave1.png") : new Bitmap("Assets\\WhiteBirdWave1.png");
            wave2 = !isWhite ? new Bitmap("Assets\\BlackBirdWave2.png") : new Bitmap("Assets\\WhiteBirdWave2.png");
            wave1F = new Bitmap(wave1);
            wave1F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            wave2F = new Bitmap(wave2);
            wave2F.RotateFlip(RotateFlipType.RotateNoneFlipX);
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
        public void ShowDialog(long endF, Point p)
        {
            Location = p;
            Thread thread = new Thread(() =>
            {
                long f = endF;

                while (true)
                {
                    long remain = Tracker.frame % 40;
                    switch (remain)
                    {
                        case long i when i < 10:
                            BackgroundImage = wave1;
                            break;
                        case long j when j >= 10 && j < 20:
                            BackgroundImage = wave2;
                            break;
                        case long k when k >= 20 && k < 30:
                            BackgroundImage = wave1F;
                            break;
                        case long l when l >= 30 && l < 40:
                            BackgroundImage = wave2F;
                            break;
                    }

                    if (Tracker.frame > endF)
                    {
                        this.Hide();
                        break;
                    }
                    Thread.Sleep(3);
                }
            });
            thread.Start();
            this.ShowDialog();
        }
    }
}
