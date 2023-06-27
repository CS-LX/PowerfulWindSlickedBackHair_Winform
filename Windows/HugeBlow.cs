using PowerfulWindSlickedBackHair.Tools;
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
    public partial class HugeBlow : Form
    {
        Bitmap blow2;
        Point startLoc;
        public HugeBlow()
        {
            InitializeComponent();
            blow2 = new Bitmap("Assets//HugeBlow2.png");
            StartPosition = FormStartPosition.CenterScreen;
        }

        public void ShowDialog(int endFrame)
        {
            Thread thread = new Thread(() =>
            {
                int f = endFrame;
                while (true)
                {
                    if (Tracker.frame == 1820)
                    {
                        BackgroundImage = blow2;
                    }
                    int x = (int)((PerlinNoise.Noise((float)Tracker.frame / 2, (float)Tracker.frame / 2 + 200f, 0) - 0.5f) * 80);
                    int y = (int)((PerlinNoise.Noise((float)Tracker.frame / 2 + 400f, (float)Tracker.frame / 2 + 510f, 0) - 0.5f) * 80);
                    Location = new Point(x + startLoc.X, y + startLoc.Y);
                    if (Tracker.frame > endFrame)
                    {
                        this.Hide();
                        break;
                    }
                }
            });
            thread.Start();
            TopMost = true;
            this.ShowDialog();
        }

        private void HugeBlow_Load(object sender, EventArgs e)
        {
            startLoc = Location;
        }
    }
}
