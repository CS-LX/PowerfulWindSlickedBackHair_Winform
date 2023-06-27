using PowerfulWindSlickedBackHair.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Tools
{
    public static class AnimalsShower
    {
        static Thread dogShower;
        static long lastFrame = -1;
        static bool isStarted;
        public static void StartShow()
        {
            if (isStarted) return;
            dogShower = Tracker.AddThread("DogShower", () =>
            {
                while (true)
                {
                    if (lastFrame != Tracker.frame)
                    {
                        Update(Tracker.frame, Screen.PrimaryScreen.WorkingArea);
                        lastFrame = Tracker.frame;
                    }
                    Thread.Sleep(1);
                }
            });
            dogShower.Start();
            isStarted = true;
        }

        public static void StopShow()
        {
            dogShower.Abort();
            lastFrame = -1;
            isStarted = false;
        }

        private static void Update(long f, Rectangle screen)
        {
            switch (f)
            {
                case 14:
                    Thread shower = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450, 200)), 152);
                    });
                    shower.Start();
                    Thread shower2 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(450, 200)), 152);
                    });
                    shower2.Start();
                    break;
                case 272:
                    Thread shower21 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450, 200)), 309);
                    });
                    shower21.Start();
                    Thread shower22 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 225, 200)), 309);
                    });
                    shower22.Start();
                    Thread shower23 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 225 * 2, 200)), 309);
                    });
                    shower23.Start();
                    Thread shower24 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 225 * 3, 200)), 309);
                    });
                    shower24.Start();
                    Thread shower25 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 225 * 4, 200)), 309);
                    });
                    shower25.Start();
                    break;
                case 1228:
                    Thread shower31 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450, 200)), 1388);
                    });
                    shower31.Start();
                    Thread shower32 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 225, 200)), 1371);
                    });
                    shower32.Start();

                    Thread shower33 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 225 * 3, 200)), 1371);
                    });
                    shower33.Start();
                    Thread shower34 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 225 * 4, 200)), 1388);
                    });
                    shower34.Start();
                    break;
                case 1491:
                    Thread shower41 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450, 200)), 1527);
                    });
                    shower41.Start();
                    Thread shower42 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 225, 200)), 1527);
                    });
                    shower42.Start();

                    Thread shower43 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 225 * 3, 200)), 1527);
                    });
                    shower43.Start();
                    Thread shower44 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 225 * 4, 200)), 1527);
                    });
                    shower44.Start();
                    break;
                case 1874:
                    Thread shower51 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 225, 200)), 1979);
                    });
                    shower51.Start();

                    Thread shower52 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 225 * 3, 200)), 1979);
                    });
                    shower52.Start();
                    break;
                case 2151:
                    Thread shower61 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450, 200)), 2284);
                    });
                    shower61.Start();
                    Thread.Sleep(1);
                    Thread shower62 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 112, 200)), 2284);
                    });
                    shower62.Start();
                    Thread.Sleep(1);
                    Thread shower63 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 112 * 2, 200)), 2284);
                    });
                    shower63.Start();
                    Thread.Sleep(1);
                    Thread shower66 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 112 * 6, 200)), 2284);
                    });
                    shower66.Start();
                    Thread.Sleep(1);
                    Thread shower67 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 112 * 7, 200)), 2284);
                    });
                    shower67.Start();
                    Thread.Sleep(1);
                    Thread shower68 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 112 * 8, 200)), 2284);
                    });
                    shower68.Start();
                    Thread.Sleep(1);
                    break;
                case 2217:
                    Thread shower71 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 - 112, 200)), 2284);
                    });
                    shower71.Start();
                    Thread shower72 = new Thread(() =>
                    {
                        DogWalkF dogWalk = new DogWalkF();
                        Point c = new Point(screen.Width / 2 - dogWalk.Width / 2, screen.Height / 2 - dogWalk.Height / 2);
                        dogWalk.ShowDialog(Add(c, new Point(-450 + 112 * 9, 200)), 2284);
                    });
                    shower72.Start();
                    break;
            }
        }
        static Point Add(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
    }
}