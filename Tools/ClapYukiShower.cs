using PowerfulWindSlickedBackHair.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Tools
{
    public static class ClapYukiShower
    {
        public static void Show()
        {
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            Thread clapYuki = new Thread(() =>
            {
                YukiClapF yukiClapF = new YukiClapF();
                yukiClapF.ShowDialog(new Point(screen.Width, screen.Height), (int)(Tracker.frame + 18), yukiClapF.Size);
            });
            clapYuki.Start();
            Thread peekPigeon = new Thread(() =>
            {
                PigeonPeekF peekF = new PigeonPeekF();
                peekF.ShowDialog(new Point(peekF.Width, screen.Height), (int)(Tracker.frame + 18), peekF.Size);
            });
            peekPigeon.Start();
        }
    }
}
