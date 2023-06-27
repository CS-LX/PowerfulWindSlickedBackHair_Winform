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
    public partial class LikeForm : Form
    {
        public LikeForm()
        {
            InitializeComponent();
        }
        public void ShowDialog(int endFrame)
        {
            Thread thread = new Thread(() =>
            {
                int f = endFrame;
                while (true)
                {
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
    }
}
