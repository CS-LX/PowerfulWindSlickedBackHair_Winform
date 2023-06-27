using PowerfulWindSlickedBackHair.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PowerfulWindSlickedBackHair.Tools
{
    public static class WaveBirdShower
    {
        public static void WaveBirdShow(Rectangle s, long f, Point dp, bool isWhite)
        {
            Thread blackShower = new Thread(() =>
            {
                BirdWaveF blackBird = new BirdWaveF(isWhite);
                Point c = new Point(s.Width / 2 - blackBird.Width / 2, s.Height / 2 - blackBird.Height / 2);
                blackBird.ShowDialog(f, new Point(c.X + dp.X, c.Y + dp.Y));
            });
            blackShower.Start();
        }
    }
}
