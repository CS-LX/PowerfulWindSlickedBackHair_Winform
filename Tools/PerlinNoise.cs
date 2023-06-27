using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerfulWindSlickedBackHair.Tools
{
    public static class PerlinNoise
    {
        private static readonly int[] perm = {
        151,160,137,91,90,15,
        131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,
        190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
        88,237,149,56,87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
        77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,
        102,143,54, 65,25,63,161, 1,216,80,73,209,76,132,187,208, 89,18,169,200,196,
        135,130,116,188,159,86,164,100,109,198,173,186, 3,64,52,217,226,250,124,123,
        5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,
        223,183,170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,172,9,
        129,22,39,253, 19,98,108,110,79,113,224,232,178,185, 112,104,218,246,97,228,
        251,34,242,193,238,210,144,12,191,179,162,241, 81,51,145,235,249,14,239,107,
        49,192,214, 31,181,199,106,157,184, 84,204,176,115,121,50,45,127, 4,150,254,
        138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180,
        151
    };
        public static float Noise(float x, float y, float z)
        {
            //计算输入点所在的“单位立方体”。0xff = 255

            var X = Mathf.FloorToInt(x) & 0xff;
            var Y = Mathf.FloorToInt(y) & 0xff;
            var Z = Mathf.FloorToInt(z) & 0xff;
            //左边界为(|x|,|y|,|z|)，右边界为 +1。接下来，我们计算出该点在立方体中的位置(0.0~1.0)。

            x -= Mathf.Floor(x);
            y -= Mathf.Floor(y);
            z -= Mathf.Floor(z);

            var u = Fade(x);
            var v = Fade(y);
            var w = Fade(z);

            var A = (perm[X] + Y) & 0xff;
            var B = (perm[X + 1] + Y) & 0xff;
            var AA = (perm[A] + Z) & 0xff;
            var BA = (perm[B] + Z) & 0xff;
            var AB = (perm[A + 1] + Z) & 0xff;
            var BB = (perm[B + 1] + Z) & 0xff;

            var AAA = perm[AA];
            var BAA = perm[BA];
            var ABA = perm[AB];
            var BBA = perm[BB];
            var AAB = perm[AA + 1];
            var BAB = perm[BA + 1];
            var ABB = perm[AB + 1];
            var BBB = perm[BB + 1];

            //梯度函数计算伪随机梯度向量和输入坐标到其单位立方体中的8个顶点向量之间的点积。

            //然后，基于我们先前通过Fade函数计算得到的(u，v，w)值，将这些全部进行插值计算。

            float x1, x2, y1, y2;
            x1 = Lerp(Grad(AAA, x, y, z), Grad(BAA, x - 1, y, z), u);
            x2 = Lerp(Grad(ABA, x, y - 1, z), Grad(BBA, x - 1, y - 1, z), u);
            y1 = Lerp(x1, x2, v);

            x1 = Lerp(Grad(AAB, x, y, z - 1), Grad(BAB, x - 1, y, z - 1), u);
            x2 = Lerp(Grad(ABB, x, y - 1, z - 1), Grad(BBB, x - 1, y - 1, z - 1), u);
            y2 = Lerp(x1, x2, v);
            //为了方便起见，我们将结果范围设为0~1(理论上之前的min/max是[-1，1])。

            return (Lerp(y1, y2, w) + 1) / 2;

            //...

        }

        static float Fade(float t)
        {
            return t * t * t * (t * (t * 6 - 15) + 10);
        }
        static float grad(int hash, float x, float y, float z)
        {
            //取散列值，取其前4位(15 = 0b1111)

            var h = hash & 15;
            //如果哈希的最高有效位(MSB)为0，则设置 u=x，否则为y。

            var u = h < 8/* 0b1000 */  ? x : y;
            //如果第一与第二有效位为0，则 v=y

            //如果第一或第二有效位是1，则 v=x

            //如果第一和第二有效位不等于(0/1，1/0)则v=z

            var v = h < 4/* 0b0100 */ ? y : (h == 12 /* 0b1100 */ || h == 14/* 0b1110*/ ? x : z);
            //使用最后2位来判断u和v是正还是负，然后返回它们的和。

            return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
        }


        // 另一种grad，两方法效果一样 Source: http://riven8192.blogspot.com/2010/08/calculate-perlinnoise-twice-as-fast.html
        public static float Grad(int hash, float x, float y, float z)
        {
            switch (hash & 0xF)
            {
                case 0x0: return x + y;
                case 0x1: return -x + y;
                case 0x2: return x - y;
                case 0x3: return -x - y;
                case 0x4: return x + z;
                case 0x5: return -x + z;
                case 0x6: return x - z;
                case 0x7: return -x - z;
                case 0x8: return y + z;
                case 0x9: return -y + z;
                case 0xA: return y - z;
                case 0xB: return -y - z;
                case 0xC: return y + x;
                case 0xD: return -y + z;
                case 0xE: return y - x;
                case 0xF: return -y - z;
                default: return 0; // never happens
            }
        }

        static float Lerp(float a, float b, float t)
        {
            return a + t * (b - a);
        }
    }
}
