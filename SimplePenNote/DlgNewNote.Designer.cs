
namespace SimplePenNote
{
    partial class DlgNewNote
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
            this.tblDialogResult = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtNoteName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.tblDialogResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblDialogResult
            // 
            this.tblDialogResult.Controls.Add(this.btnCancel);
            this.tblDialogResult.Controls.Add(this.btnOk);
            this.tblDialogResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblDialogResult.Location = new System.Drawing.Point(0, 320);
            this.tblDialogResult.Name = "tblDialogResult";
            this.tblDialogResult.Size = new System.Drawing.Size(600, 58);
            this.tblDialogResult.TabIndex = 2;
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
            this.btnOk.Text = "创建新的笔记";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtNoteName
            // 
            this.txtNoteName.Location = new System.Drawing.Point(126, 89);
            this.txtNoteName.MaxLength = 32;
            this.txtNoteName.Name = "txtNoteName";
            this.txtNoteName.Size = new System.Drawing.Size(348, 29);
            this.txtNoteName.TabIndex = 6;
            this.txtNoteName.TextChanged += new System.EventHandler(this.txtNoteName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "笔记名称";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(600, 59);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "\r\n创建新的笔记";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSavePath
            // 
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSavePath.Location = new System.Drawing.Point(122, 121);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(130, 21);
            this.lblSavePath.TabIndex = 7;
            this.lblSavePath.Text = "将会保存在xxxxx";
            // 
            // DlgNewNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 378);
            this.Controls.Add(this.lblSavePath);
            this.Controls.Add(this.txtNoteName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tblDialogResult);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DlgNewNote";
            this.ShowInTaskbar = false;
            this.Text = "DlgNewNote";
            this.Load += new System.EventHandler(this.DlgNewNote_Load);
            this.tblDialogResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel tblDialogResult;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtNoteName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSavePath;
    }
}