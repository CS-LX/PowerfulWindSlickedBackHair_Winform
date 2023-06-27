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
    public static class BWYukiShower
    {
        static Thread yukiShower;
        static long lastFrame = -1;
        static int maxMove = 400;
        public static void StartShow()
        {
            yukiShower = Tracker.AddThread("BWYukiShower", () =>
            {
                while (true)
                {
                    if (lastFrame != Tracker.frame)
                    {
                        Update(Tracker.frame, Screen.PrimaryScreen.WorkingArea);
                        lastFrame = Tracker.frame;
                    }
                    Thread.Sleep(3);
                }
            });
            yukiShower.Start();
        }

        public static void StopShow()
        {
            yukiShower.Abort();
            lastFrame = -1;
        }
        static void Update(long f, Rectangle screen)
        {
            switch (f)
            {
                case 1833:
                    Thread t1 = new Thread(() =>
                    {
                        float index = 0;
                        BWYukiForm bWYuki = new BWYukiForm();
                        Point c = new Point((screen.Width / 2 - bWYuki.Width / 2) + 400, screen.Height / 2 - bWYuki.Height / 2);
                        bWYuki.ShowDialog(Add(c, new Point((int)(index * maxMove), (int)(Math.Sin(index * Math.PI * 2) * 40))), 1873);
                    });
                    t1.Start();
                    break;
                case 1840:
                    Thread t11 = new Thread(() =>
                    {
                        float index = 1f / 6f;
                        BWYukiForm bWYuki = new BWYukiForm();
                        Point c = new Point((screen.Width / 2 - bWYuki.Width / 2) + 400, screen.Height / 2 - bWYuki.Height / 2);
                        bWYuki.ShowDialog(Add(c, new Point((int)(index * maxMove), (int)(Math.Sin(index * Math.PI * 2) * 40))), 1873);
                    });
                    t11.Start();
                    break;
                case 1844:
                    Thread t111 = new Thread(() =>
                    {
                        float index = 2f / 6f;
                        BWYukiForm bWYuki = new BWYukiForm();
                        Point c = new Point((screen.Width / 2 - bWYuki.Width / 2) + 400, screen.Height / 2 - bWYuki.Height / 2);
                        bWYuki.ShowDialog(Add(c, new Point((int)(index * maxMove), (int)(Math.Sin(index * Math.PI * 2) * 40))), 1873);
                    });
                    t111.Start();
                    break;
                case 1848:
                    Thread t1111 = new Thread(() =>
                    {
                        float index = 3f / 6f;
                        BWYukiForm bWYuki = new BWYukiForm();
                        Point c = new Point((screen.Width / 2 - bWYuki.Width / 2) + 400, screen.Height / 2 - bWYuki.Height / 2);
                        bWYuki.ShowDialog(Add(c, new Point((int)(index * maxMove), (int)(Math.Sin(index * Math.PI * 2) * 40))), 1873);
                    });
                    t1111.Start();
                    break;
                case 1852:
                    Thread t11111 = new Thread(() =>
                    {
                        float index = 4f / 6f;
                        BWYukiForm bWYuki = new BWYukiForm();
                        Point c = new Point((screen.Width / 2 - bWYuki.Width / 2) + 400, screen.Height / 2 - bWYuki.Height / 2);
                        bWYuki.ShowDialog(Add(c, new Point((int)(index * maxMove), (int)(Math.Sin(index * Math.PI * 2) * 40))), 1873);
                    });
                    t11111.Start();
                    break;
                case 1858:
                    Thread t111111 = new Thread(() =>
                    {
                        float index = 5f / 6f;
                        BWYukiForm bWYuki = new BWYukiForm();
                        Point c = new Point((screen.Width / 2 - bWYuki.Width / 2) + 400, screen.Height / 2 - bWYuki.Height / 2);
                        bWYuki.ShowDialog(Add(c, new Point((int)(index * maxMove), (int)(Math.Sin(index * Math.PI * 2) * 40))), 1873);
                    });
                    t111111.Start();
                    break;
                case 1862:
                    Thread t1111111 = new Thread(() =>
                    {
                        float index = 1;
                        BWYukiForm bWYuki = new BWYukiForm();
                        Point c = new Point((screen.Width / 2 - bWYuki.Width / 2) + 400, screen.Height / 2 - bWYuki.Height / 2);
                        bWYuki.ShowDialog(Add(c, new Point((int)(index * maxMove), (int)(Math.Sin(index * Math.PI * 2) * 40))), 1873);
                    });
                    t1111111.Start();
                    break;
            }
        }

        static Point Add(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
    }
}
