using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Ink;

namespace SimplePenNote
{
    public partial class FrmNote : Form
    {
        InkCanvas inkCanvas;
        private NoteControl NoteControl;
        public FrmNote()
        {
            
            InitializeComponent();
            this.Icon = Program.windowIcon;
            this.NoteControl = new NoteControl();
            this.noteContainer.Child = this.NoteControl;
            inkCanvas = NoteControl.InkCanvas;
            NoteControl.RightButtonPressed += NoteControl_RightButtonPressed;
            //NoteControl.SizeAvailable += NoteControl_SizeAvailable;
        }

        

        private void NoteControl_RightButtonPressed(object sender, EventArgs e)
        {
            if (currentMenu != null) {
                currentMenu.Show(MousePosition, ToolStripDropDownDirection.Left);
            }
        }

        ContextMenuStrip currentMenu = null;

        Launchkit_Backend.Toast Toast = null;

        

        private void Form1_Load(object sender, EventArgs e)
        {
            Toast = new Launchkit_Backend.Toast(this);
            inkCanvas.DefaultDrawingAttributes = normalPenAttribute;
            normalPenAttribute.Color = System.Windows.Media.Color.FromRgb(0, 0, 0);
            normalPenAttribute.FitToCurve = true;
            normalPenAttribute.Width = 1.5;
            normalPenAttribute.Height = 1.5;
            normalPenAttribute.StylusTip = System.Windows.Ink.StylusTip.Ellipse;
            hilighterAttribute.Color = System.Windows.Media.Color.FromRgb(255,192,0);
            hilighterAttribute.FitToCurve = true;
            hilighterAttribute.IgnorePressure = true;
            hilighterAttribute.Height = 48;
            hilighterAttribute.IsHighlighter = true;
            hilighterAttribute.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            inkCanvas.StrokeErasing += InkCanvas_StrokeErasing;
            currentMenu = mnuPen;
            if (File.Exists(Path.Combine(Program.WorkingDir, "level.dat")))
            {
                try
                {
                    noteInfoEntry = JsonConvert.Deserialize<NoteInfoEntry>(File.ReadAllText(Path.Combine(Program.WorkingDir, "level.dat")));
                }catch (Exception ex)
                {
                    noteInfoEntry = new NoteInfoEntry();
                }
            }
            this.Text = noteInfoEntry.Name + " - " + Application.ProductName;
            NoteControl_SizeAvailable(sender,EventArgs.Empty);
            loadCurrentPage();
        }

        private void InkCanvas_StrokeErasing(object sender, InkCanvasStrokeErasingEventArgs e)
        {
            if (btnUsePen.Checked) {
                if (e.Stroke.DrawingAttributes.IsHighlighter) {
                    e.Cancel = true;
                }
            }
            if (btnUseMarker.Checked)
            {
                if (!e.Stroke.DrawingAttributes.IsHighlighter)
                {
                    e.Cancel = true;
                }
            }
        }

        System.Windows.Ink.DrawingAttributes normalPenAttribute = new System.Windows.Ink.DrawingAttributes();
        System.Windows.Ink.DrawingAttributes hilighterAttribute = new System.Windows.Ink.DrawingAttributes();


        private void btnUsePen_Click(object sender, EventArgs e)
        {
            NoteControl.EditingMode = InkCanvasEditingMode.Ink;
            NoteControl.EditingModeInverted = InkCanvasEditingMode.EraseByStroke;
            inkCanvas.DefaultDrawingAttributes = normalPenAttribute;
            currentMenu = ((System.Windows.Forms.Control)sender).ContextMenuStrip;
            double size = 8;
            inkCanvas.EraserShape = new System.Windows.Ink.RectangleStylusShape(size, size);
        }

        private void btnUseMarker_Click(object sender, EventArgs e)
        {
            NoteControl.EditingMode = InkCanvasEditingMode.Ink;
            NoteControl.EditingModeInverted = InkCanvasEditingMode.EraseByStroke; 
            inkCanvas.DefaultDrawingAttributes = hilighterAttribute; 
            currentMenu = ((System.Windows.Forms.Control)sender).ContextMenuStrip;
            double size = 8;
            inkCanvas.EraserShape = new System.Windows.Ink.RectangleStylusShape(size, size);
        }
        private void btnUseEraser_Click(object sender, EventArgs e)
        {
            NoteControl.EditingMode = InkCanvasEditingMode.EraseByPoint;
            NoteControl.EditingModeInverted = InkCanvasEditingMode.EraseByStroke;
            currentMenu = ((System.Windows.Forms.Control)sender).ContextMenuStrip;

            double size =eraseModeSize;
            inkCanvas.EraserShape = new System.Windows.Ink.RectangleStylusShape(size, size);
        }

        double eraseModeSize = 8;

