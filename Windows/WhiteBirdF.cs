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
    public partial class WhiteBirdF : Form
    {
        Bitmap hit1;
        Bitmap hit2;
        Color backColorY;
        Color backColorB;
        public WhiteBirdF()
        {
            InitializeComponent();
            hit1 = new Bitmap("Assets\\WhiteBird1.png");
            hit2 = new Bitmap("Assets\\WhiteBird2.png");
            StartPosition = FormStartPosition.Manual;
            backColorY = Color.FromArgb(0xFED851);
            backColorY = Color.FromArgb(255, backColorY.R, backColorY.G, backColorY.B);
            BackColor = backColorY;

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
                        this.Hide();
                        break;
                    }
                    Thread.Sleep(1);
                }
            });
            moveThread.Start();
            this.ShowDialog();
        }

        private void UpdateF(long frame)
        {
            switch (frame)
            {
                case 317:
                    break;
                case 390:
                    BackColor = backColorB;
                    Hit();
                    break;
                case 467:
                    BackColor = backColorY;
                    Hit();
                    break;
                case 542:
                    BackColor = backColorB;
                    Hit();
                    break;
            }
        }

        private void Hit()
        {
            Thread hit = new Thread(() =>
            {
                BackgroundImage = hit2;
                Thread.Sleep(70);
                BackgroundImage = hit1;
            });
            hit.Start();
        }

        private void WhiteBirdF_Load(object sender, EventArgs e)
        {
            BackColor = backColorY;
            Hit();
        }
    }
}
