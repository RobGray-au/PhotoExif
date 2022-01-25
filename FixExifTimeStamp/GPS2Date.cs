using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FixExifTimeStamp
{
    public partial class GPS2Date : Form
    {
        public GPS2Date()
        {
            InitializeComponent();
        }


        private void ButProcess_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Processing folder..";
            toolStripProgressBar1.Value = 1; statusStrip1.Refresh();
            DirectoryInfo di = new DirectoryInfo(tbPhotoFolder.Text);
            if (!di.Exists)
            {
                MessageBox.Show("Photo folder not found");
                return;
            }
            string outputFolderPath;
            if (rbSubfolder.Checked)
            {
                outputFolderPath = Path.Combine(di.FullName, tbSubfolderName.Text);
                Directory.CreateDirectory(outputFolderPath);
            }
            else
            {
                outputFolderPath = "";
            }

            FixExifTimeStamp.FixExif_methods.OverwriteFile = rbOutpOverw.Checked;
            FixExifTimeStamp.FixExif_methods.outPutFolderName = outputFolderPath;
            FixExifTimeStamp.FixExif_methods.RenameFile_asDate = chkDateinDescription.Checked;
            FixExifTimeStamp.FixExif_methods.OffsetUsePrevious = rbUseLastOffset.Checked;
            FixExifTimeStamp.FixExif_methods.OffsetUseFixed = rbConstantOffset.Checked;
            FixExifTimeStamp.FixExif_methods.RenameVids = chkboxVidDatetime.Checked;

            //FixExifTimeStamp.FixExif_methods.OffsetFixed = Convert.ToSingle(tbTimeOffset.Text);
            Console.WriteLine(DateTime.Now.Ticks);

            FixExif_methods.cameraTimeOffsetbase = new Dictionary<string, TimeSpan>();
            foreach (DataGridViewRow dgvRow in dgvCameraOffset.Rows)
            {
                double hrsX = Convert.ToSingle(dgvRow.Cells[1].Value);
                int hrs = Convert.ToInt32(Math.Truncate(hrsX));
                int mins = Convert.ToInt32(Math.Round(hrsX - hrs, 2) * 60);
                TimeSpan thisOffset = new TimeSpan(hrs, mins, 0);
                FixExif_methods.cameraTimeOffsetbase.Add(dgvRow.Cells[0].Value.ToString(), thisOffset);
            }

            var fileList = di.GetFiles();
            Array.Sort(fileList, (f1, f2) => f1.Name.CompareTo(f2.Name));
            int totalfiles = fileList.Length; if (totalfiles < 10) totalfiles = 10;
            int countf = 0;
            foreach (var fl in fileList)
            {
                countf++;
                Math.DivRem(countf, totalfiles / 10, out int remaind);
                if (remaind == 0) { toolStripProgressBar1.Value = countf * 100 / totalfiles; ; }
                FixExifTimeStamp.FixExif_methods.FixEXIFtimestamp(fl.FullName);
            }

            toolStripStatusLabel1.Text = "..Done"; toolStripProgressBar1.Value = 0; statusStrip1.Refresh();
        }

        private void ButExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RBSubfolder_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSubfolder.Checked)
            {
                tbSubfolderName.Enabled = true;
            }
            else
            {
                tbSubfolderName.Enabled = false;
            }
        }

        private void ButGetPhotoFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                Description = "Select folder with photos to use for date check"
            };
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbPhotoFolder.Text = fbd.SelectedPath;
            }
        }

        private void ButPreview_Click(object sender, EventArgs e)
        {
            ///run through all the items and get stats
            if (tbPhotoFolder.Text.Length == 0) return;

            DirectoryInfo di = new DirectoryInfo(tbPhotoFolder.Text);
            toolStripStatusLabel1.Text = "Previewing GPS data...";
            toolStripProgressBar1.Value = 1; statusStrip1.Refresh();
            statusStrip1.Refresh();
            if (!di.Exists)
            {
                MessageBox.Show("Photo folder not found");
                return;
            }


            FixExif_methods.outPutFolderName = "";
            FixExif_methods.RenameFile_asDate = chkDateinDescription.Checked;
            FixExif_methods.OffsetUsePrevious = rbUseLastOffset.Checked;
            FixExif_methods.OffsetUseFixed = rbConstantOffset.Checked;

            Dictionary<string, Dictionary<float, int>> cameraTimeStats = new Dictionary<string, Dictionary<float, int>>();

            Dictionary<float, int> imagestats = new Dictionary<float, int>();
            var fileList = di.GetFiles();
            int totalfiles = fileList.Length; if (totalfiles < 10) totalfiles = 11;
            string cameraModel = "";
            float thisOffset =0;
            int countf = 0; 
            foreach (var fl in fileList)
            {
                countf++;
                Math.DivRem(countf, totalfiles/10, out int remaind );
                if (remaind == 0) { toolStripProgressBar1.Value = countf * 100 / totalfiles ; ; }
                
                FixExifTimeStamp.CameraTimeOffset thisCameraOffset = FixExifTimeStamp.FixExif_methods.GetEXIFtime_diff(fl.FullName);
                cameraModel = thisCameraOffset.cameraName;
                thisOffset = thisCameraOffset.OffsetTime;
                if (cameraTimeStats.ContainsKey(cameraModel))
                {
                    if (cameraTimeStats[cameraModel].ContainsKey(thisOffset))
                    {
                        cameraTimeStats[cameraModel][thisOffset] += 1;
                    }
                    else
                    {
                        cameraTimeStats[cameraModel].Add(thisOffset, 1);
                    }
                }
                else
                {
                    imagestats = new Dictionary<float, int>
                    {
                        { thisOffset, 1 }
                    };
                    cameraTimeStats.Add(cameraModel, imagestats);
                }

            }

            StringBuilder sb = new StringBuilder("  Hrs    Count\n");
            dgvCameraOffset.Rows.Clear();
            foreach(var cam in cameraTimeStats)
            {
                string camName = cam.Key;
                dgvCameraOffset.Rows.Add(camName, 0);
                imagestats = cam.Value;
                var orderStats = imagestats.OrderBy(x => x.Key);
                foreach (var item in orderStats)
                {
                    switch (item.Key)
                    {
                        case 99901:
                            sb.AppendLine(string.Format("{2,-20} No GPS = {1,3:##0}", item.Key, item.Value, camName));
                            break;
                        case 99999:
                        case 99998:
                            sb.AppendLine(string.Format("{2,-20} Not image = {1,3:##0}", item.Key, item.Value, camName));
                            break;
                        default:
                            //is a error flag time offset though should be less than 10 if camera has date set
                            sb.AppendLine(string.Format("{2,-20} {0,4:#0.00} = {1,3:##0}", item.Key, item.Value, camName));
                            break;
                    }

                }
            }


            toolStripStatusLabel1.Text = "..Done"; toolStripProgressBar1.Value = 0; statusStrip1.Refresh();
            MessageBox.Show(sb.ToString(), "Date offset values discovered");

            butProcess.Enabled = true;
        }

        private void TBPhotoFolder_TextChanged(object sender, EventArgs e)
        {
            butProcess.Enabled = false;
        }
    }


}
