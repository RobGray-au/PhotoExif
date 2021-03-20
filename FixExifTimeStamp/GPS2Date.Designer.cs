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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GPS2Date));
            this.helloWorldLabel = new System.Windows.Forms.Label();
            this.butExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPhotoFolder = new System.Windows.Forms.TextBox();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbSubfolderName = new System.Windows.Forms.TextBox();
            this.rbSubfolder = new System.Windows.Forms.RadioButton();
            this.rbOutpOverw = new System.Windows.Forms.RadioButton();
            this.chkDateinDescription = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbConstantOffset = new System.Windows.Forms.RadioButton();
            this.rbUseLastOffset = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.butPreview = new System.Windows.Forms.Button();
            this.butProcess = new System.Windows.Forms.Button();
            this.butGetPhotoFolder = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgvCameraOffset = new System.Windows.Forms.DataGridView();
            this.Camera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCameraOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // helloWorldLabel
            // 
            this.helloWorldLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helloWorldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helloWorldLabel.Location = new System.Drawing.Point(25, 9);
            this.helloWorldLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.helloWorldLabel.Name = "helloWorldLabel";
            this.helloWorldLabel.Size = new System.Drawing.Size(549, 65);
            this.helloWorldLabel.TabIndex = 3;
            this.helloWorldLabel.Text = "Update Photo EXIF date using GPS info where available";
            this.helloWorldLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.helloWorldLabel.Click += new System.EventHandler(this.helloWorldLabel_Click);
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
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
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
            this.tbPhotoFolder.TextChanged += new System.EventHandler(this.tbPhotoFolder_TextChanged);
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
            this.groupBox1.Controls.Add(this.chkDateinDescription);
            this.groupBox1.Controls.Add(this.tbSubfolderName);
            this.groupBox1.Controls.Add(this.rbSubfolder);
            this.groupBox1.Controls.Add(this.rbOutpOverw);
            this.groupBox1.Location = new System.Drawing.Point(47, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 55);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
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
            this.rbSubfolder.Location = new System.Drawing.Point(82, 19);
            this.rbSubfolder.Name = "rbSubfolder";
            this.rbSubfolder.Size = new System.Drawing.Size(107, 17);
            this.rbSubfolder.TabIndex = 1;
            this.rbSubfolder.TabStop = true;
            this.rbSubfolder.Text = "Copy to subfolder";
            this.rbSubfolder.UseVisualStyleBackColor = true;
            this.rbSubfolder.CheckedChanged += new System.EventHandler(this.rbSubfolder_CheckedChanged);
            // 
            // rbOutpOverw
            // 
            this.rbOutpOverw.AutoSize = true;
            this.rbOutpOverw.Location = new System.Drawing.Point(6, 19);
            this.rbOutpOverw.Name = "rbOutpOverw";
            this.rbOutpOverw.Size = new System.Drawing.Size(70, 17);
            this.rbOutpOverw.TabIndex = 0;
            this.rbOutpOverw.Text = "Overwrite";
            this.rbOutpOverw.UseVisualStyleBackColor = true;
            // 
            // chkDateinDescription
            // 
            this.chkDateinDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDateinDescription.AutoSize = true;
            this.chkDateinDescription.Checked = true;
            this.chkDateinDescription.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDateinDescription.Location = new System.Drawing.Point(376, 19);
            this.chkDateinDescription.Name = "chkDateinDescription";
            this.chkDateinDescription.Size = new System.Drawing.Size(151, 17);
            this.chkDateinDescription.TabIndex = 18;
            this.chkDateinDescription.Text = "rename file as Date Taken";
            this.chkDateinDescription.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvCameraOffset);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rbConstantOffset);
            this.groupBox2.Controls.Add(this.rbUseLastOffset);
            this.groupBox2.Location = new System.Drawing.Point(47, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(536, 152);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Update when no GPS tag . . .";
            // 
            // rbConstantOffset
            // 
            this.rbConstantOffset.AutoSize = true;
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
            this.rbUseLastOffset.Location = new System.Drawing.Point(15, 18);
            this.rbUseLastOffset.Name = "rbUseLastOffset";
            this.rbUseLastOffset.Size = new System.Drawing.Size(131, 17);
            this.rbUseLastOffset.TabIndex = 0;
            this.rbUseLastOffset.TabStop = true;
            this.rbUseLastOffset.Text = "use most recent Offset";
            this.rbUseLastOffset.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Constant / Default Offset to use";
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
            // butPreview
            // 
            this.butPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butPreview.Image = global::FixExifTimeStamp.Properties.Resources.PrintPreviewControl_698;
            this.butPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butPreview.Location = new System.Drawing.Point(112, 396);
            this.butPreview.Name = "butPreview";
            this.butPreview.Size = new System.Drawing.Size(98, 34);
            this.butPreview.TabIndex = 23;
            this.butPreview.Text = "Pre&view";
            this.toolTip1.SetToolTip(this.butPreview, "Preview what offsets are contained within the valid EXIF tags. Use to set the Def" +
        "ault or constant offset correctly.");
            this.butPreview.UseVisualStyleBackColor = true;
            this.butPreview.Click += new System.EventHandler(this.butPreview_Click);
            // 
            // butProcess
            // 
            this.butProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butProcess.Enabled = false;
            this.butProcess.Image = global::FixExifTimeStamp.Properties.Resources.PrepareProcess;
            this.butProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butProcess.Location = new System.Drawing.Point(277, 390);
            this.butProcess.Name = "butProcess";
            this.butProcess.Size = new System.Drawing.Size(99, 46);
            this.butProcess.TabIndex = 19;
            this.butProcess.Text = "&Process";
            this.toolTip1.SetToolTip(this.butProcess, "Update the EXIF tags to suit adjusted time & date of photo.");
            this.butProcess.UseVisualStyleBackColor = true;
            this.butProcess.Click += new System.EventHandler(this.butProcess_Click);
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
            this.butGetPhotoFolder.Click += new System.EventHandler(this.butGetPhotoFolder_Click);
            // 
            // dgvCameraOffset
            // 
            this.dgvCameraOffset.AllowUserToAddRows = false;
            this.dgvCameraOffset.AllowUserToDeleteRows = false;
            this.dgvCameraOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCameraOffset.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCameraOffset.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCameraOffset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCameraOffset.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Camera,
            this.Hours});
            this.dgvCameraOffset.Location = new System.Drawing.Point(246, 32);
            this.dgvCameraOffset.Name = "dgvCameraOffset";
            this.dgvCameraOffset.RowHeadersVisible = false;
            this.dgvCameraOffset.Size = new System.Drawing.Size(255, 113);
            this.dgvCameraOffset.TabIndex = 5;
            this.toolTip1.SetToolTip(this.dgvCameraOffset, "Each camera has it\'s own offset applied.\r\nrefer to the outcome of the Preview.  \r" +
        "\nNote the offset correction is the opposite of the value returned by the Preview" +
        ".");
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
            this.Hours.HeaderText = "Hours";
            this.Hours.MinimumWidth = 100;
            this.Hours.Name = "Hours";
            // 
            // GPS2Date
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Controls.Add(this.helloWorldLabel);
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
        private System.Windows.Forms.Label helloWorldLabel;
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
    }
}

