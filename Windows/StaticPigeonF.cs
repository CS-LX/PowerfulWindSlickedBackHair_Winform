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
    public partial class StaticPigeonF : Form
    {
        Bitmap grey;
        Bitmap white;
        public StaticPigeonF()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            grey = new Bitmap("Assets\\GreyPigeon.png");
            white = new Bitmap("Assets\\WhitePigeon.png");
        }
        public void ShowDialog(Point pos, long endF, bool isGrey)
        {

            Location = pos;
            BackgroundImage = isGrey ? grey : white;

            Thread thread = new Thread(() =>
            {
                long f = endF;

                while (true)
                {
                    if (Tracker.frame > endF)
                    {
                        this.Hide();
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
