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
    public partial class BlackBirdF : Form
    {
        Bitmap b1;
        Bitmap b2;
        Color backColorY;
        Color backColorB;

        long[] hitF = new long[] { 7, 11, 20, 28, 34, 45, 50, 59, 67, 73 };
        long startHitF;

        Thread hitThread;
        public BlackBirdF()
        {
            InitializeComponent();
            b1 = new Bitmap("Assets\\BlackBird1.png");
            b2 = new Bitmap("Assets\\BlackBird2.png");
            pictureBox1.BackgroundImage = b1;
            StartPosition = FormStartPosition.Manual;
            backColorY = Color.FromArgb(0xFED851);
            backColorY = Color.FromArgb(255, backColorY.R, backColorY.G, backColorY.B);
            pictureBox1.BackColor = backColorY;

            backColorB = Color.FromArgb(0x62BFF7);
            backColorB = Color.FromArgb(255, backColorB.R, backColorB.G, backColorB.B);
        }
        public void ShowDialog(Point pos, int endF)
        {

            Location = pos;

            Thread moveThread = new Thread(() =>
            {
                int f = endF;

                while (true)
                {
                    UpdateF(Tracker.frame);
                    if (Tracker.frame > endF)
                    {
                        hitThread.Abort();
                        this.Hide();
                        break;
                    }
                    Thread.Sleep(1);
                }
            });
            moveThread.Start();
            this.ShowDialog();
        }
        private void UpdateF(long f)
        {
            switch (f)
            {
                case 319:
                    pictureBox1.BackColor = backColorY;
                    Hit(-4);
                    break;
                case 390:
                    pictureBox1.BackColor = backColorB;
                    Hit(0);
                    break;
                case 467:
                    pictureBox1.BackColor = backColorY;
                    Hit(0);
                    break;
                case 542:
                    pictureBox1.BackColor = backColorB;
                    Hit(0);
                    break;
            }
        }

        private void Hit(int offset)
        {
            if (hitThread != null)
            {
                if (hitThread.ThreadState == System.Threading.ThreadState.Running)
                {
                    hitThread.Abort();
                }
            }
            hitThread = new Thread(() =>
            {
                startHitF = Tracker.frame;
                int hitIndex = 0;
                while (hitIndex < 10)
                {
                    if (Tracker.frame == startHitF + hitF[hitIndex] + offset)
                    {
                        pictureBox1.BackgroundImage = b2;
                        Console.WriteLine(hitF[hitIndex]);
                        hitIndex++;
                        Thread.Sleep(50);
                        pictureBox1.BackgroundImage = b1;
                    }
                    Thread.Sleep(5);
                }
            });
            hitThread.Start();
        }
    }
}
