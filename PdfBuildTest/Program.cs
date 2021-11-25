using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.IO.Compression;

namespace PdfBuildTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string teststr = "爷成功了"; ;
            Font f = new Font(SystemFonts.DefaultFont.FontFamily, 144);
            Brush black = new SolidBrush(Color.Black);
            Brush white = new SolidBrush(Color.White);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            for (int i = 0; i < teststr.Length; i++)
            {
                using (Bitmap bmp = new Bitmap(640, 480))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);
                        g.DrawString(teststr[i] + "", f, black, new RectangleF(0, 0, 640, 480), sf);

                    }
                    bmp.Save((i + 1) + ".png");
                }
            }

            PDFBuilder test = new PDFBuilder();
            test.BuildWithImages("1.png", "2.png", "3.png", "4.png");
            test.WriteToFile("testout.pdf");
        }
    }
    public class PDFBuilder
    {
        public List<PdfEntry> xrefTable = new List<PdfEntry>();
        public void AddEntry(PdfEntry e) {
            xrefTable.Add(e);
        }
        public void BuildWithImages(params string[] imgPaths)
        {
            PdfEntryBuilder entryBuilder = new PdfEntryBuilder();
            AddEntry(entryBuilder.buildPdfHeader());
            entryBuilder.buildPageCountEntry(this,imgPaths.Length);
            Image temp = Image.FromFile(imgPaths[0]);
            int width = temp.Width;
            int height = temp.Height;
            temp.Dispose();
            for (int i = 0; i < imgPaths.Length; i++)
            {
                using (Image img = Image.FromFile(imgPaths[i])) {
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
            using(FileStream fs = File.OpenWrite(path))
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
        public void WriteAndRelease() {
            //Do it later
            throw new NotImplementedException();
        }

        public PdfEntry(byte[] data) {
            this.content = data;
            this.Length = content.Length;
        }
    }

    public class PdfEntryBuilder {
        //Object id increment
        public int PdfEntryCounter = 1;

        public PdfEntryBuilder() { 
        
        }

        public PdfEntry buildPdfHeader()
        {
            return new PdfEntry(new byte[]
            {
                (byte)0x25, (byte)0x50, (byte)0x44, (byte)0x46,
                (byte)0x2D, (byte)0x31, (byte)0x2E, (byte)0x34,
                (byte)0x0A, (byte)0x25, (byte)0xC2, (byte)0xB5,
                (byte)0xC2, (byte)0xB6, (byte)0x0A, (byte)0x0A
            });
        }

        public PdfEntry buildSimpleObject(byte[] followingData)
        {
            using (MemoryStream ms = new MemoryStream()) {
                byte[] beginobj = (PdfEntryCounter + " 0 obj\n").Ascii();
                byte[] endobj = "\nendobj\n\n".Ascii();
                ms.Write(beginobj,0,beginobj.Length);
                ms.Write(followingData,0,followingData.Length);
                ms.Write(endobj,0,endobj.Length);
                PdfEntryCounter++;
                return new PdfEntry(ms.ToArray());
            }
        }

        public PdfEntry buildXrefEntry(PDFBuilder builder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("xref\n0 " + builder.xrefTable.Count+"\n");
            int offset = 0;
            for (int i = 0; i < builder.xrefTable.Count; i++)
            {
                string offsetstr = "" + offset;
                while (offsetstr.Length < 10) {
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

        public void buildPageCountEntry(PDFBuilder builder,int pageCount) {
            PdfEntry refPageObj = buildSimpleObject("<</Type/Catalog/Pages 2 0 R>>".Ascii());
            StringBuilder pageObj = new StringBuilder();
            pageObj.Append("<</Type/Pages/Count ").Append(pageCount);
            pageObj.Append("/Kids[");
            for (int i = 0; i < pageCount; i++)
            {
                pageObj.Append(6 + 4 * i).Append(" 0 R");
                if (i < pageCount - 1) {
                    pageObj.Append(" ");
                }
            }
            pageObj.Append("]>>");
            PdfEntry objPageObj = buildSimpleObject(pageObj.ToString().Ascii());
            builder.AddEntry(refPageObj);
            builder.AddEntry(objPageObj);
        }

        public PdfEntry BuildImageEntry(Image img,int width,int height) { 
            using(MemoryStream ms = new MemoryStream())
            {
                byte[] imgdata = PDFImage.BitmapToPdfImage(img, width, height);
                string strsbefore = "<</DecodeParms<<>>/Type/XObject/Subtype/Image/Width "+width+"/Height "+height+"/BitsPerComponent 8/ColorSpace/DeviceRGB/Length "+imgdata.Length;
                strsbefore += "/Filter/FlateDecode";
                strsbefore += ">>\n";
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

        private PdfEntry buildStreamObj(byte[] data) {
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
        public void BuildImagePages(PDFBuilder builder,Image img,int width,int height)
        {
            builder.AddEntry(BuildImageEntry(img, width, height));
            int imgRefId = PdfEntryCounter - 1;
            PdfEntry refImageObj = buildSimpleObject(("<</XObject<</Im"+imgCounter+" "+imgRefId+" 0 R>>>>").Ascii());
            builder.AddEntry(refImageObj);
            PdfEntry propImageObj = buildStreamObj(("q "+width+" 0 0 "+height+" 0 0 cm /Im"+imgCounter+" Do Q\n").Ascii());
            builder.AddEntry(propImageObj);
            PdfEntry pageObj = buildSimpleObject($"<</Type/Page/MediaBox[0 0 {width} {height}]/Rotate 0/Resources {PdfEntryCounter - 2} 0 R/Contents {PdfEntryCounter - 1} 0 R/Parent 2 0 R>>".Ascii());
            builder.AddEntry(pageObj);
            imgCounter++;
        }
    }
    static class StringExtension {
        public static byte[] Ascii(this string str) {
            return Encoding.ASCII.GetBytes(str);
        }
    }

    public class PDFImage
    {
        public static byte[] BitmapToPdfImage(Image i, int x = 0, int y = 0)
        {
            if (x == 0) { x = i.Width; y = i.Height; }
            using (Bitmap bmp2 = new Bitmap(i,x,y))
            {
                BitmapData rawData = bmp2.LockBits(new Rectangle(0, 0, bmp2.Width, bmp2.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                byte[] memoryBitmap = new byte[rawData.Width * rawData.Height * 3];
                Marshal.Copy(rawData.Scan0, memoryBitmap, 0, memoryBitmap.Length);
                uint checksum = Adler32CheckSum.CheckSum(memoryBitmap);
                using (MemoryStream msbefore = new MemoryStream(memoryBitmap))
                using (MemoryStream msafter = new MemoryStream())
                {
                    //Wrap RawDeflate with zlib header and checksum
                    byte[] zlibHeader = {0x78,0x9c};
                    msafter.Write(zlibHeader,0,zlibHeader.Length);
                    using (DeflateStream deflate = new DeflateStream(msafter, CompressionMode.Compress, true))
                    {
                        msbefore.CopyTo(deflate);
                    }
                    msafter.WriteByte((byte)(checksum >> 0 & 0xff));
                    msafter.WriteByte((byte)(checksum >> 8 & 0xff));
                    msafter.WriteByte((byte)(checksum >> 16 & 0xff));
                    msafter.WriteByte((byte)(checksum >> 24 & 0xff));
                    return msafter.ToArray();
                }
            }
        }
    }
    
    /// <summary>
    /// Alder32 Checksum Algorithm based on RFC-1955
    /// </summary>
    public class Adler32CheckSum {

        const uint BASE = 65521;
        private static uint update_alder32(uint alder,byte[] buf,int len)
        {
            uint s1 = alder & 0xffff;
            uint s2 = (alder >> 16) & 0xffff;
            int n;
            for (n = 0; n < len; n++)
            {
                s1 = (s1 + buf[n]) % BASE;
                s2 = (s2 + s1) % BASE;
            }
            return (s2 << 16) + s1;
        }

        public static uint CheckSum(byte[] data)
        {
            return update_alder32(1, data, data.Length);
        }
    }
}
