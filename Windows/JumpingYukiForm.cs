using PowerfulWindSlickedBackHair.Tools;
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
    public partial class JumpingYukiForm : Form
    {
        Bitmap upNor;
        Bitmap downNor;
        Bitmap upBlw;
        Bitmap downBlw;
        Bitmap upBluNor;
        Bitmap downBluNor;
        Bitmap upBluBlw;
        Bitmap downBluBlw;
        Point startLoc;

        //属性
        float jumpSpace = 1;
        float jumpHeight = 1;
        bool canJump = true;
        YukiState state;
        YukiState YukiState
        {
            get => state;
            set
            {
                state = value;
                //SwitchBackground(value);
            }

        }

        Thread yukiJumper;
        ThreadStart yukiMoveToRight;

        int lastP = -1;


        public JumpingYukiForm()
        {
            InitializeComponent();
            upNor = new Bitmap("Assets\\JumpUp.png");
            downNor = new Bitmap("Assets\\JumpDown.png");
            upBlw = new Bitmap("Assets\\JumpUpBlow.png");
            downBlw = new Bitmap("Assets\\JumpDownBlow.png");
            upBluBlw = new Bitmap("Assets\\JumpUpBlowBlue.png");
            downBluBlw = new Bitmap("Assets\\JumpDownBlowBlue.png");
            StartPosition = FormStartPosition.Manual;
            YukiState = YukiState.YellowNormal;

            yukiMoveToRight = delegate
            {

                canJump = false;

                long sustainF = 70;
                long startF = Tracker.frame;
                long endF = Tracker.frame + sustainF;

                while (Location.X - startLoc.X < 950)
                {
                    double k = (double)(Tracker.frame - startF) / (double)(sustainF);
                    lastP = Math.Max(lastP, (int)(startLoc.X + k * 1000));
                    Location = new Point(lastP, startLoc.Y);
                    Thread.Sleep(1);
                };

                canJump = true;
                lastP = -1;
                while (Location != startLoc)
                {
                    Location = startLoc;
                }


                /*
                int s = 0;
                canJump = false;
                while (s < 1000)
                {
                    s += 4;
                    Location = new Point(startLoc.X + s, Location.Y);
                    Thread.Sleep(2);
                }
                canJump = true;
                while (Location != startLoc)
                {
                    Location = startLoc;
                }
                */
            };
        }

        public void ShowDialog(Point pos, int endFrame)
        {
            this.Location = pos;
            yukiJumper = Tracker.AddThread("YukiJumper", () =>
            {
                for (int i = 0; i < 1024; i++)
                {
                    //切换背景
                    Thread bitmapSwitcher = new Thread(() =>
                    {
                        SwitchBackgroundSecondly();
                    });
                    //窗口跳动
                    Thread jumper = new Thread(() =>
                    {
                        float startY = Location.Y;
                        float fl = 0;
                        while (fl < 0.4f)
                        {
                            if (canJump)
                            {
                                fl += 0.02f + 0.08f * (1 - jumpSpace);
                                Point p = new Point(Location.X, (int)(startY + (jumpHeight * 200) * fl * Math.Log(fl * 2.5)));
                                //Point p = new Point(Location.X, (int)(startY + fl * 10));
                                Location = p;
                                //Console.WriteLine($"{startY} + 10 * {fl} * {Math.Log(fl)} p:{p}");
                                Thread.Sleep(1);
                            }
                        }
                    });
                    bitmapSwitcher.Start();
                    if (canJump) jumper.Start();
                    Thread.Sleep((int)(431 * jumpSpace));
                }
            });
            Thread thread = new Thread(() =>
            {
                int f = endFrame;
                yukiJumper.Start();
                while (true)
                {
                    UpdateF(Tracker.frame);
                    if (Tracker.frame > endFrame)
                    {
                        this.Hide();
                        yukiJumper.Abort();
                        break;
                    }
                }
            });
            thread.Start();
            this.ShowDialog();
        }

        void UpdateF(long f)
        {
            switch (f)
            {
                case 153:
                    Opacity = 0;
                    break;
                case 172:
                    jumpSpace = 0.4f;
                    Opacity = 1;
                    jumpHeight = 0;
                    Thread yukiMove = new Thread(yukiMoveToRight);
                    yukiMove.Start();
                    break;
                case 235:
                    Opacity = 0;
                    jumpSpace = 1;
                    jumpHeight = 1;
                    Location = startLoc;
                    break;
                case 315:
                    YukiState = YukiState.YellowBlow;
                    Opacity = 1;
                    break;
                case 390:
                    YukiState = YukiState.BlueBlow;
                    break;
                case 467:
                    YukiState = YukiState.YellowBlow;
                    break;
                case 542:
                    YukiState = YukiState.BlueBlow;
                    break;
                case 619:
                    Opacity = 0;
                    YukiState = YukiState.YellowNormal;
                    break;
                case 1228:
                    YukiState = YukiState.YellowNormal;
                    Opacity = 1;
                    break;
                case 1371:
                    Opacity = 0;
                    break;
                case 1392:
                    jumpSpace = 0.4f;
                    Opacity = 1;
                    jumpHeight = 0;
                    Thread yukiMove2 = new Thread(yukiMoveToRight);
                    yukiMove2.Start();
                    break;
                case 1454:
                    Opacity = 0;
                    jumpSpace = 1;
                    Location = startLoc;
                    jumpHeight = 1;
                    break;
                case 1685:
                    YukiState = YukiState.YellowBlow;
                    Opacity = 1;
                    break;
                case 1811:
                    Opacity = 0;
                    break;
                case 1874:
                    YukiState = YukiState.YellowNormal;
                    Opacity = 1;
                    break;
                case 1979:
                    Opacity = 0;
                    break;
                case 1998:
                    jumpSpace = 0.4f;
                    Opacity = 1;
                    jumpHeight = 0;
                    Thread yukiMove3 = new Thread(yukiMoveToRight);
                    yukiMove3.Start();
                    break;
                case 2062:
                    Opacity = 0;
                    jumpSpace = 1;
                    Location = startLoc;
                    jumpHeight = 1;
                    break;
                case 2151:
                    Opacity = 1;
                    break;
                case 2284:
                    Opacity = 0;
                    break;
                case 2304:
                    jumpSpace = 0.4f;
                    Opacity = 1;
                    jumpHeight = 0;
                    Thread yukiMove4 = new Thread(yukiMoveToRight);
                    yukiMove4.Start();
                    break;
                case 2369:
                    Opacity = 0;
                    Location = startLoc;
                    jumpSpace = 1;
                    jumpHeight = 1;
                    break;
                case 2523:
                    YukiState = YukiState.YellowBlow;
                    Opacity = 1;
                    break;
                case 2817:
                    Opacity = 0;
                    break;
            }
        }

        private void JumpingYukiForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
            TopLevel = true;
            startLoc = Location;
        }

        void SwitchBackgroundSecondly()
        {
            switch (YukiState)
            {
                case YukiState.YellowNormal:
                    BackgroundImage = BackgroundImage == upNor ? downNor : upNor;
                    break;
                case YukiState.YellowBlow:
                    BackgroundImage = BackgroundImage == upBlw ? downBlw : upBlw;
                    break;
                case YukiState.BlueNormal:
                    BackgroundImage = BackgroundImage == upBluNor ? downBluNor : upBluNor;
                    break;
                case YukiState.BlueBlow:
                    BackgroundImage = BackgroundImage == upBluBlw ? downBluBlw : upBluBlw;
                    break;
            }
        }
        /*
        void SwitchBackground(YukiState yukiState)
        {
            if (yukiState == YukiState.YellowBlow)
            {
                if (BackgroundImage == upBluNor) BackgroundImage = upNor;
                if (BackgroundImage == upBluBlw) BackgroundImage = upBlw;
            }
            if (yukiState == YukiState.BlueBlow)
            {
                if (BackgroundImage == upBlw) BackgroundImage = upBluBlw;
                if (BackgroundImage == upNor) BackgroundImage = upBluNor;
            }
        }
        */
    }
}
