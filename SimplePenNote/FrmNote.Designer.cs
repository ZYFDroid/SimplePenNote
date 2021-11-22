namespace SimplePenNote
{
    partial class FrmNote
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.noteContainer = new System.Windows.Forms.Integration.ElementHost();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuit = new SimplePenNote.MyButton();
            this.btnSave = new SimplePenNote.MyButton();
            this.btnNext = new SimplePenNote.MyButton();
            this.btnPrev = new SimplePenNote.MyButton();
            this.lblNoteIndicator = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUsePen = new SimplePenNote.MyRadioButton();
            this.mnuPen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuPenColor = new System.Windows.Forms.ToolStripMenuItem();
            this.赤红ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.烈火ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.青翠ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.苍穹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.紫罗兰ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.品红ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPenSize = new System.Windows.Forms.ToolStripMenuItem();
            this.正常ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更粗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPenSmooth = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPenPressure = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUseMarker = new SimplePenNote.MyRadioButton();
            this.mnuMarker = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMarkerColor = new System.Windows.Forms.ToolStripMenuItem();
            this.樱花粉ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.翡翠绿ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.天真蓝ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.紫罗兰ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMarkerSize = new System.Windows.Forms.ToolStripMenuItem();
            this.中ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.宽ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUseBrush = new SimplePenNote.MyRadioButton();
            this.mnuEraser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEraserSize = new System.Windows.Forms.ToolStripMenuItem();
            this.中ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.再大点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.还要更大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUseSelect = new SimplePenNote.MyRadioButton();
            this.mnuSelection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyAndThenPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUndo = new SimplePenNote.MyButton();
            this.numUndoCd = new System.Windows.Forms.ProgressBar();
            this.btnRedo = new SimplePenNote.MyButton();
            this.undoAutoTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.mnuPen.SuspendLayout();
            this.mnuMarker.SuspendLayout();
            this.mnuEraser.SuspendLayout();
            this.mnuSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // noteContainer
            // 
            this.noteContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noteContainer.Location = new System.Drawing.Point(67, 3);
            this.noteContainer.Name = "noteContainer";
            this.noteContainer.Size = new System.Drawing.Size(677, 925);
            this.noteContainer.TabIndex = 0;
            this.noteContainer.Text = "NoteControlContainer";
            this.noteContainer.Child = null;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.noteContainer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(747, 931);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(58, 925);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnQuit);
            this.flowLayoutPanel3.Controls.Add(this.btnSave);
            this.flowLayoutPanel3.Controls.Add(this.btnNext);
            this.flowLayoutPanel3.Controls.Add(this.btnPrev);
            this.flowLayoutPanel3.Controls.Add(this.lblNoteIndicator);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 621);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(58, 304);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuit.Image = global::SimplePenNote.Properties.Resources.退出;
            this.btnQuit.Location = new System.Drawing.Point(0, 246);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(58, 58);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "返回";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::SimplePenNote.Properties.Resources.卷轴;
            this.btnSave.Location = new System.Drawing.Point(0, 185);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(58, 58);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = global::SimplePenNote.Properties.Resources.下一页;
            this.btnNext.Location = new System.Drawing.Point(0, 124);
            this.btnNext.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(58, 58);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "下一页";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Image = global::SimplePenNote.Properties.Resources.上一页;
            this.btnPrev.Location = new System.Drawing.Point(0, 63);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(58, 58);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "上一页";
            this.btnPrev.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lblNoteIndicator
            // 
            this.lblNoteIndicator.Location = new System.Drawing.Point(3, 18);
            this.lblNoteIndicator.Name = "lblNoteIndicator";
            this.lblNoteIndicator.Size = new System.Drawing.Size(52, 42);
            this.lblNoteIndicator.TabIndex = 4;
            this.lblNoteIndicator.Text = "1/1";
            this.lblNoteIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnUsePen);
            this.flowLayoutPanel2.Controls.Add(this.btnUseMarker);
            this.flowLayoutPanel2.Controls.Add(this.btnUseBrush);
            this.flowLayoutPanel2.Controls.Add(this.btnUseSelect);
            this.flowLayoutPanel2.Controls.Add(this.btnUndo);
            this.flowLayoutPanel2.Controls.Add(this.numUndoCd);
            this.flowLayoutPanel2.Controls.Add(this.btnRedo);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(58, 392);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnUsePen
            // 
            this.btnUsePen.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnUsePen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.btnUsePen.Checked = true;
            this.btnUsePen.ContextMenuStrip = this.mnuPen;
            this.btnUsePen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsePen.Image = global::SimplePenNote.Properties.Resources.线性羽毛笔;
            this.btnUsePen.Location = new System.Drawing.Point(0, 0);
            this.btnUsePen.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnUsePen.Name = "btnUsePen";
            this.btnUsePen.Size = new System.Drawing.Size(58, 58);
            this.btnUsePen.TabIndex = 0;
            this.btnUsePen.TabStop = true;
            this.btnUsePen.Text = "书写";
            this.btnUsePen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUsePen.UseVisualStyleBackColor = false;
            this.btnUsePen.Click += new System.EventHandler(this.btnUsePen_Click);
            // 
            // mnuPen
            // 
            this.mnuPen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPenColor,
            this.赤红ToolStripMenuItem,
            this.烈火ToolStripMenuItem,
            this.青翠ToolStripMenuItem,
            this.苍穹ToolStripMenuItem,
            this.紫罗兰ToolStripMenuItem,
            this.品红ToolStripMenuItem,
            this.toolStripSeparator1,
            this.mnuPenSize,
            this.正常ToolStripMenuItem,
            this.粗ToolStripMenuItem,
            this.更粗ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.mnuPenSmooth,
            this.mnuPenPressure});
            this.mnuPen.Name = "mnuPen";
            this.mnuPen.Size = new System.Drawing.Size(173, 576);
            // 
            // mnuPenColor
            // 
            this.mnuPenColor.Name = "mnuPenColor";
            this.mnuPenColor.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.mnuPenColor.Size = new System.Drawing.Size(172, 40);
            this.mnuPenColor.Text = "■ 浓墨";
            this.mnuPenColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuPenColor.Click += new System.EventHandler(this.mnuPenColor_Click);
            // 
            // 赤红ToolStripMenuItem
            // 
            this.赤红ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.赤红ToolStripMenuItem.Name = "赤红ToolStripMenuItem";
            this.赤红ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.赤红ToolStripMenuItem.Size = new System.Drawing.Size(172, 40);
            this.赤红ToolStripMenuItem.Text = "■ 赤红";
            this.赤红ToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.赤红ToolStripMenuItem.Click += new System.EventHandler(this.mnuPenColor_Click);
            // 
            // 烈火ToolStripMenuItem
            // 
            this.烈火ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.烈火ToolStripMenuItem.Name = "烈火ToolStripMenuItem";
            this.烈火ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.烈火ToolStripMenuItem.Size = new System.Drawing.Size(172, 40);
            this.烈火ToolStripMenuItem.Text = "■ 烈火";
            this.烈火ToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.烈火ToolStripMenuItem.Click += new System.EventHandler(this.mnuPenColor_Click);
            // 
            // 青翠ToolStripMenuItem
            // 
            this.青翠ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.青翠ToolStripMenuItem.Name = "青翠ToolStripMenuItem";
            this.青翠ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.青翠ToolStripMenuItem.Size = new System.Drawing.Size(172, 40);
            this.青翠ToolStripMenuItem.Text = "■ 青翠";
            this.青翠ToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.青翠ToolStripMenuItem.Click += new System.EventHandler(this.mnuPenColor_Click);
            // 
            // 苍穹ToolStripMenuItem
            // 
            this.苍穹ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.苍穹ToolStripMenuItem.Name = "苍穹ToolStripMenuItem";
            this.苍穹ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.苍穹ToolStripMenuItem.Size = new System.Drawing.Size(172, 40);
            this.苍穹ToolStripMenuItem.Text = "■ 苍穹";
            this.苍穹ToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.苍穹ToolStripMenuItem.Click += new System.EventHandler(this.mnuPenColor_Click);
            // 
            // 紫罗兰ToolStripMenuItem
            // 
            this.紫罗兰ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(13)))), ((int)(((byte)(255)))));
            this.紫罗兰ToolStripMenuItem.Name = "紫罗兰ToolStripMenuItem";
            this.紫罗兰ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.紫罗兰ToolStripMenuItem.Size = new System.Drawing.Size(172, 40);
            this.紫罗兰ToolStripMenuItem.Text = "■ 桔梗";
            this.紫罗兰ToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.紫罗兰ToolStripMenuItem.Click += new System.EventHandler(this.mnuPenColor_Click);
            // 
            // 品红ToolStripMenuItem
            // 
            this.品红ToolStripMenuItem.ForeColor = System.Drawing.Color.Fuchsia;
            this.品红ToolStripMenuItem.Name = "品红ToolStripMenuItem";
            this.品红ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.品红ToolStripMenuItem.Size = new System.Drawing.Size(172, 40);
            this.品红ToolStripMenuItem.Text = "■ 品红";
            this.品红ToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.品红ToolStripMenuItem.Click += new System.EventHandler(this.mnuPenColor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // mnuPenSize
            // 
            this.mnuPenSize.Name = "mnuPenSize";
            this.mnuPenSize.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.mnuPenSize.Size = new System.Drawing.Size(172, 40);
            this.mnuPenSize.Tag = "1";
            this.mnuPenSize.Text = "细";
            this.mnuPenSize.Click += new System.EventHandler(this.mnuPenSize_Click);
            // 
            // 正常ToolStripMenuItem
            // 
            this.正常ToolStripMenuItem.Name = "正常ToolStripMenuItem";
            this.正常ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.正常ToolStripMenuItem.Size = new System.Drawing.Size(172, 40);
            this.正常ToolStripMenuItem.Tag = "1.5";
            this.正常ToolStripMenuItem.Text = "正常";
            this.正常ToolStripMenuItem.Click += new System.EventHandler(this.mnuPenSize_Click);
            // 
            // 粗ToolStripMenuItem
            // 
            this.粗ToolStripMenuItem.Name = "粗ToolStripMenuItem";
            this.粗ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.粗ToolStripMenuItem.Size = new System.Drawing.Size(172, 40);
            this.粗ToolStripMenuItem.Tag = "3.6";
            this.粗ToolStripMenuItem.Text = "粗";
            this.粗ToolStripMenuItem.Click += new System.EventHandler(this.mnuPenSize_Click);
            // 
            // 更粗ToolStripMenuItem
            // 
            this.更粗ToolStripMenuItem.Name = "更粗ToolStripMenuItem";
            this.更粗ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.更粗ToolStripMenuItem.Size = new System.Drawing.Size(172, 40);
            this.更粗ToolStripMenuItem.Tag = "6.4";
            this.更粗ToolStripMenuItem.Text = "更粗";
            this.更粗ToolStripMenuItem.Click += new System.EventHandler(this.mnuPenSize_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 40);
            this.toolStripMenuItem2.Tag = "24";
            this.toolStripMenuItem2.Text = "我猜你想要记号笔";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.mnuPenSize_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // mnuPenSmooth
            // 
            this.mnuPenSmooth.Checked = true;
            this.mnuPenSmooth.CheckOnClick = true;
            this.mnuPenSmooth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuPenSmooth.Name = "mnuPenSmooth";
            this.mnuPenSmooth.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.mnuPenSmooth.Size = new System.Drawing.Size(172, 40);
            this.mnuPenSmooth.Text = "平滑";
            this.mnuPenSmooth.Click += new System.EventHandler(this.mnuPenSmooth_Click);
            // 
            // mnuPenPressure
            // 
            this.mnuPenPressure.Checked = true;
            this.mnuPenPressure.CheckOnClick = true;
            this.mnuPenPressure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuPenPressure.Name = "mnuPenPressure";
            this.mnuPenPressure.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.mnuPenPressure.Size = new System.Drawing.Size(172, 40);
            this.mnuPenPressure.Text = "压力感应";
            this.mnuPenPressure.Click += new System.EventHandler(this.mnuPenPressure_Click);
            // 
            // btnUseMarker
            // 
            this.btnUseMarker.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnUseMarker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.btnUseMarker.ContextMenuStrip = this.mnuMarker;
            this.btnUseMarker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUseMarker.Image = global::SimplePenNote.Properties.Resources.魔法棒;
            this.btnUseMarker.Location = new System.Drawing.Point(0, 61);
            this.btnUseMarker.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnUseMarker.Name = "btnUseMarker";
            this.btnUseMarker.Size = new System.Drawing.Size(58, 58);
            this.btnUseMarker.TabIndex = 1;
            this.btnUseMarker.Text = "标记";
            this.btnUseMarker.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUseMarker.UseVisualStyleBackColor = false;
            this.btnUseMarker.Click += new System.EventHandler(this.btnUseMarker_Click);
            // 
            // mnuMarker
            // 
            this.mnuMarker.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.mnuMarkerColor,
            this.樱花粉ToolStripMenuItem,
            this.翡翠绿ToolStripMenuItem,
            this.天真蓝ToolStripMenuItem,
            this.紫罗兰ToolStripMenuItem1,
            this.toolStripSeparator3,
            this.mnuMarkerSize,
            this.中ToolStripMenuItem,
            this.宽ToolStripMenuItem});
            this.mnuMarker.Name = "mnuMarker";
            this.mnuMarker.Size = new System.Drawing.Size(124, 370);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(123, 40);
            this.toolStripMenuItem1.Text = "■ 凋叶棕";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.mnuMarkerColor_Click);
            // 
            // mnuMarkerColor
            // 
            this.mnuMarkerColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mnuMarkerColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(255)))), ((int)(((byte)(4)))));
            this.mnuMarkerColor.Name = "mnuMarkerColor";
            this.mnuMarkerColor.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.mnuMarkerColor.Size = new System.Drawing.Size(123, 40);
            this.mnuMarkerColor.Text = "■ 荧光黄";
            this.mnuMarkerColor.Click += new System.EventHandler(this.mnuMarkerColor_Click);
            // 
            // 樱花粉ToolStripMenuItem
            // 
            this.樱花粉ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.樱花粉ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(181)))), ((int)(((byte)(237)))));
            this.樱花粉ToolStripMenuItem.Name = "樱花粉ToolStripMenuItem";
            this.樱花粉ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.樱花粉ToolStripMenuItem.Size = new System.Drawing.Size(123, 40);
            this.樱花粉ToolStripMenuItem.Text = "■ 樱花粉";
            this.樱花粉ToolStripMenuItem.Click += new System.EventHandler(this.mnuMarkerColor_Click);
            // 
            // 翡翠绿ToolStripMenuItem
            // 
            this.翡翠绿ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.翡翠绿ToolStripMenuItem.ForeColor = System.Drawing.Color.Lime;
            this.翡翠绿ToolStripMenuItem.Name = "翡翠绿ToolStripMenuItem";
            this.翡翠绿ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.翡翠绿ToolStripMenuItem.Size = new System.Drawing.Size(123, 40);
            this.翡翠绿ToolStripMenuItem.Text = "■ 翡翠绿";
            this.翡翠绿ToolStripMenuItem.Click += new System.EventHandler(this.mnuMarkerColor_Click);
            // 
            // 天真蓝ToolStripMenuItem
            // 
            this.天真蓝ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.天真蓝ToolStripMenuItem.ForeColor = System.Drawing.Color.Cyan;
            this.天真蓝ToolStripMenuItem.Name = "天真蓝ToolStripMenuItem";
            this.天真蓝ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.天真蓝ToolStripMenuItem.Size = new System.Drawing.Size(123, 40);
            this.天真蓝ToolStripMenuItem.Text = "■ 天真蓝";
            this.天真蓝ToolStripMenuItem.Click += new System.EventHandler(this.mnuMarkerColor_Click);
            // 
            // 紫罗兰ToolStripMenuItem1
            // 
            this.紫罗兰ToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.紫罗兰ToolStripMenuItem1.ForeColor = System.Drawing.Color.Fuchsia;
            this.紫罗兰ToolStripMenuItem1.Name = "紫罗兰ToolStripMenuItem1";
            this.紫罗兰ToolStripMenuItem1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.紫罗兰ToolStripMenuItem1.Size = new System.Drawing.Size(123, 40);
            this.紫罗兰ToolStripMenuItem1.Text = "■ 紫罗兰";
            this.紫罗兰ToolStripMenuItem1.Click += new System.EventHandler(this.mnuMarkerColor_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.toolStripSeparator3.Size = new System.Drawing.Size(120, 6);
            // 
            // mnuMarkerSize
            // 
            this.mnuMarkerSize.Name = "mnuMarkerSize";
            this.mnuMarkerSize.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.mnuMarkerSize.Size = new System.Drawing.Size(123, 40);
            this.mnuMarkerSize.Tag = "20";
            this.mnuMarkerSize.Text = "窄";
            this.mnuMarkerSize.Click += new System.EventHandler(this.mnuMarkerSize_Click);
            // 
            // 中ToolStripMenuItem
            // 
            this.中ToolStripMenuItem.Name = "中ToolStripMenuItem";
            this.中ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.中ToolStripMenuItem.Size = new System.Drawing.Size(123, 40);
            this.中ToolStripMenuItem.Tag = "40";
            this.中ToolStripMenuItem.Text = "中";
            this.中ToolStripMenuItem.Click += new System.EventHandler(this.mnuMarkerSize_Click);
            // 
            // 宽ToolStripMenuItem
            // 
            this.宽ToolStripMenuItem.Name = "宽ToolStripMenuItem";
            this.宽ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.宽ToolStripMenuItem.Size = new System.Drawing.Size(123, 40);
            this.宽ToolStripMenuItem.Tag = "60";
            this.宽ToolStripMenuItem.Text = "宽";
            this.宽ToolStripMenuItem.Click += new System.EventHandler(this.mnuMarkerSize_Click);
            // 
            // btnUseBrush
            // 
            this.btnUseBrush.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnUseBrush.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.btnUseBrush.ContextMenuStrip = this.mnuEraser;
            this.btnUseBrush.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUseBrush.Image = global::SimplePenNote.Properties.Resources.线性橡皮;
            this.btnUseBrush.Location = new System.Drawing.Point(0, 122);
            this.btnUseBrush.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnUseBrush.Name = "btnUseBrush";
            this.btnUseBrush.Size = new System.Drawing.Size(58, 58);
            this.btnUseBrush.TabIndex = 0;
            this.btnUseBrush.Text = "消除";
            this.btnUseBrush.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUseBrush.UseVisualStyleBackColor = false;
            this.btnUseBrush.Click += new System.EventHandler(this.btnUseEraser_Click);
            // 
            // mnuEraser
            // 
            this.mnuEraser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEraserSize,
            this.中ToolStripMenuItem1,
            this.大ToolStripMenuItem,
            this.再大点ToolStripMenuItem,
            this.还要更大ToolStripMenuItem});
            this.mnuEraser.Name = "mnuEraser";
            this.mnuEraser.Size = new System.Drawing.Size(125, 204);
            // 
            // mnuEraserSize
            // 
            this.mnuEraserSize.Name = "mnuEraserSize";
            this.mnuEraserSize.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.mnuEraserSize.Size = new System.Drawing.Size(124, 40);
            this.mnuEraserSize.Tag = "8";
            this.mnuEraserSize.Text = "小";
            this.mnuEraserSize.Click += new System.EventHandler(this.mnuEraserSize_Click);
            // 
            // 中ToolStripMenuItem1
            // 
            this.中ToolStripMenuItem1.Name = "中ToolStripMenuItem1";
            this.中ToolStripMenuItem1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.中ToolStripMenuItem1.Size = new System.Drawing.Size(124, 40);
            this.中ToolStripMenuItem1.Tag = "16";
            this.中ToolStripMenuItem1.Text = "中";
            this.中ToolStripMenuItem1.Click += new System.EventHandler(this.mnuEraserSize_Click);
            // 
            // 大ToolStripMenuItem
            // 
            this.大ToolStripMenuItem.Name = "大ToolStripMenuItem";
            this.大ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.大ToolStripMenuItem.Size = new System.Drawing.Size(124, 40);
            this.大ToolStripMenuItem.Tag = "24";
            this.大ToolStripMenuItem.Text = "大";
            this.大ToolStripMenuItem.Click += new System.EventHandler(this.mnuEraserSize_Click);
            // 
            // 再大点ToolStripMenuItem
            // 
            this.再大点ToolStripMenuItem.Name = "再大点ToolStripMenuItem";
            this.再大点ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.再大点ToolStripMenuItem.Size = new System.Drawing.Size(124, 40);
            this.再大点ToolStripMenuItem.Tag = "32";
            this.再大点ToolStripMenuItem.Text = "再大点";
            this.再大点ToolStripMenuItem.Click += new System.EventHandler(this.mnuEraserSize_Click);
            // 
            // 还要更大ToolStripMenuItem
            // 
            this.还要更大ToolStripMenuItem.Name = "还要更大ToolStripMenuItem";
            this.还要更大ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.还要更大ToolStripMenuItem.Size = new System.Drawing.Size(124, 40);
            this.还要更大ToolStripMenuItem.Tag = "96";
            this.还要更大ToolStripMenuItem.Text = "还要更大";
            this.还要更大ToolStripMenuItem.Click += new System.EventHandler(this.mnuEraserSize_Click);
            // 
            // btnUseSelect
            // 
            this.btnUseSelect.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnUseSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.btnUseSelect.ContextMenuStrip = this.mnuSelection;
            this.btnUseSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUseSelect.Image = global::SimplePenNote.Properties.Resources.script_medium;
            this.btnUseSelect.Location = new System.Drawing.Point(0, 183);
            this.btnUseSelect.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnUseSelect.Name = "btnUseSelect";
            this.btnUseSelect.Size = new System.Drawing.Size(58, 58);
            this.btnUseSelect.TabIndex = 0;
            this.btnUseSelect.Text = "选择";
            this.btnUseSelect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUseSelect.UseVisualStyleBackColor = false;
            this.btnUseSelect.Click += new System.EventHandler(this.btnUseSelection_Click);
            // 
            // mnuSelection
            // 
            this.mnuSelection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCut,
            this.mnuCopy,
            this.mnuCopyAndThenPaste,
            this.mnuPaste,
            this.mnuDelete});
            this.mnuSelection.Name = "mnuSelection";
            this.mnuSelection.Size = new System.Drawing.Size(161, 204);
            // 
            // mnuCut
            // 
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.mnuCut.Size = new System.Drawing.Size(160, 40);
            this.mnuCut.Text = "剪切";
            this.mnuCut.Click += new System.EventHandler(this.mnuCut_Click);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.mnuCopy.Size = new System.Drawing.Size(160, 40);
            this.mnuCopy.Text = "复制";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // mnuCopyAndThenPaste
            // 
            this.mnuCopyAndThenPaste.Name = "mnuCopyAndThenPaste";
            this.mnuCopyAndThenPaste.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.mnuCopyAndThenPaste.Size = new System.Drawing.Size(160, 40);
            this.mnuCopyAndThenPaste.Text = "复制，然后粘贴";
            this.mnuCopyAndThenPaste.Click += new System.EventHandler(this.mnuCopyAndThenPaste_Click);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.mnuPaste.Size = new System.Drawing.Size(160, 40);
            this.mnuPaste.Text = "粘贴";
            this.mnuPaste.Click += new System.EventHandler(this.mnuPaste_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.mnuDelete.Size = new System.Drawing.Size(160, 40);
            this.mnuDelete.Text = "删除";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Image = global::SimplePenNote.Properties.Resources.revoke;
            this.btnUndo.Location = new System.Drawing.Point(0, 244);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(0);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(58, 58);
            this.btnUndo.TabIndex = 2;
            this.btnUndo.Text = "撤销";
            this.btnUndo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // numUndoCd
            // 
            this.numUndoCd.Location = new System.Drawing.Point(2, 304);
            this.numUndoCd.Margin = new System.Windows.Forms.Padding(2);
            this.numUndoCd.Maximum = 32;
            this.numUndoCd.Name = "numUndoCd";
            this.numUndoCd.Size = new System.Drawing.Size(54, 12);
            this.numUndoCd.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.numUndoCd.TabIndex = 4;
            this.numUndoCd.Visible = false;
            // 
            // btnRedo
            // 
            this.btnRedo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.btnRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedo.Image = global::SimplePenNote.Properties.Resources._return;
            this.btnRedo.Location = new System.Drawing.Point(0, 318);
            this.btnRedo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(58, 58);
            this.btnRedo.TabIndex = 3;
            this.btnRedo.Text = "恢复";
            this.btnRedo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRedo.UseVisualStyleBackColor = false;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // undoAutoTimer
            // 
            this.undoAutoTimer.Enabled = true;
            this.undoAutoTimer.Interval = 1;
            this.undoAutoTimer.Tick += new System.EventHandler(this.undoAutoTimer_Tick);
            // 
            // FrmNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(747, 931);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(763, 970);
            this.Name = "FrmNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "《因为嫌微软商店的笔记太难用所以自己写的笔记软件你会喜欢吗》";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNote_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.mnuPen.ResumeLayout(false);
            this.mnuMarker.ResumeLayout(false);
            this.mnuEraser.ResumeLayout(false);
            this.mnuSelection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost noteContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private SimplePenNote.MyRadioButton btnUsePen;
        private SimplePenNote.MyRadioButton btnUseBrush;
        private SimplePenNote.MyRadioButton btnUseSelect;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private SimplePenNote.MyButton btnPrev;
        private SimplePenNote.MyButton btnNext;
        private SimplePenNote.MyButton btnSave;
        private SimplePenNote.MyButton btnQuit;
        private SimplePenNote.MyRadioButton btnUseMarker;
        private System.Windows.Forms.ContextMenuStrip mnuPen;
        private System.Windows.Forms.ContextMenuStrip mnuMarker;
        private System.Windows.Forms.ContextMenuStrip mnuEraser;
        private System.Windows.Forms.ContextMenuStrip mnuSelection;
        private System.Windows.Forms.ToolStripMenuItem mnuPenColor;
        private System.Windows.Forms.ToolStripMenuItem 赤红ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 烈火ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 青翠ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 苍穹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 紫罗兰ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 品红ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuPenSize;
        private System.Windows.Forms.ToolStripMenuItem 正常ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更粗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuPenSmooth;
        private System.Windows.Forms.ToolStripMenuItem mnuPenPressure;
        private System.Windows.Forms.ToolStripMenuItem mnuMarkerColor;
        private System.Windows.Forms.ToolStripMenuItem 樱花粉ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 翡翠绿ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 天真蓝ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 紫罗兰ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuMarkerSize;
        private System.Windows.Forms.ToolStripMenuItem 中ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 宽ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEraserSize;
        private System.Windows.Forms.ToolStripMenuItem 中ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 再大点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 还要更大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.Label lblNoteIndicator;
        private SimplePenNote.MyButton btnUndo;
        private SimplePenNote.MyButton btnRedo;
        private System.Windows.Forms.ProgressBar numUndoCd;
        private System.Windows.Forms.Timer undoAutoTimer;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyAndThenPaste;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

