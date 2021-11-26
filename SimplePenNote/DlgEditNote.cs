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
    public partial class DlgEditNote : Form
    {

        public NoteInfoEntry infoEntry = null;
        public string notesavePath = null;
        public DlgEditNote()
        {
            InitializeComponent();
        }

        private void DlgEditNote_Load(object sender, EventArgs e)
        {
            txtNoteName.Text = infoEntry.Name;
            dlgSavePdf.FileName = infoEntry.Name;
        }

        private void txtNoteName_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = txtNoteName.TextLength > 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            infoEntry.Name = txtNoteName.Text;
            System.IO.File.WriteAllText(System.IO.Path.Combine(notesavePath,"level.dat"),JsonConvert.Serialize(infoEntry));
            Close();
        }

        private void btnOpenDir_Click(object sender, EventArgs e)
        {
            Process.Start(Path.GetFullPath(notesavePath));
        }

        private string _pdfSavePath = "";
        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if(dlgSavePdf.ShowDialog(this) == DialogResult.OK)
            {
                btnExportPdf.Enabled = false;
                tblDialogResult.Enabled = false;
                numProgress.Visible = true;
                _pdfSavePath = dlgSavePdf.FileName;
                buildPdfWorker.RunWorkerAsync();
            }
        }

        private void buildPdfWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                buildPdfWorker.ReportProgress(0, "正在构建PDF");
                int width = (int)infoEntry.PaperWidth;
                int height = (int)infoEntry.PaperHeight;
                int pageCount = infoEntry.PageCount;
                String tempPath = Path.Combine(Path.GetTempPath(), "notebuildcache");
                Directory.CreateDirectory(tempPath);
                PdfBuildTest.StrokeUtils strokeUtils = new PdfBuildTest.StrokeUtils();
                for (int i = 1; i <= pageCount; i++)
                {
                    buildPdfWorker.ReportProgress(i * 80 / pageCount, "正在渲染页面：" + i + "/" + pageCount);
                    System.Windows.Ink.StrokeCollection strokes = null;
                    String storkePath = Path.Combine(notesavePath, "pages", "page" + i + ".ink");
                    if (File.Exists(storkePath))
                    {
                        using (FileStream fs = File.OpenRead(storkePath))
                        {
                            strokes = new System.Windows.Ink.StrokeCollection(fs);
                        }
                    }
                    else
                    {
                        strokes = new System.Windows.Ink.StrokeCollection();
                    }
                    strokeUtils.StrokeToImage(strokes, width, height, Path.Combine(tempPath, i + ".png"));
                }
                buildPdfWorker.ReportProgress(90, "正在构建PDF");

                PdfBuildTest.PDFBuilder builder = new PdfBuildTest.PDFBuilder();
                List<string> filenames = new List<string>();
                for (int i = 1; i <= pageCount; i++)
                {
                    filenames.Add(Path.Combine(tempPath, i + ".png"));
                }
                builder.BuildWithImages(filenames.ToArray());
                builder.WriteToFile(_pdfSavePath);

                MessageBox.Show("PDF保存成功", "生成Pdf");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"生成pdf失败");
            }
        }

        private void buildPdfWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            numProgress.Value = e.ProgressPercentage;
            btnExportPdf.Text = e.UserState.ToString();
        }

        private void buildPdfWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnExportPdf.Enabled = true;
            btnExportPdf.Text = "导出笔记为PDF格式";
            tblDialogResult.Enabled = true;
            numProgress.Visible = false;
        }
    }
}
