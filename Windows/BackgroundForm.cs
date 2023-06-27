using Sunny.UI.Win32;
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
    public partial class BackgroundForm : Form
    {
        Color backColorY;
        Color backColorB;
        public BackgroundForm()
        {
            InitializeComponent();
            backColorY = Color.FromArgb(0xFED851);
            backColorY = Color.FromArgb(255, backColorY.R, backColorY.G, backColorY.B);
            BackColor = backColorY;

            backColorB = Color.FromArgb(0x62BFF7);
            backColorB = Color.FromArgb(255, backColorB.R, backColorB.G, backColorB.B);
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
                    UpdateText(Tracker.frame);
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

        void UpdateText(long f)
        {
            long offset = 0;
            switch (f - offset)
            {
                case 10:
                    text.Text = "外出た瞬間\r\n";
                    break;
                case 48:
                    text.Text = "終わったわ\r\n";
                    break;
                case 68:
                    text.Text = "";
                    break;
                case 86:
                    text.Text = "天気は良いのに\r\n";
                    break;
                case 125:
                    text.Text = "進めない\r\n";
                    break;
                case 146:
                    text.Text = "";
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 186F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    break;
                //风
                case 152:
                    text.Text = "風";
                    break;
                case 167:
                    text.Text = "";
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    break;
                case 172:
                    text.Text = "強すぎて\r\n";
                    break;
                case 201:
                    text.Text = "お亡くなり\r\n";
                    break;
                case 221:
                    text.Text = "";
                    break;
                case 238:
                    text.Text = "定期      \r\n";
                    break;
                case 247:
                    text.Text = "定期定期\r\n";
                    break;
                case 257:
                    text.Text = "定期定期\r\n的に";
                    break;
                case 272:
                    text.Text = "オールバック\r\n";
                    break;
                case 309:
                    text.Text = "";
                    break;
                case 390:
                    BackColor = backColorB;
                    break;
                case 460:
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    break;
                case 467:
                    BackColor = backColorY;
                    text.Text = "強風オールバック\r\n";
                    break;
                case 542:
                    BackColor = backColorB;
                    break;
                case 618:
                    text.Text = "";
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    break;
                case 619:
                    text.Text = "地下に\r\n";
                    BackColor = backColorY;
                    break;
                case 652:
                    text.Text = "潜りたいな\r\n";
                    break;
                case 701:
                    text.Text = "";
                    break;
                case 714:
                    text.Text = "って\r\n";
                    break;
                case 726:
                    text.Text = "";
                    break;
                case 729:
                    text.Text = "思いました\r\n";
                    break;
                case 762:
                    text.Text = "";
                    break;
                case 772:
                    text.Text = "風さえ\r\n";
                    break;
                case 810:
                    text.Text = "なくなれば\r\n";
                    break;
                case 843:
                    text.Text = "";
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 86F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    break;
                case 876:
                    text.Text = "あったかいのに\r\n";
                    break;
                case 909:
                    text.Text = "";
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    break;
                case 924:
                    text.Text = "ずっと\r\n";
                    break;
                case 958:
                    text.Text = "座りたいな\r\n";
                    break;
                case 997:
                    text.Text = "";
                    break;
                case 1018:
                    text.Text = "って\r\n";
                    break;
                case 1029:
                    text.Text = "";
                    break;
                case 1034:
                    text.Text = "思いました\r\n";
                    break;
                case 1076:
                    text.Text = "いやいや\r\n";
                    break;
                case 1109:
                    text.Text = "と\r\n";
                    break;
                case 1114:
                    text.Text = "外でたら\r\n";
                    break;
                case 1142:
                    text.Text = "";
                    break;
                case 1152:
                    text.Text = "ハト         \r\n";
                    break;
                case 1161:
                    text.Text = "   ハト      \r\n";
                    break;
                case 1170:
                    text.Text = "      ハト   \r\n";
                    break;
                case 1179:
                    text.Text = "         ハト\r\n";
                    break;
                case 1185:
                    text.Text = "";
                    break;
                case 1191:
                    text.Text = "大乱闘\r\n";
                    break;
                case 1212:
                    text.Text = "";
                    break;
                //P2
                case 1228:
                    text.Text = "外出た瞬間\r\n";
                    break;
                case 1266:
                    text.Text = "終わったわ\r\n";
                    break;
                case 1288:
                    text.Text = "";
                    break;
                case 1304:
                    text.Text = "天気は良いのに\r\n";
                    break;
                case 1343:
                    text.Text = "進めない\r\n";
                    break;
                case 1364:
                    text.Text = "";
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 186F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    break;
                //风
                case 1371:
                    text.Text = "風";
                    break;
                case 1386:
                    text.Text = "";
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    break;
                case 1391:
                    text.Text = "強すぎて\r\n";
                    break;
                case 1420:
                    text.Text = "お亡くなり\r\n";
                    break;
                case 1441:
                    text.Text = "";
                    break;
                case 1456:
                    text.Text = "定期      \r\n";
                    break;
                case 1466:
                    text.Text = "定期定期\r\n";
                    break;
                case 1476:
                    text.Text = "定期定期\r\n的に";
                    break;
                case 1491:
                    text.Text = "オールバック\r\n";
                    break;
                case 1527:
                    text.Text = "";
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    break;
                case 1685:
                    text.Text = "強風オールバック\r\n";
                    break;
                case 1810:
                    text.Text = "";
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    break;
                //P3
                case 1836:
                    text.Text = "外\r\n";
                    break;
                case 1843:
                    text.Text = "外出\r\n";
                    break;
                case 1847:
                    text.Text = "外出た\r\n";
                    break;
                case 1851:
                    text.Text = "外出た瞬\r\n";
                    break;
                case 1865:
                    text.Text = "外出た瞬間\r\n";
                    break;
                case 1874:
                    text.Text = "終わったわ\r\n";
                    break;
                case 1895:
                    text.Text = "";
                    break;
                case 1912:
                    text.Text = "天気は良いのに\r\n";
                    break;
                case 1951:
                    text.Text = "進めない\r\n";
                    break;
                case 1973:
                    text.Text = "";
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 186F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    break;
                //风
                case 1979:
                    text.Text = "風";
                    break;
                case 1994:
                    text.Text = "";
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    break;
                case 1998:
                    text.Text = "強すぎて\r\n";
                    break;
                case 2028:
                    text.Text = "お亡くなり\r\n";
                    break;
                case 2048:
                    text.Text = "";
                    break;
                case 2065:
                    text.Text = "定期      \r\n";
                    break;
                case 2074:
                    text.Text = "定期定期\r\n";
                    break;
                case 2084:
                    text.Text = "定期定期\r\n的に";
                    break;
                case 2099:
                    text.Text = "オールバック\r\n";
                    break;
                //P4
                case 2131:
                    text.Text = "そっ\r\n";
                    break;
                case 2135:
                    text.Text = "";
                    break;
                case 2141:
                    text.Text = "と\r\n";
                    break;
                case 2148:
                    text.Text = "";
                    break;
                case 2151:
                    text.Text = "出た瞬間\r\n";
                    break;
                case 2172:
                    text.Text = "";
                    break;
                case 2180:
                    text.Text = "終わったわ\r\n";
                    break;
                case 2200:
                    text.Text = "";
                    break;
                case 2218:
                    text.Text = "天気は良いのに\r\n";
                    break;
                case 2255:
                    text.Text = "進めない\r\n";
                    break;
                case 2277:
                    text.Text = "";
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 186F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    break;
                //风
                case 2285:
                    text.Text = "風";
                    break;
                case 2300:
                    text.Text = "";
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    break;
                case 2304:
                    text.Text = "強すぎて\r\n";
                    break;
                case 2333:
                    text.Text = "お亡くなり\r\n";
                    break;
                case 2356:
                    text.Text = "";
                    break;
                case 2371:
                    text.Text = "定期      \r\n";
                    break;
                case 2381:
                    text.Text = "定期定期\r\n";
                    break;
                case 2391:
                    text.Text = "定期定期\r\n的に";
                    break;
                case 2405:
                    text.Text = "オールバック\r\n";
                    break;
                case 2438:
                    text.Text = "";
                    break;
                case 2445:
                    text.Text = "髪の毛\r\n";
                    break;
                case 2461:
                    text.Text = "強風\r\n";
                    break;
                case 2476:
                    text.Text = "オールバック\r\n";
                    break;
                case 2502:
                    text.Text = "";
                    break;
                case 2523:
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    text.TextAlign = ContentAlignment.MiddleLeft;
                    text.Text = "強風オールバック\r\n但是windows";
                    break;
                case 2602:
                    text.Text = "原: https://youtu.be/D6DVTLvOupE\r\n";
                    break;
                case 2677:
                    text.Text = "改: LX\r\n显示: winform";
                    break;
                case 2753:
                    text.Text = "使用插件:\r\nNAudio SunnyUI";
                    break;
                case 2818:
                    text.Font = new System.Drawing.Font("思源黑体 CN Heavy", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    text.TextAlign = ContentAlignment.MiddleCenter;
                    text.Text = "谢谢观看\r\n记得三连~";
                    break;
            }
        }
    }
}
