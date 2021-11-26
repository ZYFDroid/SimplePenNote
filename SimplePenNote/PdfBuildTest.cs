using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.IO.Compression;
using System.Windows.Ink;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace PdfBuildTest
{

    public class StrokeUtils {
        System.Drawing.TextureBrush bgBrush;
        public StrokeUtils()
        {
            bgBrush = new TextureBrush(new Bitmap(SimplePenNote.Properties.Resources.noteline, 3, (int)Math.Round(4096 * 0.025)));
            bgBrush.ScaleTransform(1, 4096 / 4080);
        }
        public void StrokeToImage(StrokeCollection stroke, int w, int h, String savePath) {
            RenderTargetBitmap target = new RenderTargetBitmap(w * 2, h * 2, 192, 192, System.Windows.Media.PixelFormats.Default);
            DrawingVisual vis = new DrawingVisual();
            System.Windows.Media.Pen p = null;// new System.Windows.Media.Pen(System.Windows.Media.Brushes.White, 5);
            DrawingContext drawing = vis.RenderOpen();
            stroke.Draw(drawing);
            drawing.Close();
            target.Render(vis);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            BitmapFrame bitmapFrame = BitmapFrame.Create(target);
            encoder.Frames.Add(bitmapFrame);
            System.Drawing.Bitmap bgBmg = new Bitmap(w*2,h*2);
            System.Drawing.Image fgBmP = null;
            using (MemoryStream  ms = new MemoryStream())
            {
                encoder.Save(ms);
                fgBmP = Bitmap.FromStream(ms);
            }
            Graphics g = Graphics.FromImage(bgBmg);
            g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(System.Drawing.Color.White);
            g.FillRectangle(bgBrush, 0, 0, w * 2, h * 2);
            g.DrawImage(fgBmP, 0, 0, w * 2, h * 2);
            g.Dispose();
            fgBmP.Dispose();
            using(Bitmap temp = new Bitmap(bgBmg))
            {
                temp.Save(savePath,ImageFormat.Png);
            }
            bgBmg.Dispose();
        }
    }

    public class PDFBuilder
    {
        public List<PdfEntry> xrefTable = new List<PdfEntry>();
        public void AddEntry(PdfEntry e)
        {
            xrefTable.Add(e);
        }
        public void BuildWithImages(params string[] imgPaths)
        {
            PdfEntryBuilder entryBuilder = new PdfEntryBuilder();
            AddEntry(entryBuilder.buildPdfHeader());
            entryBuilder.buildPageCountEntry(this, imgPaths.Length);
            Image temp = Image.FromFile(imgPaths[0]);
            int width = temp.Width;
            int height = temp.Height;
            temp.Dispose();
            for (int i = 0; i < imgPaths.Length; i++)
            {
                using (Image img = Image.FromFile(imgPaths[i]))
                {
                    entryBuilder.BuildImagePages(this, img, width, height);
                }
            }
            //需要分别创建然后分别添加，创建这两个对象需要已经创建的对象的数量
            PdfEntry entryXref = entryBuilder.buildXrefEntry(this);
            PdfEntry entryEnd = entryBuilder.buildTailerEntry(this);
            AddEntry(entryXref);
            AddEntry(entryEnd);

        }

        public void WriteToFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = File.OpenWrite(path))
            {
                for (int i = 0; i < xrefTable.Count; i++)
                {
                    byte[] entryData = xrefTable[i].content;
                    fs.Write(entryData, 0, entryData.Length);
                }
            }
        }

    }

    public class PdfEntry
    {
        public byte[] content;
        public int Length { get; private set; }

        /// <summary>
        /// 提前写入并释放
        /// 当前为先写入内存然后写入文件
        /// 当页面较多的时候可以先写出文件，然后释放内存，仅保留必要的数据结构
        /// </summary>
        public void WriteAndRelease()
        {
            //Do it later
            throw new NotImplementedException();
        }

        public PdfEntry(byte[] data)
        {
            this.content = data;
            this.Length = content.Length;
        }
    }

    public class PdfEntryBuilder
    {
        //Object id increment
        public int PdfEntryCounter = 1;

        public PdfEntryBuilder()
        {

        }

        public PdfEntry buildPdfHeader()
        {
            return new PdfEntry(new byte[]
            {
                0x25,0x50,0x44,0x46,
                0x2D,0x31,0x2E,0x34,
                0x0A,0x25,0xC2,0xB5,
                0xC2,0xB6,0x0A,0x0A
            });
        }

        public PdfEntry buildSimpleObject(byte[] followingData)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] beginobj = (PdfEntryCounter + " 0 obj\n").Ascii();
                byte[] endobj = "\nendobj\n\n".Ascii();
                ms.Write(beginobj, 0, beginobj.Length);
                ms.Write(followingData, 0, followingData.Length);
                ms.Write(endobj, 0, endobj.Length);
                PdfEntryCounter++;
                return new PdfEntry(ms.ToArray());
            }
        }

        public PdfEntry buildXrefEntry(PDFBuilder builder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("xref\n0 " + builder.xrefTable.Count + "\n");
            int offset = 0;
            for (int i = 0; i < builder.xrefTable.Count; i++)
            {
                string offsetstr = "" + offset;
                while (offsetstr.Length < 10)
                {
                    offsetstr = "0" + offsetstr;
                }
                sb.Append(offsetstr + " 00000 n\n");
                offset += builder.xrefTable[i].Length;
            }
            sb.Append("\n");
            return new PdfEntry(sb.ToString().Ascii());
        }

        public PdfEntry buildTailerEntry(PDFBuilder builder)
        {
            int xrefCount = builder.xrefTable.Count;
            string strs = "trailer\n<</Size " + xrefCount + "/Root 1 0 R>>\nstartxref\n" + builder.xrefTable.Sum(x => x.Length) + "\n%%EOF\n";
            return new PdfEntry(strs.Ascii());
        }

        public void buildPageCountEntry(PDFBuilder builder, int pageCount)
        {
            PdfEntry refPageObj = buildSimpleObject("<</Type/Catalog/Pages 2 0 R>>".Ascii());
            StringBuilder pageObj = new StringBuilder();
            pageObj.Append("<</Type/Pages/Count ").Append(pageCount);
            pageObj.Append("/Kids[");
            for (int i = 0; i < pageCount; i++)
            {
                pageObj.Append(6 + 4 * i).Append(" 0 R");
                if (i < pageCount - 1)
                {
                    pageObj.Append(" ");
                }
            }
            pageObj.Append("]>>");
            PdfEntry objPageObj = buildSimpleObject(pageObj.ToString().Ascii());
            builder.AddEntry(refPageObj);
            builder.AddEntry(objPageObj);
        }

        public PdfEntry BuildImageEntry(Image img, int width, int height)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] imgdata = PDFImage.BitmapToPdfImage(img, width, height);
                string strsbefore = $"<</Type/XObject/Subtype/Image/Width {width}/Height {height}/ColorSpace/DeviceRGB/BitsPerComponent 8/Filter/DCTDecode/Interpolate true/Length {imgdata.Length}>>";

                string begin = "stream\n";
                string end = "\nendstream";
                byte[] bytesBefore = strsbefore.Ascii();
                byte[] bytebegin = begin.Ascii();
                byte[] byteEnd = end.Ascii();
                ms.Write(bytesBefore, 0, bytesBefore.Length);
                ms.Write(bytebegin, 0, bytebegin.Length);
                ms.Write(imgdata, 0, imgdata.Length);
                ms.Write(byteEnd, 0, byteEnd.Length);
                return buildSimpleObject(ms.ToArray());
            }
        }

        private PdfEntry buildStreamObj(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                string strsbefore = "<</Length " + data.Length + ">>\n";
                string begin = "stream\n";
                string end = "\nendstream";
                byte[] bytesBefore = strsbefore.Ascii();
                byte[] bytebegin = begin.Ascii();
                byte[] byteEnd = end.Ascii();
                ms.Write(bytesBefore, 0, bytesBefore.Length);
                ms.Write(bytebegin, 0, bytebegin.Length);
                ms.Write(data, 0, data.Length);
                ms.Write(byteEnd, 0, byteEnd.Length);
                return buildSimpleObject(ms.ToArray());
            }
        }

        int imgCounter = 0;
        public void BuildImagePages(PDFBuilder builder, Image img, int width, int height)
        {
            builder.AddEntry(BuildImageEntry(img, width, height));
            int imgRefId = PdfEntryCounter - 1;
            PdfEntry refImageObj = buildSimpleObject(("<</XObject<</Im" + imgCounter + " " + imgRefId + " 0 R>>>>").Ascii());
            builder.AddEntry(refImageObj);
            PdfEntry propImageObj = buildStreamObj(("q " + width + " 0 0 " + height + " 0 0 cm /Im" + imgCounter + " Do Q\n").Ascii());
            builder.AddEntry(propImageObj);
            PdfEntry pageObj = buildSimpleObject($"<</Type/Page/MediaBox[0 0 {width} {height}]/Rotate 0/Resources {PdfEntryCounter - 2} 0 R/Contents {PdfEntryCounter - 1} 0 R/Parent 2 0 R>>".Ascii());
            builder.AddEntry(pageObj);
            imgCounter++;
        }
    }
    static class StringExtension
    {
        public static byte[] Ascii(this string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }
    }

    public class PDFImage
    {
        public static byte[] BitmapToPdfImage(Image i, int x = 0, int y = 0)
        {
            if (x == 0) { x = i.Width; y = i.Height; }
            using (Bitmap bmp2 = new Bitmap(i, x, y))
            {
                using(MemoryStream ms = new MemoryStream())
                {
                    ImageCodecInfo codec = ImageCodecInfo.GetImageEncoders().Where(c => c.MimeType=="image/jpeg").First();
                    EncoderParameters encoderParameters = new EncoderParameters(1);
                    encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                    bmp2.Save(ms, codec,encoderParameters);
                    return ms.ToArray();
                }

            }
        }
    }

}
