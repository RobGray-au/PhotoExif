using System;

using System.Windows.Forms;

namespace KMZ_PhotoMapper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void butProcess_Click(object sender, EventArgs e)
        {
            Processor go = new Processor(tbDescription.Text)
            {
                IncludeThumbnails = chkIncThumbnails.Checked,
                Inputfolder = tbPhotoFolder.Text,
                OutputFileName = tbOutputFileName.Text,
                SortByDateTaken = chkOrderbyDate.Checked,
                PhotoFilename_asDescription = chkPhotoFileName.Checked,
                UseGPSDate = chkUseGPSDate.Checked,
                IncludeDateonpopout = chkDateinDescription.Checked,
                IncludePath = chkPath.Checked
                
            };
            go.Progress += new Processor.ProgressDelegate(DisplayProgress);

            var isOk = go.Begin();
        }

        private void DisplayProgress(string message, int percent)
        {
            if (InvokeRequired)
            {
                Invoke(new Processor.ProgressDelegate(DisplayProgress), new object[] { message, percent });
            }
            else
            {
                toolStripStatusLabel1.Text = message;
                toolStripProgressBar1.Value = percent;
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butGetPhotoFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                Description = "Select folder with photos to use for KMZ"
            };
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbPhotoFolder.Text = fbd.SelectedPath;
            }
        }

        private void butGetOutputFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog getOutFileDialog = new SaveFileDialog())
            {
                getOutFileDialog.InitialDirectory = "c:\\";
                getOutFileDialog.Filter = "GoogleEarth Zip (*.kmz) |*.kmz| GoogleEarthList (*.kml) |*.kml";
                getOutFileDialog.FilterIndex = 1;
                getOutFileDialog.CheckFileExists = false;
                getOutFileDialog.CheckPathExists = true;
                getOutFileDialog.RestoreDirectory = false;
                getOutFileDialog.DefaultExt = "kmz";
                getOutFileDialog.AddExtension = true;
                getOutFileDialog.SupportMultiDottedExtensions = false;
                DialogResult dr = getOutFileDialog.ShowDialog();
                if (!string.IsNullOrEmpty(getOutFileDialog.FileName) )
                {
                    //Get the path of specified file
                    tbOutputFileName.Text = getOutFileDialog.FileName;
                }
            }


        }


    }
}
