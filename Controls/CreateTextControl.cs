using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Components;

namespace Controls
{
    public partial class CreateTextControl : UserControl
    {
        private List<MdfFile> listDbs;
        private int[] indexDbs;

        public CreateTextControl(List<MdfFile> dbs, int[] indexDbs)
        {
            InitializeComponent();
            this.listDbs = dbs;
            this.indexDbs = indexDbs;
        }

        public void InitCreation()
        {
            ThreadControl.ThreadCount++;
            backgroundWorkerCreateText.RunWorkerAsync();
        }

        private void executeCommand(string command)
        {
            var process = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = "/c " + command
            };

            var execCmd = Process.Start(process);
            execCmd.WaitForExit();
        }

        private void backgroundWorkerCreateText_DoWork(object sender, DoWorkEventArgs e)
        {
            var commandTemplate =
                "bcp \"SELECT * FROM [{0}].dbo.{1}\" QUERYOUT \"{2}\\{3}.txt\" -c -t^; -T -S DI401\\SEC_SQL";
            object[] tables = Components.DataSet.getTables();
            var percent = 0;
            long exported = 0;
            long totalExport = indexDbs.Length;

            foreach (var index in indexDbs)
            {
                object[] tableCollection = (object[])tables[listDbs[index].Part - 1];
                listDbs[index].attachDb();
                if (listDbs[index].isAttached)
                {
                    for (var x = 0; x < tableCollection.Length; x++)
                    {
                        var command = string.Format(
                            commandTemplate,
                            listDbs[index].code,
                            tableCollection[x],
                            listDbs[index].DbDirectory,
                            tableCollection[x]
                        );
                        percent = (int)Math.Round((double)((exported * 100) / totalExport));
                        backgroundWorkerCreateText.ReportProgress(
                            percent, "BASE " + listDbs[index].code + listDbs[index].Part + " TABLA " + tableCollection[x] + "...");
                        executeCommand(command);
                    }
                    //listDbs[index].detachDb();
                }                
                exported++;
            }
        }

        private void backgroundWorkerCreateText_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelCreation.Text = e.UserState.ToString();
        }

        private void backgroundWorkerCreateText_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labelCreation.Text = "Archivos Creados";
            ThreadControl.ThreadCount--;
        }
    }
}
