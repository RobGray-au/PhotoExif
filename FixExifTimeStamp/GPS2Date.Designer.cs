namespace FixExifTimeStamp
{
    partial class GPS2Date
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GPS2Date));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.title = new System.Windows.Forms.Label();
            this.butExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPhotoFolder = new System.Windows.Forms.TextBox();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDateinDescription = new System.Windows.Forms.CheckBox();
            this.tbSubfolderName = new System.Windows.Forms.TextBox();
            this.rbSubfolder = new System.Windows.Forms.RadioButton();
            this.rbOutpOverw = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCameraOffset = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbConstantOffset = new System.Windows.Forms.RadioButton();
            this.rbUseLastOffset = new System.Windows.Forms.RadioButton();
            this.butPreview = new System.Windows.Forms.Button();
            this.butProcess = new System.Windows.Forms.Button();
            this.butGetPhotoFolder = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Camera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkboxVidDatetime = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCameraOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.SystemColors.Highlight;
            this.title.Location = new System.Drawing.Point(25, 9);
            this.title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(549, 65);
            this.title.TabIndex = 3;
            this.title.Text = "Update Photo EXIF date using GPS info where available";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butExit.Location = new System.Drawing.Point(518, 396);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(65, 34);
            this.butExit.TabIndex = 20;
            this.butExit.Text = "Exit";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(44, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Photo location to be searched";
            // 
            // tbPhotoFolder
            // 
            this.tbPhotoFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPhotoFolder.Location = new System.Drawing.Point(47, 108);
            this.tbPhotoFolder.Name = "tbPhotoFolder";
            this.tbPhotoFolder.Size = new System.Drawing.Size(501, 20);
            this.tbPhotoFolder.TabIndex = 14;
            this.tbPhotoFolder.TextChanged += new System.EventHandler(this.TBPhotoFolder_TextChanged);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel1.Text = "....                ";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 460);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(607, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chkDateinDescription);
            this.groupBox1.Controls.Add(this.tbSubfolderName);
            this.groupBox1.Controls.Add(this.rbSubfolder);
            this.groupBox1.Controls.Add(this.rbOutpOverw);
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(47, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 55);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // chkDateinDescription
            // 
            this.chkDateinDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDateinDescription.AutoSize = true;
            this.chkDateinDescription.Checked = true;
            this.chkDateinDescription.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDateinDescription.ForeColor = System.Drawing.Color.Tomato;
            this.chkDateinDescription.Location = new System.Drawing.Point(376, 19);
            this.chkDateinDescription.Name = "chkDateinDescription";
            this.chkDateinDescription.Size = new System.Drawing.Size(151, 17);
            this.chkDateinDescription.TabIndex = 18;
            this.chkDateinDescription.Text = "rename file as Date Taken";
            this.chkDateinDescription.UseVisualStyleBackColor = true;
            // 
            // tbSubfolderName
            // 
            this.tbSubfolderName.Location = new System.Drawing.Point(188, 19);
            this.tbSubfolderName.Name = "tbSubfolderName";
            this.tbSubfolderName.Size = new System.Drawing.Size(89, 20);
            this.tbSubfolderName.TabIndex = 2;
            this.tbSubfolderName.Text = "gpsfix";
            // 
            // rbSubfolder
            // 
            this.rbSubfolder.AutoSize = true;
            this.rbSubfolder.Checked = true;
            this.rbSubfolder.ForeColor = System.Drawing.Color.Tomato;
            this.rbSubfolder.Location = new System.Drawing.Point(82, 19);
            this.rbSubfolder.Name = "rbSubfolder";
            this.rbSubfolder.Size = new System.Drawing.Size(107, 17);
            this.rbSubfolder.TabIndex = 1;
            this.rbSubfolder.TabStop = true;
            this.rbSubfolder.Text = "Copy to subfolder";
            this.rbSubfolder.UseVisualStyleBackColor = true;
            this.rbSubfolder.CheckedChanged += new System.EventHandler(this.RBSubfolder_CheckedChanged);
            // 
            // rbOutpOverw
            // 
            this.rbOutpOverw.AutoSize = true;
            this.rbOutpOverw.ForeColor = System.Drawing.Color.Tomato;
            this.rbOutpOverw.Location = new System.Drawing.Point(6, 19);
            this.rbOutpOverw.Name = "rbOutpOverw";
            this.rbOutpOverw.Size = new System.Drawing.Size(70, 17);
            this.rbOutpOverw.TabIndex = 0;
            this.rbOutpOverw.Text = "Overwrite";
            this.rbOutpOverw.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.chkboxVidDatetime);
            this.groupBox2.Controls.Add(this.dgvCameraOffset);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rbConstantOffset);
            this.groupBox2.Controls.Add(this.rbUseLastOffset);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(47, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(536, 152);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Update when no GPS tag . . .";
            // 
            // dgvCameraOffset
            // 
            this.dgvCameraOffset.AllowUserToAddRows = false;
            this.dgvCameraOffset.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dgvCameraOffset.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCameraOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCameraOffset.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCameraOffset.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvCameraOffset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCameraOffset.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Camera,
            this.Hours});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCameraOffset.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCameraOffset.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCameraOffset.Location = new System.Drawing.Point(246, 32);
            this.dgvCameraOffset.Name = "dgvCameraOffset";
            this.dgvCameraOffset.RowHeadersVisible = false;
            this.dgvCameraOffset.Size = new System.Drawing.Size(255, 113);
            this.dgvCameraOffset.TabIndex = 5;
            this.toolTip1.SetToolTip(this.dgvCameraOffset, "Each camera has it\'s own offset applied.\r\nrefer to the outcome of the Preview.  \r" +
        "\nNote the offset correction is the opposite of the value returned by the Preview" +
        ".");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(439, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "hrs";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(288, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Constant / Default Offset to use";
            // 
            // rbConstantOffset
            // 
            this.rbConstantOffset.AutoSize = true;
            this.rbConstantOffset.ForeColor = System.Drawing.Color.Tomato;
            this.rbConstantOffset.Location = new System.Drawing.Point(15, 42);
            this.rbConstantOffset.Name = "rbConstantOffset";
            this.rbConstantOffset.Size = new System.Drawing.Size(124, 17);
            this.rbConstantOffset.TabIndex = 1;
            this.rbConstantOffset.Text = "use a constant offset";
            this.rbConstantOffset.UseVisualStyleBackColor = true;
            // 
            // rbUseLastOffset
            // 
            this.rbUseLastOffset.AutoSize = true;
            this.rbUseLastOffset.Checked = true;
            this.rbUseLastOffset.ForeColor = System.Drawing.Color.Tomato;
            this.rbUseLastOffset.Location = new System.Drawing.Point(15, 18);
            this.rbUseLastOffset.Name = "rbUseLastOffset";
            this.rbUseLastOffset.Size = new System.Drawing.Size(131, 17);
            this.rbUseLastOffset.TabIndex = 0;
            this.rbUseLastOffset.TabStop = true;
            this.rbUseLastOffset.Text = "use most recent Offset";
            this.rbUseLastOffset.UseVisualStyleBackColor = true;
            // 
            // butPreview
            // 
            this.butPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butPreview.BackColor = System.Drawing.Color.Transparent;
            this.butPreview.Image = global::FixExifTimeStamp.Properties.Resources.PrintPreviewControl_698;
            this.butPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butPreview.Location = new System.Drawing.Point(112, 396);
            this.butPreview.Name = "butPreview";
            this.butPreview.Size = new System.Drawing.Size(81, 34);
            this.butPreview.TabIndex = 23;
            this.butPreview.Text = "Pre&view";
            this.toolTip1.SetToolTip(this.butPreview, "Preview what offsets are contained within the valid EXIF tags. Use to set the Def" +
        "ault or constant offset correctly.");
            this.butPreview.UseVisualStyleBackColor = false;
            this.butPreview.Click += new System.EventHandler(this.ButPreview_Click);
            // 
            // butProcess
            // 
            this.butProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butProcess.BackColor = System.Drawing.Color.Transparent;
            this.butProcess.Enabled = false;
            this.butProcess.Image = global::FixExifTimeStamp.Properties.Resources.PrepareProcess;
            this.butProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butProcess.Location = new System.Drawing.Point(277, 390);
            this.butProcess.Name = "butProcess";
            this.butProcess.Size = new System.Drawing.Size(99, 46);
            this.butProcess.TabIndex = 19;
            this.butProcess.Text = "&Process";
            this.toolTip1.SetToolTip(this.butProcess, "Update the EXIF tags to suit adjusted time & date of photo.");
            this.butProcess.UseVisualStyleBackColor = false;
            this.butProcess.Click += new System.EventHandler(this.ButProcess_Click);
            // 
            // butGetPhotoFolder
            // 
            this.butGetPhotoFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butGetPhotoFolder.Image = ((System.Drawing.Image)(resources.GetObject("butGetPhotoFolder.Image")));
            this.butGetPhotoFolder.Location = new System.Drawing.Point(554, 108);
            this.butGetPhotoFolder.Name = "butGetPhotoFolder";
            this.butGetPhotoFolder.Size = new System.Drawing.Size(29, 26);
            this.butGetPhotoFolder.TabIndex = 16;
            this.butGetPhotoFolder.UseVisualStyleBackColor = true;
            this.butGetPhotoFolder.Click += new System.EventHandler(this.ButGetPhotoFolder_Click);
            // 
            // Camera
            // 
            this.Camera.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Camera.DividerWidth = 4;
            this.Camera.HeaderText = "Camera";
            this.Camera.MinimumWidth = 50;
            this.Camera.Name = "Camera";
            this.Camera.ReadOnly = true;
            this.Camera.Width = 72;
            // 
            // Hours
            // 
            this.Hours.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Hours.DefaultCellStyle = dataGridViewCellStyle2;
            this.Hours.HeaderText = "Hours";
            this.Hours.MinimumWidth = 100;
            this.Hours.Name = "Hours";
            // 
            // chkboxVidDatetime
            // 
            this.chkboxVidDatetime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkboxVidDatetime.Checked = true;
            this.chkboxVidDatetime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxVidDatetime.ForeColor = System.Drawing.Color.Tomato;
            this.chkboxVidDatetime.Location = new System.Drawing.Point(15, 95);
            this.chkboxVidDatetime.Name = "chkboxVidDatetime";
            this.chkboxVidDatetime.Size = new System.Drawing.Size(198, 50);
            this.chkboxVidDatetime.TabIndex = 19;
            this.chkboxVidDatetime.Text = "rename VID file with last offset if  name matches datetime";
            this.chkboxVidDatetime.UseVisualStyleBackColor = true;
            // 
            // GPS2Date
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FixExifTimeStamp.Properties.Resources.world_satellite;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(607, 482);
            this.Controls.Add(this.butPreview);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butProcess);
            this.Controls.Add(this.butGetPhotoFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPhotoFolder);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GPS2Date";
            this.Text = "GPS2Date";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCameraOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Button butProcess;
        private System.Windows.Forms.Button butGetPhotoFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPhotoFolder;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbSubfolderName;
        private System.Windows.Forms.RadioButton rbSubfolder;
        private System.Windows.Forms.RadioButton rbOutpOverw;
        private System.Windows.Forms.CheckBox chkDateinDescription;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbConstantOffset;
        private System.Windows.Forms.RadioButton rbUseLastOffset;
        private System.Windows.Forms.Button butPreview;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dgvCameraOffset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Camera;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hours;
        private System.Windows.Forms.CheckBox chkboxVidDatetime;
    }
}

