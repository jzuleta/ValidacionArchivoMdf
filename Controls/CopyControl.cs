using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Components;

namespace CopyFiles
{
    public partial class CopyControl : UserControl
    {
        private delegate void delegateProgress();
        public MdfFile db { get; set; }
        public string outputPath { get; set; }
        private string outputName;
        private int percent;

        public CopyControl()
        {
            InitializeComponent();
        }

        private void autoDispose()
        {
            this.progressBarCopy.Value = 100;
            ThreadControl.ThreadCount--;
            this.Dispose();
        }

        private void progressChange()
        {
            this.labelPercent.Text = percent + "%";
            this.progressBarCopy.Value = percent;
            this.labelDetailCopy.Text = "Empresa " + db.Id + " -> "+db.DbName.ToLower();
        }

        private void checkDirectory()
        {
            outputPath = string.Format(@"{0}\{1}", outputPath,  db.DbCleanDirectory);
            outputName = string.Format(@"{0}\{1}.mdf", outputPath, db.DbName);

            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);
        }

        public void InitCopy()
        {
            checkDirectory();
            backgroundWorkerCopy.RunWorkerAsync();
        }

        private void backgroundWorkerCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream(db.PathDb, FileMode.Open, FileAccess.Read))
                {
                    using (Stream rs = new FileStream(outputName, FileMode.OpenOrCreate, FileAccess.Write))
                    {

                        var buffer = new byte[8092];
                        int read = 0;
                        long bytesSent = 0;
                        long bytesTotal = fs.Length;

                        while ((read = fs.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            rs.Write(buffer, 0, read);
                            bytesSent += read;
                            percent = (int)Math.Round((double)((bytesSent * 100) / bytesTotal));
                            this.Invoke(new delegateProgress(progressChange));
                        }
                        rs.Flush();
                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show("Error al copiar el archivo\n" + err.Message);
            }
            finally
            {
                this.Invoke(new delegateProgress(autoDispose));
            }
        }

    }
}
