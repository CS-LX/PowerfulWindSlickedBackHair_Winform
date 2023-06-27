using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
    public partial class StaticYukiForm : Form
    {
        Bitmap upNor;
        Bitmap downNor;
        public StaticYukiForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            upNor = new Bitmap("Assets\\JumpUp.png");
            downNor = new Bitmap("Assets\\JumpDown.png");
        }
        public void ShowDialog(Point pos, int endFrame)
        {
            this.Location = pos;

            Thread thread = new Thread(() =>
            {
                Thread backGroundChanger = new Thread(() =>
                {
                    while (true)
                    {
                        BackgroundImage = ((int)(Tracker.frame / 8) % 2 == 1) ? upNor : downNor;
                        Thread.Sleep(10);
                    }
                });
                backGroundChanger.Start();
                int f = endFrame;
                while (true)
                {
                    if (Tracker.frame > endFrame)
                    {
                        this.Hide();
                        backGroundChanger.Abort();
                        break;
                    }
                }
            });
            thread.Start();
            //SystemSounds.Exclamation.Play();
            this.ShowDialog();
        }
    }
}
