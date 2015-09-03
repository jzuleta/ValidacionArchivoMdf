using Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controls;

namespace CopyFiles
{
    public partial class Form1 : Form
    {
        private delegate void delegateControl();
        private CopyControl _currentControl;
        private SqlServerInstance sqlServer = new SqlServerInstance();
        private List<MdfFile> dbList;

        public Form1()
        {
            InitializeComponent();
        }

        #region Copy Databases
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBoxIn.Text)
                && !string.IsNullOrWhiteSpace(this.textBoxOut.Text))
                prepareCopyFiles();
            else
                MessageBox.Show("Indique una ruta de origen y una de destino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void prepareCopyFiles()
        {
            backgroundWorkerCheckThread.DoWork += CopyFilesThreadDoWork;
            backgroundWorkerCheckThread.RunWorkerCompleted += CopyFilesRunWorkerCompleted;
            backgroundWorkerCheckThread.RunWorkerAsync();
        }

        private void executeCopyFile()
        {
            while (true)
            {
                if (ThreadControl.ThreadCount < ThreadControl.ThreadMax)
                {
                    ThreadControl.ThreadCount++;
                    break;
                }
                Thread.Sleep(1000);
            }

            this.Invoke(new delegateControl(addControl));
            _currentControl.InitCopy();
        }

        private void addControl()
        {
            panelContentBar.Controls.Add(_currentControl);
        }

        private void CopyFilesThreadDoWork(object sender, DoWorkEventArgs e)
        {
            var filesToCopy =
                Directory.EnumerateFiles(this.textBoxIn.Text, "*.mdf", SearchOption.AllDirectories).ToArray();

            for (var i = 0; i < filesToCopy.Length; i++)
            {
                _currentControl = new CopyControl
                {
                    db = new MdfFile(filesToCopy[i]),
                    outputPath = this.textBoxOut.Text.ToUpper(),
                    Dock = DockStyle.Top
                };

                executeCopyFile();
            }

            while (true)
            {
                if (ThreadControl.ThreadCount == 0)
                    break;

                Thread.Sleep(1000);
            }
        }

        private void CopyFilesRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorkerCheckThread.DoWork -= CopyFilesThreadDoWork;
            backgroundWorkerCheckThread.RunWorkerCompleted -= CopyFilesRunWorkerCompleted;
            MessageBox.Show("Listo", "Proceso Terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Validate Databases
        private void buttonValidate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxPathSource.Text) && Utilities.checkCountDb(textBoxPathSource.Text))
                prepareValidateFiles();
            else
                MessageBox.Show("Indique una ruta de origen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void prepareValidateFiles()
        {
            //var d = Utilities.checkCountDb(this.textBoxPathSource.Text);
            var validation = new ValidateControl(this.textBoxPathSource.Text);
            panelValidateContent.Controls.Add(validation);
            validation.InitValidate();
        }

        #endregion

        #region Create Text Files
        private void buttonFinder_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBoxSourceDb.Text))
                prepareCreateFiles();
            else
                MessageBox.Show("Indique una ruta de origen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void prepareCreateFiles()
        {
            var dbs = Directory.EnumerateFiles(this.textBoxSourceDb.Text, "*.mdf", SearchOption.AllDirectories).ToArray();
            dbList = new List<MdfFile>();

            checkedListBoxDbList.Items.Clear();
            for (var i = 0; i < dbs.Length; i++)
            {
                dbList.Add(new MdfFile(dbs[i]));
                checkedListBoxDbList.Items.Add(dbList[i].code);
                checkedListBoxDbList.SetItemChecked(i, true);
            }


            
            buttonCreate.Enabled = dbList.Count != 0;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var createText = new CreateTextControl(
                dbList,
                Utilities.createArrayIndex(checkedListBoxDbList.CheckedIndices)
            );

            panelCreateTextStat.Controls.Add(createText);

            createText.InitCreation();
        }
        #endregion
    }
}