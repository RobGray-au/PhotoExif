﻿
namespace KMZ_PhotoMapper
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbPhotoFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.butGetPhotoFolder = new System.Windows.Forms.Button();
            this.butGetOutputFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOutputFileName = new System.Windows.Forms.TextBox();
            this.chkIncThumbnails = new System.Windows.Forms.CheckBox();
            this.chkOrderbyDate = new System.Windows.Forms.CheckBox();
            this.chkPhotoFileName = new System.Windows.Forms.CheckBox();
            this.chkDateinDescription = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkUseGPSDate = new System.Windows.Forms.CheckBox();
            this.butProcess = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.chkPath = new System.Windows.Forms.CheckBox();
            this.imgSizeDDL = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPhotoFolder
            // 
            this.tbPhotoFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPhotoFolder.Location = new System.Drawing.Point(51, 135);
            this.tbPhotoFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPhotoFolder.Name = "tbPhotoFolder";
            this.tbPhotoFolder.Size = new System.Drawing.Size(505, 26);
            this.tbPhotoFolder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(54, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(583, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "App currently requires the photos to have valid EXIF Georeferencing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(46, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Photo location to be searched";
            // 
            // butGetPhotoFolder
            // 
            this.butGetPhotoFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butGetPhotoFolder.Image = global::KMZ_PhotoMapper.Properties.Resources.Open_65291;
            this.butGetPhotoFolder.Location = new System.Drawing.Point(567, 135);
            this.butGetPhotoFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butGetPhotoFolder.Name = "butGetPhotoFolder";
            this.butGetPhotoFolder.Size = new System.Drawing.Size(44, 40);
            this.butGetPhotoFolder.TabIndex = 3;
            this.butGetPhotoFolder.UseVisualStyleBackColor = true;
            this.butGetPhotoFolder.Click += new System.EventHandler(this.butGetPhotoFolder_Click);
            // 
            // butGetOutputFile
            // 
            this.butGetOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butGetOutputFile.Image = global::KMZ_PhotoMapper.Properties.Resources.Open_65291;
            this.butGetOutputFile.Location = new System.Drawing.Point(567, 209);
            this.butGetOutputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butGetOutputFile.Name = "butGetOutputFile";
            this.butGetOutputFile.Size = new System.Drawing.Size(44, 40);
            this.butGetOutputFile.TabIndex = 6;
            this.butGetOutputFile.UseVisualStyleBackColor = true;
            this.butGetOutputFile.Click += new System.EventHandler(this.butGetOutputFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(46, 173);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output KML/KMZ data file";
            // 
            // tbOutputFileName
            // 
            this.tbOutputFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutputFileName.Location = new System.Drawing.Point(51, 198);
            this.tbOutputFileName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbOutputFileName.Name = "tbOutputFileName";
            this.tbOutputFileName.Size = new System.Drawing.Size(505, 26);
            this.tbOutputFileName.TabIndex = 4;
            // 
            // chkIncThumbnails
            // 
            this.chkIncThumbnails.AutoSize = true;
            this.chkIncThumbnails.BackColor = System.Drawing.Color.Transparent;
            this.chkIncThumbnails.Checked = true;
            this.chkIncThumbnails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncThumbnails.Location = new System.Drawing.Point(51, 272);
            this.chkIncThumbnails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkIncThumbnails.Name = "chkIncThumbnails";
            this.chkIncThumbnails.Size = new System.Drawing.Size(288, 24);
            this.chkIncThumbnails.TabIndex = 7;
            this.chkIncThumbnails.Text = "Use thumbnail photo as placemarks";
            this.toolTip1.SetToolTip(this.chkIncThumbnails, "Includes a 128 pixel version of photo in KMZ");
            this.chkIncThumbnails.UseVisualStyleBackColor = false;
            // 
            // chkOrderbyDate
            // 
            this.chkOrderbyDate.AutoSize = true;
            this.chkOrderbyDate.BackColor = System.Drawing.Color.Transparent;
            this.chkOrderbyDate.Checked = true;
            this.chkOrderbyDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOrderbyDate.Location = new System.Drawing.Point(51, 308);
            this.chkOrderbyDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkOrderbyDate.Name = "chkOrderbyDate";
            this.chkOrderbyDate.Size = new System.Drawing.Size(222, 24);
            this.chkOrderbyDate.TabIndex = 8;
            this.chkOrderbyDate.Text = "Order points by data taken";
            this.toolTip1.SetToolTip(this.chkOrderbyDate, "Takes a lot more time as has to read all files. But needed if photos are not name" +
        "d by date");
            this.chkOrderbyDate.UseVisualStyleBackColor = false;
            // 
            // chkPhotoFileName
            // 
            this.chkPhotoFileName.AutoSize = true;
            this.chkPhotoFileName.BackColor = System.Drawing.Color.Transparent;
            this.chkPhotoFileName.Checked = true;
            this.chkPhotoFileName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPhotoFileName.Location = new System.Drawing.Point(51, 377);
            this.chkPhotoFileName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkPhotoFileName.Name = "chkPhotoFileName";
            this.chkPhotoFileName.Size = new System.Drawing.Size(298, 24);
            this.chkPhotoFileName.TabIndex = 9;
            this.chkPhotoFileName.Text = "Include photo filename as description";
            this.chkPhotoFileName.UseVisualStyleBackColor = false;
            // 
            // chkDateinDescription
            // 
            this.chkDateinDescription.AutoSize = true;
            this.chkDateinDescription.BackColor = System.Drawing.Color.Transparent;
            this.chkDateinDescription.Checked = true;
            this.chkDateinDescription.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDateinDescription.Location = new System.Drawing.Point(51, 412);
            this.chkDateinDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDateinDescription.Name = "chkDateinDescription";
            this.chkDateinDescription.Size = new System.Drawing.Size(299, 24);
            this.chkDateinDescription.TabIndex = 10;
            this.chkDateinDescription.Text = "Include Date Taken within description";
            this.chkDateinDescription.UseVisualStyleBackColor = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 661);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(884, 31);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(108, 26);
            this.toolStripStatusLabel1.Text = "....                ";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 25);
            // 
            // chkUseGPSDate
            // 
            this.chkUseGPSDate.AutoSize = true;
            this.chkUseGPSDate.BackColor = System.Drawing.Color.Transparent;
            this.chkUseGPSDate.Checked = true;
            this.chkUseGPSDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseGPSDate.Enabled = false;
            this.chkUseGPSDate.Location = new System.Drawing.Point(51, 343);
            this.chkUseGPSDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkUseGPSDate.Name = "chkUseGPSDate";
            this.chkUseGPSDate.Size = new System.Drawing.Size(247, 24);
            this.chkUseGPSDate.TabIndex = 16;
            this.chkUseGPSDate.Text = "Use GPS date where possible";
            this.toolTip1.SetToolTip(this.chkUseGPSDate, "Deprecated. Now assumes that Exif date has been corrected using companion app Fix" +
        "ExifDate");
            this.chkUseGPSDate.UseVisualStyleBackColor = false;
            // 
            // butProcess
            // 
            this.butProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butProcess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butProcess.ForeColor = System.Drawing.Color.RoyalBlue;
            this.butProcess.Location = new System.Drawing.Point(202, 549);
            this.butProcess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butProcess.Name = "butProcess";
            this.butProcess.Size = new System.Drawing.Size(260, 71);
            this.butProcess.TabIndex = 12;
            this.butProcess.Text = "Process";
            this.butProcess.UseVisualStyleBackColor = false;
            this.butProcess.Click += new System.EventHandler(this.butProcess_Click);
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExit.ForeColor = System.Drawing.Color.RoyalBlue;
            this.butExit.Location = new System.Drawing.Point(723, 549);
            this.butExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(129, 66);
            this.butExit.TabIndex = 13;
            this.butExit.Text = "Exit";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(54, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(51, 77);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(505, 26);
            this.tbDescription.TabIndex = 14;
            // 
            // chkPath
            // 
            this.chkPath.AutoSize = true;
            this.chkPath.BackColor = System.Drawing.Color.Transparent;
            this.chkPath.Checked = true;
            this.chkPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPath.Location = new System.Drawing.Point(51, 448);
            this.chkPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkPath.Name = "chkPath";
            this.chkPath.Size = new System.Drawing.Size(235, 24);
            this.chkPath.TabIndex = 17;
            this.chkPath.Text = "Include path between points";
            this.chkPath.UseVisualStyleBackColor = false;
            // 
            // imgSizeDDL
            // 
            this.imgSizeDDL.FormattingEnabled = true;
            this.imgSizeDDL.ItemHeight = 20;
            this.imgSizeDDL.Items.AddRange(new object[] {
            "400",
            "600",
            "800",
            "1000"});
            this.imgSizeDDL.Location = new System.Drawing.Point(156, 232);
            this.imgSizeDDL.Name = "imgSizeDDL";
            this.imgSizeDDL.Size = new System.Drawing.Size(81, 24);
            this.imgSizeDDL.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(54, 236);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Preview size";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KMZ_PhotoMapper.Properties.Resources.kmzItaly;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(884, 692);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.imgSizeDDL);
            this.Controls.Add(this.chkPath);
            this.Controls.Add(this.chkUseGPSDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butProcess);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chkDateinDescription);
            this.Controls.Add(this.chkPhotoFileName);
            this.Controls.Add(this.chkOrderbyDate);
            this.Controls.Add(this.chkIncThumbnails);
            this.Controls.Add(this.butGetOutputFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbOutputFileName);
            this.Controls.Add(this.butGetPhotoFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPhotoFolder);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Opacity = 0.9D;
            this.Text = "KMZ-Photomapper";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPhotoFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button butGetPhotoFolder;
        private System.Windows.Forms.Button butGetOutputFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOutputFileName;
        private System.Windows.Forms.CheckBox chkIncThumbnails;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkOrderbyDate;
        private System.Windows.Forms.CheckBox chkPhotoFileName;
        private System.Windows.Forms.CheckBox chkDateinDescription;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button butProcess;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.CheckBox chkUseGPSDate;
        private System.Windows.Forms.CheckBox chkPath;
        private System.Windows.Forms.ListBox imgSizeDDL;
        private System.Windows.Forms.Label label5;
    }
}