        private void btnUseSelection_Click(object sender, EventArgs e)
        {
            NoteControl.EditingMode = InkCanvasEditingMode.Select;
            NoteControl.EditingModeInverted = InkCanvasEditingMode.Select;
            currentMenu = ((System.Windows.Forms.Control)sender).ContextMenuStrip;
            double size = 8;
            inkCanvas.EraserShape = new System.Windows.Ink.RectangleStylusShape(size, size);
            
        }

        
        private void mnuPenColor_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            System.Drawing.Color color = mnu.ForeColor;
            normalPenAttribute.Color = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        private void mnuPenSize_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            double size =double.Parse(mnu.Tag.ToString());
            normalPenAttribute.Width = size;
            normalPenAttribute.Height = size;
        }

        private void mnuPenSmooth_Click(object sender, EventArgs e)
        {
            normalPenAttribute.FitToCurve = mnuPenSmooth.Checked;
        }

        private void mnuPenPressure_Click(object sender, EventArgs e)
        {
            normalPenAttribute.IgnorePressure = !mnuPenPressure.Checked;
        }

        private void mnuMarkerColor_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            System.Drawing.Color color = mnu.ForeColor;
            hilighterAttribute.Color = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        private void mnuMarkerSize_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            double size = double.Parse(mnu.Tag.ToString());
            hilighterAttribute.Width = 3;
            hilighterAttribute.Height = size;
        }

        private void mnuEraserSize_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            double size = double.Parse(mnu.Tag.ToString());
            inkCanvas.EraserShape = new System.Windows.Ink.RectangleStylusShape(size, size);
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            if (inkCanvas.GetSelectedStrokes().Count > 0)
            {
                inkCanvas.CutSelection();
            }
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            if (inkCanvas.GetSelectedStrokes().Count > 0)
            {
                inkCanvas.CopySelection();
            }
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            if (inkCanvas.CanPaste())
            {
                inkCanvas.Paste();
                NoteControl.NotifyStrokesChanged();
                undoPushStateCd = 8;
            }
        }

        private void mnuCopyAndThenPaste_Click(object sender, EventArgs e)
        {
            if (inkCanvas.GetSelectedStrokes().Count > 0)
            {
                inkCanvas.CopySelection();
                if (inkCanvas.CanPaste())
                {
                    inkCanvas.Paste();
                    NoteControl.NotifyStrokesChanged(); 
                    undoPushStateCd = 8;
                }
            }
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            inkCanvas.Strokes.Remove(inkCanvas.GetSelectedStrokes());

            NoteControl.NotifyStrokesChanged();
            undoPushStateCd = 16;
        }

        int undoPushStateCd = 0;
        private void undoAutoTimer_Tick(object sender, EventArgs e)
        {
            
            if (NoteControl.IsStylusIn)
            {
                undoPushStateCd = 32;

            }
            else
            {
                if (redoPushedState.Count > 0) {
                    if (NoteControl.StrokesChanged())
                    {
                        redoPushedState.Clear();
                    }
                }
                if (redoPushedState.Count == 0)
                {
                    if (!NoteControl.StrokesChanged())
                    {
                        undoPushStateCd = 0;
                    }
                    if (undoPushStateCd > 0)
                    {
                        undoPushStateCd--;
                        if (undoPushStateCd == 0)
                        {
                            undoPushState();
                            NoteControl.ClearStrokeChanged();
                        }
                    }
                }
               
            }
            numUndoCd.Value = undoPushStateCd;
            
        }

        List<byte[]> undoPushedState = new List<byte[]>();
        List<byte[]> redoPushedState = new List<byte[]>();
        byte[] currentUnpushedState = new byte[0];
        private void undoPushState() { 
            undoPushedState.Add(currentUnpushedState);
            currentUnpushedState = Stroke2Bytes(inkCanvas.Strokes);
            while (undoPushedState.Count > 30)
            {
                undoPushedState.RemoveAt(0);
            }
        }

        private byte[] Stroke2Bytes(StrokeCollection strokes)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                strokes.Save(ms);
                return ms.ToArray();
            }
        }

        


        private void redoPushState() {
            redoPushedState.Add(currentUnpushedState);
            while (redoPushedState.Count > 30)
            {
                redoPushedState.RemoveAt(0);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (undoPushedState.Count > 0)
            {
                redoPushState();
                currentUnpushedState = undoPushedState[undoPushedState.Count - 1];
                inkCanvas.Strokes = Byte2Strokes(currentUnpushedState);
                undoPushedState.RemoveAt(undoPushedState.Count - 1);
            }
            else
            {
                Toast.ShowMessage("没有更多步骤");
            }
        }

        private StrokeCollection Byte2Strokes(byte[] b)
        {
            if (b.Length == 0)
            {
                return new StrokeCollection();
            }
            using(MemoryStream ms = new MemoryStream(b))
            {
                return new StrokeCollection(ms);
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (redoPushedState.Count > 0)
            {
                undoPushState();
                currentUnpushedState  = redoPushedState[redoPushedState.Count - 1];
                inkCanvas.Strokes = Byte2Strokes(currentUnpushedState);
                redoPushedState.RemoveAt(redoPushedState.Count - 1);
            }
            else
            {
                Toast.ShowMessage("没有更多步骤");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();
            Toast.ShowMessage("保存成功");
        }

        private void DoSave()
        {
            noteInfoEntry.PaperWidth = NoteControl.sizeAccessor.ActualWidth;
            noteInfoEntry.PaperHeight = NoteControl.sizeAccessor.ActualHeight;
            noteInfoEntry.LastAccess = DateTime.Now.ToFileTime();
            File.WriteAllText(Path.Combine(Program.WorkingDir, "level.dat"), JsonConvert.Serialize(noteInfoEntry));
            if (!Directory.Exists(Path.Combine(Program.WorkingDir, "pages")))
            {
                Directory.CreateDirectory(Path.Combine(Program.WorkingDir, "pages"));
            }
            using (FileStream fs = File.OpenWrite(Path.Combine(Program.WorkingDir,"pages" ,"page" + noteInfoEntry.PageIndex + ".ink")))
            {
                inkCanvas.Strokes.Save(fs);
            }
        }

        private NoteInfoEntry noteInfoEntry = new NoteInfoEntry();

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DoSave();
            Program.gotoTitle = true;
            Close();

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if(noteInfoEntry.PageIndex > 1)
            {
                DoSave();

                noteInfoEntry.PageIndex--;
                if (inkCanvas.Strokes.Count == 0 && noteInfoEntry.PageCount == noteInfoEntry.PageIndex+1)
                {
                    noteInfoEntry.PageCount--;
                }
                loadCurrentPage();
            }
        }

        public void loadCurrentPage()
        {
            undoPushedState.Clear();
            redoPushedState.Clear();
            inkCanvas.Strokes.Clear();
            String fileName = Path.Combine(Program.WorkingDir,"pages", "page" + noteInfoEntry.PageIndex + ".ink");
            if (File.Exists(fileName))
            {
                using(FileStream fs = File.OpenRead(fileName))
                {
                    inkCanvas.Strokes = new StrokeCollection(fs);
                }
            }
            currentUnpushedState = Stroke2Bytes(inkCanvas.Strokes);
            lblNoteIndicator.Text = noteInfoEntry.PageIndex+"/"+noteInfoEntry.PageCount;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (noteInfoEntry.PageIndex < 4096)
            {
                DoSave();

                noteInfoEntry.PageIndex++;
                if (noteInfoEntry.PageCount < noteInfoEntry.PageIndex)
                {
                    noteInfoEntry.PageCount = noteInfoEntry.PageIndex;
                }
                loadCurrentPage();
            }
        }

        bool sizeLoaded = false;
        private void NoteControl_SizeAvailable(object sender, EventArgs e)
        {
            if(noteInfoEntry.PaperWidth < 0)
            {
                sizeLoaded = true;
                return;
            }
            if (!sizeLoaded)
            {
                sizeLoaded = true;
                double innerWidth = NoteControl.sizeAccessor.ActualWidth;
                double innerHeight = NoteControl.sizeAccessor.ActualHeight;
                double outerWidth = noteContainer.Width;
                double outerHeight = noteContainer.Height;
                
                double windowWidth = this.Width;
                double windowHeight = this.Height;

                double deltaWidth = windowWidth - outerWidth;
                double deltaHeight = windowHeight - outerHeight;

                double widthFactor = outerWidth / innerWidth;
                double heightFactor = outerHeight / innerHeight;

                double requiredOuterWidth = noteInfoEntry.PaperWidth * widthFactor;
                double requiredOuterHeight = noteInfoEntry.PaperHeight * heightFactor;

                double requiredWindowWidth = requiredOuterWidth + deltaWidth;
                double requiredWindowHeight = requiredOuterHeight + deltaHeight;

                this.SuspendLayout();
                int width = (int)Math.Round(Math.Max(requiredWindowWidth,this.MinimumSize.Width));
                int height = (int)Math.Round(Math.Max(requiredWindowHeight, this.MinimumSize.Height));
                this.Size = new Size(width, height);
                this.ResumeLayout();
            }
            else
            {
                noteInfoEntry.PaperWidth = NoteControl.sizeAccessor.ActualWidth;
                noteInfoEntry.PaperHeight = NoteControl.sizeAccessor.ActualHeight;
            }
        }

        private void FrmNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            DoSave();
        }
    }
}
