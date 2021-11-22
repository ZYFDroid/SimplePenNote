using Launchkit_Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePenNote
{
    public partial class FrmNoteManager : Form
    {
        public FrmNoteManager()
        {
            InitializeComponent();
            Program.WorkingDir = null;
            this.Icon = Program.windowIcon;
        }

        Toast Toast;

        private void FrmNoteManager_Load(object sender, EventArgs e)
        {
            Toast = new Toast(this);
            loadData();
        }

        private string savesPath = "saves";

        private Button generateButton(String path,NoteInfoEntry noteInfoEntry)
        {
            Button btn = new Button();
            btn.BackColor = Color.White;
            btn.FlatAppearance.BorderColor = Color.White;
            btn.FlatAppearance.BorderSize = 3;
            btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(192,255,255);
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font(this.Font.FontFamily,12);
            btn.Image = Properties.Resources.noteicon;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.Margin = new Padding(20,1,0,0);
            btn.Size = new Size(560, 89);
            DateTime d = DateTime.FromFileTime(noteInfoEntry.LastAccess);
            btn.Text = $"{noteInfoEntry.Name}\r\n{d.ToShortDateString()+" "+d.ToShortTimeString()}\r\n{noteInfoEntry.PageIndex}/{noteInfoEntry.PageCount}页";
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Click += Btn_Click;
            btn.Tag = path;
            return btn;
        }

        private string _selectedDir = null;
        string selectedDir {
            get {
                return _selectedDir;
            }
            set { 
                _selectedDir = value;
                btnOpen.Enabled = value != null; 
                btnOpenDir.Enabled = value != null; 
                btnRename.Enabled = value != null; 
                btnDelete.Enabled = value != null; 
            }
        }

        class NotePathPair {
            internal string path;
            internal NoteInfoEntry entry;
        }

        private void loadData()
        {
            tblNoteItems.Controls.Clear();
            if (!Directory.Exists(savesPath))
            {
                Directory.CreateDirectory(savesPath);
            }
            selectedDir = null;
            tblNoteItems.SuspendLayout();
            List<NotePathPair> noteInfoEntries = getAllNote();
            noteInfoEntries.OrderByDescending(n => n.entry.LastAccess).ToList().ForEach(f => {
                Button btn = generateButton(f.path,f.entry);
                tblNoteItems.Controls.Add(btn);
            });

            tblNoteItems.ResumeLayout();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            foreach (Button item in tblNoteItems.Controls)
            {
                item.FlatAppearance.BorderColor = Color.White;
            }
            Button btn = (Button)sender;
            btn.FlatAppearance.BorderColor = Color.FromArgb(64,192,255);
            if (selectedDir == btn.Tag.ToString())
            {
                btnOpen.PerformClick();
            }
            else
            {
                selectedDir = btn.Tag.ToString();
            }
        }

        public void openParticularNote(string path)
        {
            if(path.Contains(' '))
            {
                path = '\"' + path + '\"';
            }
            System.Diagnostics.Process.Start(Application.ExecutablePath,path);
            Close();
        }
        bool draggedin = false;
        int beginY = 0;
        int shouldDragY = 0;
        private void sfDragger_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                draggedin = true;
                beginY = e.Y;
                shouldDragY = tblNoteItems.VerticalScroll.Value;
            }
        }

        private void sfDragger_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedin)
            {
                if (tblNoteItems.VerticalScroll.Enabled)
                {
                    int deltaY = e.Y - beginY;
                    int newValue = shouldDragY - deltaY;
                    if(newValue < tblNoteItems.VerticalScroll.Minimum)
                    {
                        newValue = tblNoteItems.VerticalScroll.Minimum;
                    }
                    if(newValue > tblNoteItems.VerticalScroll.Maximum)
                    {
                        newValue = tblNoteItems.VerticalScroll.Maximum;
                    }
                    tblNoteItems.VerticalScroll.Value = newValue;
                    shouldDragY = newValue;
                    beginY = e.Y;
                }
            }
        }

        private void sfDragger_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draggedin = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            selectedDir = null;
            foreach (Button item in tblNoteItems.Controls)
            {
                item.FlatAppearance.BorderColor = Color.White;
                item.Visible = item.Text.Split('\r','\n')[0].ToLower().Contains(txtSearch.Text.ToLower());
            }
        }

        private List<NotePathPair> getAllNote()
        {
            var noteInfoEntries = new List<NotePathPair>();
            Directory.EnumerateDirectories(Path.GetFullPath(savesPath)).ToList().ForEach(d => {
                Console.WriteLine(d);
                string metafile = Path.Combine(d, "level.dat");
                if (File.Exists(metafile))
                {

                    try
                    {

                        noteInfoEntries.Add(new NotePathPair { path = d, entry = JsonConvert.Deserialize<NoteInfoEntry>(File.ReadAllText(metafile)) });

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            });
            return noteInfoEntries;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
            string name = "新的笔记";
            int i = 0;
            List<string> allNames = getAllNote().Select(l => l.entry.Name).Distinct().ToList();
            while (allNames.Contains(name))
            {
                i++;
                name = "新的笔记" + " ("+i+")";
            }
            if (DlgInputBox.InputText(this,"创建新的笔记","笔记名称",ref name))
            {
                string dirname = Guid.NewGuid().ToString().Replace("-","");
                dirname = Path.Combine(savesPath, dirname);
                Directory.CreateDirectory(dirname);
                NoteInfoEntry noteInfoEntry = new NoteInfoEntry();
                noteInfoEntry.LastAccess = DateTime.Now.ToFileTime();
                noteInfoEntry.Name = name;
                File.WriteAllText(Path.Combine(dirname,"level.dat"),JsonConvert.Serialize(noteInfoEntry));
                loadData();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(selectedDir == null)
            {
                return;
            }
            openParticularNote(selectedDir);
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (selectedDir == null)
            {
                return;
            }
            String metapath = Path.Combine(selectedDir, "level.dat");
            NoteInfoEntry noteInfoEntry = JsonConvert.Deserialize<NoteInfoEntry>(File.ReadAllText(metapath));
            if (DlgInputBox.InputText(this, "编辑笔记", "笔记名称", ref noteInfoEntry.Name))
            {
                File.WriteAllText(metapath, JsonConvert.Serialize(noteInfoEntry));
                loadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(this,"你确定要删除这个笔记吗？\r\n这个笔记将会永久失去！（真的很久！）","删除确认",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Directory.Delete(selectedDir, true);
                loadData();
                Toast.ShowMessage("笔记已删除");
            }
        }

        private void btnOpenDir_Click(object sender, EventArgs e)
        {
            Process.Start(Path.GetFullPath(selectedDir));
        }
    }
}
