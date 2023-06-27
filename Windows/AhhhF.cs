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
    public partial class AhhhF : Form
    {
        public AhhhF()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
        }
        public void ShowDialog(Point pos, int endFrame)
        {
            this.Location = pos;
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
            this.ShowDialog();
        }
    }
}
