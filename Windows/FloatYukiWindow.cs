using Sunny.UI.Win32;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair.Windows
{
    public partial class FloatYukiWindow : Form
    {
        Bitmap yuki;
        public FloatYukiWindow()
        {
            InitializeComponent();
            yuki = new Bitmap("Assets//CuttingYuki.png");
            Size = yuki.Size;
        }

        private void FloatYukiWindow_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            ConcurrentBag<Point> points = new ConcurrentBag<Point>();
            Rectangle rect = new Rectangle(0, 0, yuki.Width, yuki.Height);

            BitmapData data = yuki.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                int stride = data.Stride;

                Parallel.For(0, data.Height, y =>
                {
                    for (int x = 0; x < data.Width; x++)
                    {
                        byte alpha = ptr[y * stride + x * 4 + 3];
                        if (alpha > 0)
                        {
                            points.Add(new Point(x, y));
                        }
                    }
                });
            }
            yuki.UnlockBits(data);

            if (points.Count > 0)
            {
                path.AddPolygon(points.ToArray());
            }

            // 设置窗体的背景色为透明
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
        }

        private void FloatYukiWindow_Paint(object sender, PaintEventArgs e)
        {
            // 绘制圆形背景
            Rectangle rect = new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
            using (Brush brush = new SolidBrush(Color.LightBlue))
            {
                e.Graphics.DrawImage(yuki, 0, 0);
            }
        }
    }
}
