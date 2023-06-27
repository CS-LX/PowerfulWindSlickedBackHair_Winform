using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
    public partial class FloatWindowHelperF : Form
    {
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        FloatYukiWindow yukiWindow;
        Point cursorP = new Point();
        long lastFlame;
        Rectangle screen;
        public FloatWindowHelperF()
        {
            InitializeComponent();
            yukiWindow = new FloatYukiWindow();
            yukiWindow.TopMost = true;
            screen = Screen.PrimaryScreen.WorkingArea;
        }
        public void ShowDialog(int endFrame)
        {
            yukiWindow.Show();

            Thread thread = new Thread(() =>
            {
                int f = endFrame;
                while (true)
                {
                    GetCursorPos(ref cursorP);
                    yukiWindow.Location = new Point(cursorP.X + 8, Cursor.Position.Y - yukiWindow.Height / 2);
                    yukiWindow.TopMost = true;
                    if (lastFlame != Tracker.frame)
                    {
                        lastFlame = Tracker.frame;
                        UpdateFlame(Tracker.frame);
                    }
                    if (Tracker.frame > endFrame)
                    {
                        this.Hide();
                        yukiWindow.Close();
                        break;
                    }
                    Thread.Sleep(3);
                }
            });
            thread.Start();
            this.ShowDialog();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.None && this.ClientRectangle.Contains(e.Location))
            {
                yukiWindow.Location = new Point(Cursor.Position.X + 16, Cursor.Position.Y - yukiWindow.Height / 2);
            }
        }

        void UpdateFlame(long f)
        {
            switch (f)
            {
                case 1535:
                    Thread thread = new Thread(() =>
                    {
                        CabbageForm cabbageForm = new CabbageForm();
                        cabbageForm.ShowDialog(1685, Center(screen, new Rectangle(Point.Empty, cabbageForm.Size)));
                    });
                    thread.Start();
                    break;
                case 1567:
                    Thread threadB = new Thread(() =>
                    {
                        CabbageForm cabbageForm = new CabbageForm();
                        cabbageForm.ShowDialog(1685, Center(screen, new Rectangle(Point.Empty, cabbageForm.Size)));
                    });
                    threadB.Start();
                    break;


                case 1604:
                    Thread threadB1 = new Thread(() =>
                    {
                        CabbageForm cabbageForm = new CabbageForm();
                        Point p = Center(screen, new Rectangle(Point.Empty, cabbageForm.Size));
                        cabbageForm.ShowDialog(1685, new Point(p.X - 180, p.Y));
                    });
                    threadB1.Start();
                    break;
                case 1614:
                    Thread threadB2 = new Thread(() =>
                    {
                        CabbageForm cabbageForm = new CabbageForm();
                        Point p = Center(screen, new Rectangle(Point.Empty, cabbageForm.Size));
                        cabbageForm.ShowDialog(1685, new Point((int)(p.X - 60), p.Y));
                    });
                    threadB2.Start();
                    break;
                case 1624:
                    Thread threadB3 = new Thread(() =>
                    {
                        CabbageForm cabbageForm = new CabbageForm();
                        Point p = Center(screen, new Rectangle(Point.Empty, cabbageForm.Size));
                        cabbageForm.ShowDialog(1685, new Point((int)(p.X + 60), p.Y));
                    });
                    threadB3.Start();
                    break;
                case 1634:
                    Thread threadB4 = new Thread(() =>
                    {
                        CabbageForm cabbageForm = new CabbageForm();
                        Point p = Center(screen, new Rectangle(Point.Empty, cabbageForm.Size));
                        cabbageForm.ShowDialog(1685, new Point((int)(p.X + 180), p.Y));
                    });
                    threadB4.Start();
                    break;

                case 1640:
                    Thread threadC1 = new Thread(() =>
                    {
                        CabbageForm cabbageForm = new CabbageForm();
                        Point p = Center(screen, new Rectangle(Point.Empty, cabbageForm.Size));
                        cabbageForm.ShowDialog(1685, p);
                    });
                    threadC1.Start();
                    break;
                case 1650:
                    Thread threadC2 = new Thread(() =>
                    {
                        CabbageForm cabbageForm = new CabbageForm();
                        Point p = Center(screen, new Rectangle(Point.Empty, cabbageForm.Size));
                        cabbageForm.ShowDialog(1685, new Point(p.X - 180, p.Y));
                    });
                    threadC2.Start();
                    break;
                case 1660:
                    Thread threadC3 = new Thread(() =>
                    {
                        CabbageForm cabbageForm = new CabbageForm();
                        Point p = Center(screen, new Rectangle(Point.Empty, cabbageForm.Size));
                        cabbageForm.ShowDialog(1685, new Point(p.X + 180, p.Y));
                    });
                    threadC3.Start();
                    break;
                case 1670:
                    Thread threadC4 = new Thread(() =>
                    {
                        CabbageForm cabbageForm = new CabbageForm();
                        Point p = Center(screen, new Rectangle(Point.Empty, cabbageForm.Size));
                        cabbageForm.ShowDialog(1685, p);
                    });
                    threadC4.Start();
                    break;
            }
        }

        Point Center(Rectangle big, Rectangle small)
        {
            return new Point(big.Width / 2 - small.Width / 2, big.Height / 2 - small.Height / 2);
        }
    }
}
