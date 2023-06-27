using NAudio.Wave;
using PowerfulWindSlickedBackHair.Tools;
using PowerfulWindSlickedBackHair.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair
{
    public partial class MainForm : Form
    {
        bool isCursorPressOnListView;
        Mp3FileReader reader;
        WaveOut wave;

        BackgroundForm backgroundForm;
        JumpingYukiForm yukiForm;

        int offset = 3;

        bool isSummonBackgroundForm;
        bool isSummonJumpingForm;
        bool isBWYuki = false;
        bool isFloatWindow = false;

        long lastFrame = -1;
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Rectangle rectangle = Screen.PrimaryScreen.WorkingArea;
            Location = new Point(rectangle.Width - Size.Width, rectangle.Height - Size.Height);
            if (File.Exists("Offset.txt"))
            {
                offset = int.Parse(File.ReadAllText("Offset.txt"));
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CmdHelper.ExeCommand("taskkill /im cmd.exe /f");

            //更换壁纸
            //WinTool.WallPaper.SetDesktopWallpaperBmp("Resources/RickAstley.png");
            //开始技术进程

            Thread frameTracker = Tracker.AddThread("FrameTracker", () =>
            {
                int t = 40 - offset;
                while (true)
                {
                    Tracker.frame++;
                    Thread.Sleep(t);
                }
            });


            /*
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 40;
            timer.Elapsed += delegate
            {
                Tracker.frame++;
            };
            timer.Enabled = true;
            Tracker.frame -= 10;
            */
            Thread flameUpdater = Tracker.AddThread("FrameUpdater", () =>
            {
                int t = 40 - offset;
                //播放音乐
                Stream stream = new FileStream("Assets\\Audio.mp3", FileMode.Open);
                reader = new Mp3FileReader(stream);
                wave = new WaveOut();
                wave.Init(reader);
                wave.Play();
                frameTracker.Start();
                //timer.Start();
                //Tracker.frame += (long)(((double)wave.GetPosition() / (double)wave.OutputWaveFormat.AverageBytesPerSecond) * 25);
                while (true)
                {
                    if (lastFrame == Tracker.frame) continue;
                    lastFrame = Tracker.frame;
                    frameLabel.Text = Tracker.frame.ToString();
                    Update(Tracker.frame, Screen.PrimaryScreen.WorkingArea);
                    Thread.Sleep(t / 2);
                }
            });
            Thread threadsShower = Tracker.AddThread("ThreadsShower", () =>
            {
                while (true)
                {
                    if (isCursorPressOnListView) continue;
                    threadsList.Items.Clear();
                    try
                    {
                        foreach (Thread thread in Tracker.threads)
                        {
                            try
                            {
                                string name = thread.Name;
                                bool isAlive = thread.IsAlive;
                                ListViewItem item = threadsList.Items.Add(name);
                                item.SubItems.Add(thread.ThreadState.ToString());
                                //threadsList.Items.Add(name + "\t" + thread.ThreadState);
                            }
                            catch (Exception ex) { }
                        }
                    }
                    catch (Exception ex) { }
                    Thread.Sleep(100);
                }
            });
            flameUpdater.Start();
            threadsShower.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tracker.StopAll();
            wave.Stop();
            wave.Dispose();
            CmdHelper.ExeCommand("taskkill /im PowerfulWindSlickedBackHair.exe /f");
        }

        private void Update(long f, Rectangle screen)
        {
            switch (f - offset)
            {
                case long i when i > 3 && i < 8:
                    if (!isSummonBackgroundForm)
                    {
                        Thread backgroundShower = Tracker.AddThread("BackgroundShower", () =>
                        {
                            if (backgroundForm == null)
                            {
                                this.isSummonBackgroundForm = true;
                                this.backgroundForm = new BackgroundForm();
                                this.backgroundForm.ShowDialog(new Point(screen.Width / 2 - backgroundForm.Width / 2, screen.Height / 2 - backgroundForm.Height / 2), 2864);
                            }
                        });
                        backgroundShower.Start();
                    }
                    break;
                case long i when i >= 9 && i < 14:
                    if (!isSummonJumpingForm)
                    {
                        Thread jumpingYuki = Tracker.AddThread("JumpingYuki", () =>
                        {
                            this.isSummonJumpingForm = true;
                            this.yukiForm = new JumpingYukiForm();
                            this.yukiForm.ShowDialog(new Point(screen.Width / 2 - yukiForm.Width / 2, screen.Height / 2 - yukiForm.Height / 2), 2864);
                        });

                        jumpingYuki.Start();
                        AnimalsShower.StartShow();
                    }
                    break;

                case 69:
                    ClapYukiShower.Show();
                    break;
                case 172:
                    RollingDogShower.Show(1000);
                    break;
                case 220:
                    ClapYukiShower.Show();
                    break;

                //
                case 234:
                    Thread staticYukiShower = new Thread(() =>
                    {
                        StaticYukiForm staticYuki = new StaticYukiForm();
                        staticYuki.ShowDialog(new Point(screen.Width / 2 - staticYuki.Width / 2 - 400, screen.Height / 2 - staticYuki.Height / 2), 269);
                    });
                    staticYukiShower.Start();
                    break;
                case 244:
                    Thread staticYukiShower2 = new Thread(() =>
                    {
                        StaticYukiForm staticYuki = new StaticYukiForm();
                        staticYuki.ShowDialog(new Point(screen.Width / 2 - staticYuki.Width / 2, screen.Height / 2 - staticYuki.Height / 2), 269);
                    });
                    staticYukiShower2.Start();
                    break;
                case 254:
                    Thread staticYukiShower3 = new Thread(() =>
                    {
                        StaticYukiForm staticYuki = new StaticYukiForm();
                        staticYuki.ShowDialog(new Point(screen.Width / 2 - staticYuki.Width / 2 + 400, screen.Height / 2 - staticYuki.Height / 2), 269);
                    });
                    staticYukiShower3.Start();
                    break;

                case 315:
                    Thread blackBirdShower = Tracker.AddThread("BlackBirdShower", () =>
                    {
                        BlackBirdF blackBirdF = new BlackBirdF();
                        Point c = new Point(screen.Width / 2 - blackBirdF.Width / 2, screen.Height / 2 - blackBirdF.Height);
                        blackBirdF.ShowDialog(new Point(c.X - 500, c.Y + 400), 619);
                    });
                    blackBirdShower.Start();
                    Thread whiteBirdShower = Tracker.AddThread("WhiteBirdShower", () =>
                    {
                        WhiteBirdF whiteBirdF = new WhiteBirdF();
                        Point c2 = new Point(screen.Width / 2 - whiteBirdF.Width / 2, screen.Height / 2 - whiteBirdF.Height);
                        whiteBirdF.ShowDialog(new Point(c2.X + 500, c2.Y + 400), 619);
                    });
                    whiteBirdShower.Start();
                    break;

                case 619:
                    Thread walkingYukiShower = Tracker.AddThread("WalkingYuki", () =>
                    {
                        WalkingYukiForm walkingYuki = new WalkingYukiForm();
                        walkingYuki.ShowDialog(new Point(screen.Width - walkingYuki.Width, screen.Height / 2 - walkingYuki.Height / 2), 1151, 300);
                    });
                    walkingYukiShower.Start();
                    break;
                case 811:
                    RollingDogShower.Show(1450);
                    break;
                case 990:
                    RollingDogShower.Show(1450);
                    break;

                case 1149:
                    ShowStaticPigeon(new Point(-3 * 150, 100), screen, 1184, true);
                    break;
                case 1158:
                    ShowStaticPigeon(new Point(-150, 100), screen, 1184, true);
                    break;
                case 1167:
                    ShowStaticPigeon(new Point(150, 100), screen, 1184, true);
                    break;
                case 1176:
                    ShowStaticPigeon(new Point(3 * 150, 100), screen, 1184, false);
                    break;
                case 1184:
                    Thread fightShower = new Thread(() =>
                    {
                        FightForm fightForm = new FightForm();
                        fightForm.ShowDialog(1211);
                    });
                    fightShower.Start();
                    break;

                case 1212:
                    Thread ahhhFShower = Tracker.AddThread("AhhhFShower", () =>
                    {
                        AhhhF ahhhF = new AhhhF();
                        ahhhF.ShowDialog(new Point(screen.Width / 2, screen.Height / 2 - ahhhF.Height / 2), 1226);
                    });
                    ahhhFShower.Start();
                    break;
                case 1214:
                    Thread ahhhError = Tracker.AddThread("AhhhError", () =>
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            Thread errorFShower = new Thread(() =>
                            {
                                ErrorF errorF = new ErrorF();
                                errorF.ShowDialog(new Point((screen.Width / 2 - errorF.Width / 2) - i * 40, (screen.Height / 2 - errorF.Height / 2) + i * 30), 1226);
                            });
                            errorFShower.Start();
                            Thread.Sleep(50);
                        }
                    });
                    ahhhError.Start();
                    break;

                case 1288:
                    ClapYukiShower.Show();
                    break;
                case 1391:
                    RollingDogShower.Show(1000);
                    break;
                case 1395:
                    RollingDogShower.Show(1000);
                    break;
                case 1438:
                    ClapYukiShower.Show();
                    break;
                //
                case 1452:
                    Thread staticYukiShower4 = new Thread(() =>
                    {
                        StaticYukiForm staticYuki = new StaticYukiForm();
                        staticYuki.ShowDialog(new Point(screen.Width / 2 - staticYuki.Width / 2 - 400, screen.Height / 2 - staticYuki.Height / 2), 1486);
                    });
                    staticYukiShower4.Start();
                    break;
                case 1462:
                    Thread staticYukiShower5 = new Thread(() =>
                    {
                        StaticYukiForm staticYuki = new StaticYukiForm();
                        staticYuki.ShowDialog(new Point(screen.Width / 2 - staticYuki.Width / 2, screen.Height / 2 - staticYuki.Height / 2), 1486);
                    });
                    staticYukiShower5.Start();
                    break;
                case 1472:
                    Thread staticYukiShower6 = new Thread(() =>
                    {
                        StaticYukiForm staticYuki = new StaticYukiForm();
                        staticYuki.ShowDialog(new Point(screen.Width / 2 - staticYuki.Width / 2 + 400, screen.Height / 2 - staticYuki.Height / 2), 1486);
                    });
                    staticYukiShower6.Start();
                    break;

                case 1512:
                    ClapYukiShower.Show();
                    break;

                //case 30:
                case long i when i >= 1527 && i < 1535:
                    if (!isFloatWindow)
                    {
                        Thread floatWindowHelperShower = Tracker.AddThread("FloatWindowShower", () =>
                        {
                            FloatWindowHelperF floatWindow = new FloatWindowHelperF();
                            floatWindow.ShowDialog(1684);
                        });
                        floatWindowHelperShower.Start();
                        isFloatWindow = true;
                    }
                    break;

                case 1669:
                    ClapYukiShower.Show();
                    break;

                case 1685:
                    WaveBirdShower.WaveBirdShow(screen, 1806, new Point(-480, 240), false);
                    WaveBirdShower.WaveBirdShow(screen, 1806, new Point(-320, 240), false);
                    WaveBirdShower.WaveBirdShow(screen, 1806, new Point(-160, 240), false);
                    WaveBirdShower.WaveBirdShow(screen, 1806, new Point(480, 240), true);
                    WaveBirdShower.WaveBirdShow(screen, 1806, new Point(320, 240), true);
                    WaveBirdShower.WaveBirdShow(screen, 1806, new Point(160, 240), true);
                    break;

                case 1808:
                    Thread hugeBlowShower = Tracker.AddThread("HugeBlowShower", () =>
                    {
                        HugeBlow hugeBlow = new HugeBlow();
                        hugeBlow.ShowDialog(1831);
                    });
                    hugeBlowShower.Start();
                    break;

                case long i when i >= 1830 && i < 1840:
                    if (!isBWYuki)
                    {
                        BWYukiShower.StartShow();
                        isBWYuki = true;
                    }
                    break;
                case 1880:
                    BWYukiShower.StopShow();
                    break;

                case 1896:
                    ClapYukiShower.Show();
                    break;
                case 1989:
                    RollingDogShower.Show(1000);
                    break;
                case 1993:
                    RollingDogShower.Show(1000);
                    break;
                case 1997:
                    RollingDogShower.Show(1000);
                    break;
                case 2046:
                    ClapYukiShower.Show();
                    break;
                //
                case 2061:
                    Thread staticYukiShower7 = new Thread(() =>
                    {
                        StaticYukiForm staticYuki = new StaticYukiForm();
                        staticYuki.ShowDialog(new Point(screen.Width / 2 - staticYuki.Width / 2 - 400, screen.Height / 2 - staticYuki.Height / 2), 2141);
                    });
                    staticYukiShower7.Start();
                    break;
                case 2071:
                    Thread staticYukiShower8 = new Thread(() =>
                    {
                        StaticYukiForm staticYuki = new StaticYukiForm();
                        staticYuki.ShowDialog(new Point(screen.Width / 2 - staticYuki.Width / 2, screen.Height / 2 - staticYuki.Height / 2), 2141);
                    });
                    staticYukiShower8.Start();
                    break;
                case 2081:
                    Thread staticYukiShower9 = new Thread(() =>
                    {
                        StaticYukiForm staticYuki = new StaticYukiForm();
                        staticYuki.ShowDialog(new Point(screen.Width / 2 - staticYuki.Width / 2 + 400, screen.Height / 2 - staticYuki.Height / 2), 2141);
                    });
                    staticYukiShower9.Start();
                    break;

                case 2099:
                    WaveBirdShower.WaveBirdShow(screen, 2122, new Point(-300, 240), true);
                    WaveBirdShower.WaveBirdShow(screen, 2122, new Point(-100, 240), false);
                    WaveBirdShower.WaveBirdShow(screen, 2122, new Point(100, 240), true);
                    WaveBirdShower.WaveBirdShow(screen, 2122, new Point(300, 240), false);
                    break;


                case 2198:
                    ClapYukiShower.Show();
                    break;
                case 2305:
                    RollingDogShower.Show(1000);
                    break;
                case 2309:
                    RollingDogShower.Show(1000);
                    break;
                case 2313:
                    RollingDogShower.Show(1000);
                    break;
                case 2317:
                    RollingDogShower.Show(1000);
                    break;
                case 2352:
                    ClapYukiShower.Show();
                    break;
                case 2405:
                    RollingDogShower.Show(1400);
                    break;
                //
                case 2368:
                    Thread staticYukiShower11 = new Thread(() =>
                    {
                        StaticYukiForm staticYuki = new StaticYukiForm();
                        staticYuki.ShowDialog(new Point(screen.Width / 2 - staticYuki.Width / 2 - 400, screen.Height / 2 - staticYuki.Height / 2), 2400);
                    });
                    staticYukiShower11.Start();
                    break;
                case 2378:
                    Thread staticYukiShower12 = new Thread(() =>
                    {
                        StaticYukiForm staticYuki = new StaticYukiForm();
                        staticYuki.ShowDialog(new Point(screen.Width / 2 - staticYuki.Width / 2, screen.Height / 2 - staticYuki.Height / 2), 2400);
                    });
                    staticYukiShower12.Start();
                    break;
                case 2388:
                    Thread staticYukiShower13 = new Thread(() =>
                    {
                        StaticYukiForm staticYuki = new StaticYukiForm();
                        staticYuki.ShowDialog(new Point(screen.Width / 2 - staticYuki.Width / 2 + 400, screen.Height / 2 - staticYuki.Height / 2), 2400);
                    });
                    staticYukiShower13.Start();
                    break;

                case 2439:
                    WaveBirdShower.WaveBirdShow(screen, 2485, new Point(-120 * 3, 240), false);
                    WaveBirdShower.WaveBirdShow(screen, 2485, new Point(-120 * 2, 240), true);
                    WaveBirdShower.WaveBirdShow(screen, 2485, new Point(-120 * 1, 240), false);
                    WaveBirdShower.WaveBirdShow(screen, 2485, new Point(-120 * 0, 240), true);
                    WaveBirdShower.WaveBirdShow(screen, 2485, new Point(-120 * -3, 240), false);
                    WaveBirdShower.WaveBirdShow(screen, 2485, new Point(-120 * -2, 240), true);
                    WaveBirdShower.WaveBirdShow(screen, 2485, new Point(-120 * -1, 240), false);
                    break;
                case 2508:
                    Thread likeThread = new Thread(() =>
                    {
                        LikeForm likeForm = new LikeForm();
                        likeForm.ShowDialog(2520);
                    });
                    likeThread.Start();
                    break;
            }
        }


        //鼠标是否在listView上按下
        private void threadsList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isCursorPressOnListView = true;
            }
        }

        private void threadsList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isCursorPressOnListView = false;
            }
        }

        private void ShowStaticPigeon(Point d, Rectangle screen, long endF, bool isGrey)
        {
            Thread thread = new Thread(() =>
            {
                StaticPigeonF staticPigeonF = new StaticPigeonF();
                Point c = new Point(screen.Width / 2 - staticPigeonF.Width / 2, screen.Height / 2 - staticPigeonF.Height / 2);
                staticPigeonF.ShowDialog(new Point(c.X + d.X, c.Y + d.Y), endF, isGrey);
            });
            thread.Start();
        }
    }
}
