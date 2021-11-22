using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace PdfBuildTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = File.OpenWrite("test.dat");
            using (Bitmap bmp2 = new Bitmap(48, 48, PixelFormat.Format24bppRgb))
            {
                Graphics g = Graphics.FromImage(bmp2);
                g.Clear(Color.Red);
                g.Dispose();
                BitmapData rawData = bmp2.LockBits(new Rectangle(0,0,bmp2.Width,bmp2.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                byte[] memoryBitmap = new byte[rawData.Width * rawData.Height * 3];
                Marshal.Copy(rawData.Scan0, memoryBitmap, 0, memoryBitmap.Length);
                fs.Write(memoryBitmap, 0, memoryBitmap.Length);
                bmp2.UnlockBits(rawData);
            }
        }
    }
    public class PDFBuilder { 
    
    }

    public class PDFImage
    {
        public static byte[] BitmapToPdfImage(Image i,int x = 0,int y = 0)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                if (x == 0) { x = i.Width;y = i.Height;}
                using (Bitmap bmp2 = new Bitmap(x, y, PixelFormat.Format24bppRgb)) {
                    Graphics g = Graphics.FromImage(bmp2);
                    g.Clear(Color.Red);
                    bmp2.Save(ms,ImageFormat.MemoryBmp);
                    return ms.ToArray();
                }
            }
        }
    }
}
