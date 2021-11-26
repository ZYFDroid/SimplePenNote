
namespace SimplePenNote
{
    partial class DlgEditNote
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tblDialogResult = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoteName = new System.Windows.Forms.TextBox();
            this.btnOpenDir = new System.Windows.Forms.Button();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.numProgress = new System.Windows.Forms.ProgressBar();
            this.buildPdfWorker = new System.ComponentModel.BackgroundWorker();
            this.dlgSavePdf = new System.Windows.Forms.SaveFileDialog();
            this.tblDialogResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "\r\n编辑笔记";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tblDialogResult
            // 
            this.tblDialogResult.Controls.Add(this.btnCancel);
            this.tblDialogResult.Controls.Add(this.btnOk);
            this.tblDialogResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblDialogResult.Location = new System.Drawing.Point(0, 320);
            this.tblDialogResult.Name = "tblDialogResult";
            this.tblDialogResult.Size = new System.Drawing.Size(600, 58);
            this.tblDialogResult.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(303, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(171, 43);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(126, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(171, 43);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "保存";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "笔记名称";
            // 
            // txtNoteName
            // 
            this.txtNoteName.Location = new System.Drawing.Point(126, 86);
            this.txtNoteName.MaxLength = 32;
            this.txtNoteName.Name = "txtNoteName";
            this.txtNoteName.Size = new System.Drawing.Size(348, 29);
            this.txtNoteName.TabIndex = 3;
            this.txtNoteName.TextChanged += new System.EventHandler(this.txtNoteName_TextChanged);
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.Location = new System.Drawing.Point(126, 132);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(348, 50);
            this.btnOpenDir.TabIndex = 4;
            this.btnOpenDir.Text = "打开存档文件夹";
            this.btnOpenDir.UseVisualStyleBackColor = true;
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.Location = new System.Drawing.Point(126, 188);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(348, 50);
            this.btnExportPdf.TabIndex = 4;
            this.btnExportPdf.Text = "导出笔记为PDF格式";
            this.btnExportPdf.UseVisualStyleBackColor = true;
            this.btnExportPdf.Click += new System.EventHandler(this.btnExportPdf_Click);
            // 
            // numProgress
            // 
            this.numProgress.Location = new System.Drawing.Point(127, 227);
            this.numProgress.Name = "numProgress";
            this.numProgress.Size = new System.Drawing.Size(346, 10);
            this.numProgress.TabIndex = 5;
            this.numProgress.Visible = false;
            // 
            // buildPdfWorker
            // 
            this.buildPdfWorker.WorkerReportsProgress = true;
            this.buildPdfWorker.WorkerSupportsCancellation = true;
            this.buildPdfWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.buildPdfWorker_DoWork);
            this.buildPdfWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.buildPdfWorker_ProgressChanged);
            this.buildPdfWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.buildPdfWorker_RunWorkerCompleted);
            // 
            // dlgSavePdf
            // 
            this.dlgSavePdf.DefaultExt = "pdf";
            this.dlgSavePdf.Filter = "PDF 文档|*.pdf";
            this.dlgSavePdf.Title = "保存PDF";
            // 
            // DlgEditNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 378);
            this.Controls.Add(this.numProgress);
            this.Controls.Add(this.btnExportPdf);
            this.Controls.Add(this.btnOpenDir);
            this.Controls.Add(this.txtNoteName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tblDialogResult);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DlgEditNote";
            this.ShowInTaskbar = false;
            this.Text = "DlgEditNote";
            this.Load += new System.EventHandler(this.DlgEditNote_Load);
            this.tblDialogResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel tblDialogResult;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoteName;
        private System.Windows.Forms.Button btnOpenDir;
        private System.Windows.Forms.Button btnExportPdf;
        private System.Windows.Forms.ProgressBar numProgress;
        private System.ComponentModel.BackgroundWorker buildPdfWorker;
        private System.Windows.Forms.SaveFileDialog dlgSavePdf;
    }
}