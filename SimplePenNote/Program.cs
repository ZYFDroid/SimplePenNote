using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePenNote
{
    internal static class Program
    {

        public static string WorkingDir = ".";
        public static bool gotoTitle = false;
        public static Icon windowIcon = null;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            windowIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            gotoTitle = false;

            
            if(Environment.GetCommandLineArgs().Length>1)
            {
                WorkingDir = Environment.GetCommandLineArgs()[1].Trim('\"'); 
                if (WorkingDir != null && Directory.Exists(WorkingDir))
                {
                    Application.Run(new FrmNote());
                    if (gotoTitle)
                    {
                        System.Diagnostics.Process.Start(Application.ExecutablePath);
                    }
                }
            }
            else
            {
                Application.Run(new FrmNoteManager());

            }


        }
    }

    class NoteInfoEntry {
        public string Name = "新的笔记";
        public long LastAccess = new DateTime(2021,11,22).ToFileTime();
        public int PageCount = 1;
        public int PageIndex = 1;
        public double PaperWidth = -1;
        public double PaperHeight = -1;
    }

    class JsonConvert {
        private static System.Web.Script.Serialization.JavaScriptSerializer serializer;
        public static string Serialize(object obj) {
            if (serializer == null) { serializer = new System.Web.Script.Serialization.JavaScriptSerializer(); }
            return serializer.Serialize(obj);
        }

        public static T Deserialize<T>(string json) {
            if (serializer == null) { serializer = new System.Web.Script.Serialization.JavaScriptSerializer(); }
            return serializer.Deserialize<T>(json);
        }
    }

    class MyButton: System.Windows.Forms.Button
    {
        public MyButton() : base()
        {
            makeFlat(this);
            
        }

        public static void makeFlat(System.Windows.Forms.ButtonBase btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 0, 255, 255);
            btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(255, 0, 192, 192);
            btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(255, 0, 255, 255);
            btn.BackColor = System.Drawing.Color.FromArgb(255, 223, 244, 249);
            btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btn.FlatAppearance.BorderSize = 3;
        }
    }
    class MyRadioButton : System.Windows.Forms.RadioButton
    {
        public MyRadioButton() : base()
        {
            MyButton.makeFlat(this);
            this.Appearance = Appearance.Button;
        }
    }
}
