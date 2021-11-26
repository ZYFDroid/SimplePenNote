using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePenNote
{
    public partial class DlgNewNote : Form
    {
        public String copyFrom = null;
        public String copyFromName = null;

        public String NewNotePath = null;
        public event EventHandler<EventArgs> NoteCreated;
        public DlgNewNote()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        private void DlgNewNote_Load(object sender, EventArgs e)
        {
            if (copyFrom != null)
            {
                txtNoteName.Text = copyFromName;
                lblTitle.Text = "从现有笔记创建";
            }
            else
            {
                txtNoteName.Text = "新的笔记";
            }
            testSaveDir();
        }

        
        string pendingSaveDir = "";
        void testSaveDir()
        {
            string dirName = txtNoteName.Text.Replace('/', '_');
            Path.GetInvalidFileNameChars().ToList().ForEach(c => dirName = dirName.Replace(c, '_'));
            while (Directory.Exists(Path.Combine("saves", dirName)))
            {
                dirName += "_";
                if (dirName.Length > 48)
                {
                    dirName = ("wtf" + DateTime.Now.Ticks);
                    if (dirName.Length > 40)
                    {
                        dirName = dirName.Substring(0, 40);
                    }
                }
            }
            pendingSaveDir = dirName;
            lblSavePath.Text = "将会保存在 "+pendingSaveDir;
        }
        private void txtNoteName_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = txtNoteName.TextLength > 0;
            testSaveDir();
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            testSaveDir();
            Directory.CreateDirectory(Path.Combine("saves", pendingSaveDir));
            Directory.CreateDirectory(Path.Combine("saves", pendingSaveDir, "pages"));
            NoteInfoEntry ne = null;
            if (copyFrom != null)
            {
                ne = JsonConvert.Deserialize<NoteInfoEntry>(File.ReadAllText(Path.Combine(copyFrom, "level.dat")));
                string dirCopyFrom = Path.Combine(copyFrom, "pages");
                string dirCopyTo = Path.Combine("saves",pendingSaveDir, "pages");
                if (Directory.Exists(dirCopyFrom))
                {
                    Directory.EnumerateFiles(dirCopyFrom).ToList().ForEach(f => File.Copy(f, Path.Combine(dirCopyTo, Path.GetFileName(f)),true));
                }
                ne.PageIndex = 1;
            }
            else
            {
                ne = new NoteInfoEntry();
                
            }
            ne.Name = txtNoteName.Text;
            ne.LastAccess = DateTime.Now.ToFileTime();
            File.WriteAllText(Path.Combine("saves",pendingSaveDir, "level.dat"), JsonConvert.Serialize(ne));
            Close();
            this.NewNotePath = Path.GetFullPath(Path.Combine("saves", pendingSaveDir));
            NoteCreated?.Invoke(this, EventArgs.Empty);
        }
    }
}
