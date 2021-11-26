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
        float scaleFactor = 1.0f;
        private void FrmNoteManager_Load(object sender, EventArgs e)
        {
            scaleFactor = (float)btnOpen.Width / 252f;
            NoteIcon = new Bitmap(NoteIcon, scaleSize(72), scaleSize(72));
            Image bannerTop = Properties.Resources.banner;
            Image bannerBottom = Properties.Resources.banner_bottom;
            panelTop.BackgroundImage = new Bitmap(bannerTop, (int)Math.Round((float)bannerTop.Width * ((float)panelTop.Height / (float)bannerTop.Height)), panelTop.Height);
            panelBottom.BackgroundImage = new Bitmap(bannerBottom, (int)Math.Round((float)bannerBottom.Width * ((float)panelBottom.Height / (float)bannerBottom.Height)), panelBottom.Height);
            Toast = new Toast(this);
            loadData();
        }

        private int scaleSize(int i)
        {
            return (int)Math.Floor(scaleFactor * i);
        }



        private string savesPath = "saves";
        private Image NoteIcon = Properties.Resources.noteicon;
        private Button generateButton(String path,NoteInfoEntry noteInfoEntry)
        {
            Button btn = new Button();
            btn.BackColor = Color.White;
            btn.FlatAppearance.BorderColor = Color.White;
            btn.FlatAppearance.BorderSize = scaleSize(3);
            btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(192,255,255);
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font(this.Font.FontFamily,(12));
            btn.Image = NoteIcon;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.Margin = new Padding(scaleSize(20),1,0,0);
            btn.Size = new Size(scaleSize(560), scaleSize(89));
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
                btnClone.Enabled = value != null; 
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
            DlgNewNote dlgNewNote = new DlgNewNote();
            dlgNewNote.NoteCreated += delegate
            {
                openParticularNote(dlgNewNote.NewNotePath);
            };
            ShowOverlayWindow(dlgNewNote);
        }
        private void btnClone_Click(object sender, EventArgs e)
        {
            DlgNewNote dlgNewNote = new DlgNewNote();
            String metapath = Path.Combine(selectedDir, "level.dat");
            NoteInfoEntry noteInfoEntry = JsonConvert.Deserialize<NoteInfoEntry>(File.ReadAllText(metapath));
            dlgNewNote.copyFrom = selectedDir;
            dlgNewNote.copyFromName = noteInfoEntry.Name;
            dlgNewNote.NoteCreated += delegate
            {
                openParticularNote(dlgNewNote.NewNotePath);
            };
            ShowOverlayWindow(dlgNewNote);
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

            DlgEditNote dlg = new DlgEditNote();
            dlg.infoEntry = noteInfoEntry;
            dlg.notesavePath = selectedDir;
            ShowOverlayWindow(dlg);
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


        private Form overlayForm = null;
        private void ShowOverlayWindow(Form f)
        {
            overlayForm = f;
            f.FormClosed += F_FormClosed;
            f.Load += F_Load;
            tblHeader.Visible = false;
            tblFooter.Visible = false;
            f.Show(this);
        }

        private void F_Load(object sender, EventArgs e)
        {
            repositionOverlay();
        }

        private void repositionOverlay()
        {
            if(overlayForm != null)
            {
                overlayForm.WindowState = (this.WindowState != FormWindowState.Minimized) ? FormWindowState.Normal : FormWindowState.Minimized;
                overlayForm.Location = tblNoteItems.PointToScreen(Point.Empty);
                overlayForm.Size = tblNoteItems.Size;
            }
        }

        private void F_FormClosed(object sender, FormClosedEventArgs e)
        {
            overlayForm = null;
            tblHeader.Visible = true;
            tblFooter.Visible = true;
            loadData();
        }

        private void FrmNoteManager_LocationChanged(object sender, EventArgs e)
        {
            if (overlayForm != null)
            {
                repositionOverlay();
            }
        }

        private void FrmNoteManager_SizeChanged(object sender, EventArgs e)
        {
            if (overlayForm != null)
            {
                repositionOverlay();
            }
        }


    }
}
