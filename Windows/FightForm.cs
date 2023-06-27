using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
    public partial class FightForm : Form
    {
        Bitmap fight1;
        Bitmap fight2;
        Bitmap fight3;
        public FightForm()
        {
            InitializeComponent();
            fight1 = new Bitmap("Assets\\Fight1.png");
            fight2 = new Bitmap("Assets\\Fight2.png");
            fight3 = new Bitmap("Assets\\Fight3.png");
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

        public void ShowDialog(long endF)
        {
            Thread thread = new Thread(() =>
            {
                long f = endF;

                while (true)
                {
                    long r = Tracker.frame % 6;
                    BackgroundImage = r < 2 ? fight1 : (r < 4 ? fight2 : fight3);
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
