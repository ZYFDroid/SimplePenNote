namespace SimplePenNote
{
    partial class FrmNoteManager
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tblNoteItems = new System.Windows.Forms.FlowLayoutPanel();
            this.sfDragger = new System.Windows.Forms.Panel();
            this.sfDragger2 = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tblFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClone = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tblHeader = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tblFooter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tblHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tblNoteItems, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.sfDragger, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.sfDragger2, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 79);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 336F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(902, 336);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tblNoteItems
            // 
            this.tblNoteItems.AutoScroll = true;
            this.tblNoteItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblNoteItems.Location = new System.Drawing.Point(151, 0);
            this.tblNoteItems.Margin = new System.Windows.Forms.Padding(0);
            this.tblNoteItems.Name = "tblNoteItems";
            this.tblNoteItems.Size = new System.Drawing.Size(600, 336);
            this.tblNoteItems.TabIndex = 0;
            // 
            // sfDragger
            // 
            this.sfDragger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfDragger.Location = new System.Drawing.Point(3, 3);
            this.sfDragger.Name = "sfDragger";
            this.sfDragger.Size = new System.Drawing.Size(145, 330);
            this.sfDragger.TabIndex = 1;
            this.sfDragger.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sfDragger_MouseDown);
            this.sfDragger.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sfDragger_MouseMove);
            this.sfDragger.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sfDragger_MouseUp);
            // 
            // sfDragger2
            // 
            this.sfDragger2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfDragger2.Location = new System.Drawing.Point(754, 3);
            this.sfDragger2.Name = "sfDragger2";
            this.sfDragger2.Size = new System.Drawing.Size(145, 330);
            this.sfDragger2.TabIndex = 1;
            this.sfDragger2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sfDragger_MouseDown);
            this.sfDragger2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sfDragger_MouseMove);
            this.sfDragger2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sfDragger_MouseUp);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.tableLayoutPanel2);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 415);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(902, 102);
            this.panelBottom.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tblFooter, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(902, 102);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tblFooter
            // 
            this.tblFooter.Controls.Add(this.btnCancel);
            this.tblFooter.Controls.Add(this.btnDelete);
            this.tblFooter.Controls.Add(this.btnClone);
            this.tblFooter.Controls.Add(this.btnRename);
            this.tblFooter.Controls.Add(this.btnNew);
            this.tblFooter.Controls.Add(this.btnOpen);
            this.tblFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFooter.Location = new System.Drawing.Point(154, 3);
            this.tblFooter.Name = "tblFooter";
            this.tblFooter.Size = new System.Drawing.Size(594, 96);
            this.tblFooter.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(426, 57);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 33);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(168, 57);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(124, 33);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClone
            // 
            this.btnClone.Enabled = false;
            this.btnClone.Location = new System.Drawing.Point(298, 57);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(124, 33);
            this.btnClone.TabIndex = 0;
            this.btnClone.Text = "重建";
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // btnRename
            // 
            this.btnRename.Enabled = false;
            this.btnRename.Location = new System.Drawing.Point(40, 57);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(124, 33);
            this.btnRename.TabIndex = 0;
            this.btnRename.Text = "编辑";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(298, 18);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(252, 33);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "创建新的笔记";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Enabled = false;
            this.btnOpen.Location = new System.Drawing.Point(40, 18);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(252, 33);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "进入选中的笔记";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.tableLayoutPanel1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(902, 79);
            this.panelTop.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tblHeader, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(902, 79);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tblHeader
            // 
            this.tblHeader.Controls.Add(this.txtSearch);
            this.tblHeader.Controls.Add(this.label1);
            this.tblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblHeader.Location = new System.Drawing.Point(154, 3);
            this.tblHeader.Name = "tblHeader";
            this.tblHeader.Size = new System.Drawing.Size(594, 73);
            this.tblHeader.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(127, 31);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(341, 26);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(594, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择笔记";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmNoteManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(902, 517);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(918, 556);
            this.Name = "FrmNoteManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "笔记管理器 - 《因为嫌微软商店的笔记太难用所以自己写的笔记软件你会喜欢吗》";
            this.Load += new System.EventHandler(this.FrmNoteManager_Load);
            this.LocationChanged += new System.EventHandler(this.FrmNoteManager_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.FrmNoteManager_SizeChanged);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tblFooter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tblHeader.ResumeLayout(false);
            this.tblHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel tblHeader;
        private System.Windows.Forms.Panel tblFooter;
        private System.Windows.Forms.FlowLayoutPanel tblNoteItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClone;
        private System.Windows.Forms.Panel sfDragger;
        private System.Windows.Forms.Panel sfDragger2;
    }
}