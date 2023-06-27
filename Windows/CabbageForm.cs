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
    public partial class CabbageForm : Form
    {
        Bitmap cut;
        bool isClicked;
        long startF;
        public CabbageForm()
        {
            InitializeComponent();
            cut = new Bitmap("Assets//CabbageCut.png");
            StartPosition = FormStartPosition.Manual;
        }
        public void ShowDialog(int endFrame, Point startPos)
        {
            Location = startPos;
            startF = Tracker.frame;
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

                    if (Tracker.frame > startF + 5 && !isClicked)
                    {
                        BackgroundImage = cut;
                        isClicked = true;
                    }

                    if (isClicked)
                    {
                        for (int i = (int)(Opacity * 50); i > 0; Opacity -= 0.02f)
                        {
                            Thread.Sleep(10);
                            if (Opacity < 0.05f)
                                Hide();
                        }
                        this.Hide();
                        break;
                    }
                }
            });
            thread.Start();
            this.ShowDialog();
        }
        private void CabbageForm_Click(object sender, EventArgs e)
        {
            BackgroundImage = cut;
            isClicked = true;
        }
    }
}
