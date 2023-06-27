using PowerfulWindSlickedBackHair.Windows;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Tools
{
    public static class RollingDogShower
    {
        public static void Show(int lastPos)
        {
            Thread thread = new Thread(() =>
            {
                Rectangle rectangle = Screen.PrimaryScreen.WorkingArea;
                RollingDogF rollingDogF = new RollingDogF();
                Point l = new Point(rectangle.Width / 2 - rollingDogF.Width / 2 - 300, rectangle.Height - rollingDogF.Height - 30);

                rollingDogF.ShowDialog(l, Tracker.frame + 58, lastPos, lastPos > 1000);
            });
            thread.Start();
        }
    }
}
