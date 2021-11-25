using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //Console.WriteLine(Adler32CheckSum.CheckSum(File.ReadAllBytes("testchksum.dat")));
            //Console.ReadLine();
            //if (true) { return; }
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
            PdfEntry entryXref = entryBuilder.buildXrefEntry(this);
            PdfEntry entryEnd = entryBuilder.buildTailerEntry(this);
            AddEntry(entryXref);
            AddEntry(entryEnd);

        }
        
        public void WriteToFile(string path)
        {
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
            throw new NotImplementedException();
        }

        public PdfEntry(byte[] data) {
            this.content = data;
            this.Length = content.Length;
        }
    }

    public class PdfEntryBuilder {
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
                byte[] beginobj = Encoding.ASCII.GetBytes(PdfEntryCounter + " 0 obj\n");
                byte[] endobj = Encoding.ASCII.GetBytes("\nendobj\n\n");
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
            return new PdfEntry(Encoding.ASCII.GetBytes(sb.ToString()));
        }

        public PdfEntry buildTailerEntry(PDFBuilder builder)
        {
            int xrefCount = builder.xrefTable.Count;
            string strs = "trailer\n<</Size " + xrefCount + "/Root 1 0 R>>\nstartxref\n" + builder.xrefTable.Sum(x => x.Length) + "\n%%EOF\n";
            return new PdfEntry(Encoding.ASCII.GetBytes(strs));
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
            builder.xrefTable.Add(refPageObj);
            builder.xrefTable.Add(objPageObj);
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
            builder.xrefTable.Add(BuildImageEntry(img, width, height));
            int imgRefId = PdfEntryCounter - 1;
            PdfEntry refImageObj = buildSimpleObject(("<</XObject<</Im"+imgCounter+" "+imgRefId+" 0 R>>>>").Ascii());
            builder.xrefTable.Add(refImageObj);
            PdfEntry propImageObj = buildStreamObj(("q "+width+" 0 0 "+height+" 0 0 cm /Im"+imgCounter+" Do Q\n").Ascii());
            builder.xrefTable.Add(propImageObj);
            PdfEntry pageObj = buildSimpleObject($"<</Type/Page/MediaBox[0 0 {width} {height}]/Rotate 0/Resources {PdfEntryCounter - 2} 0 R/Contents {PdfEntryCounter - 1} 0 R/Parent 2 0 R>>".Ascii());
            builder.xrefTable.Add(pageObj);
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

                    msafter.WriteByte(0x78);
                    msafter.WriteByte(0x9c);
                    using (DeflateStream deflate = new DeflateStream(msafter, CompressionMode.Compress, true))
                    {
                        msbefore.CopyTo(deflate);
                        
                    }
                    msafter.WriteByte((byte)(checksum >> 0 & 0xff));
                    msafter.WriteByte((byte)(checksum >> 8 & 0xff));
                    msafter.WriteByte((byte)(checksum >> 16 & 0xff));
                    msafter.WriteByte((byte)(checksum >> 24 & 0xff));
                    return msafter.GetBuffer();
                }
            }
        }
    }
    /*
      The following C code computes the Adler-32 checksum of a data buffer.
   It is written for clarity, not for speed.  The sample code is in the
   ANSI C programming language. Non C users may find it easier to read
   with these hints:

      &      Bitwise AND operator.
      >>     Bitwise right shift operator. When applied to an
             unsigned quantity, as here, right shift inserts zero bit(s)
             at the left.
      <<     Bitwise left shift operator. Left shift inserts zero
             bit(s) at the right.
      ++     "n++" increments the variable n.
      %      modulo operator: a % b is the remainder of a divided by b.

      #define BASE 65521 // largest prime smaller than 65536 

    
       Update a running Adler-32 checksum with the bytes buf[0..len-1]
     and return the updated checksum. The Adler-32 checksum should be
     initialized to 1.

     Usage example:

       unsigned long adler = 1L;

       while (read_buffer(buffer, length) != EOF) {
         adler = update_adler32(adler, buffer, length);
       }
       if (adler != original_adler) error();
    
    unsigned long update_adler32(unsigned long adler,
       unsigned char* buf, int len)
    {
        unsigned long s1 = adler & 0xffff;
        unsigned long s2 = (adler >> 16) & 0xffff;
        int n;

        for (n = 0; n < len; n++)
        {
            s1 = (s1 + buf[n]) % BASE;
            s2 = (s2 + s1) % BASE;
        }
        return (s2 << 16) + s1;
    }

       Return the adler32 of the bytes buf[0..len-1] 
     */
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
