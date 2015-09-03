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
using Components;

namespace Controls
{
    public partial class ValidateControl : UserControl
    {
        private string pathSource;
        private SqlServerInstance sqlServer = new SqlServerInstance();
        public List<MdfFile> listDb = new List<MdfFile>();

        public ValidateControl(string pathSource)
        {
            InitializeComponent();
            this.pathSource = pathSource;
        }

        public void InitValidate()
        {
            ThreadControl.ThreadCount++;
            backgroundWorkerValidate.RunWorkerAsync();
        }

        private void ValidateFilesThreadDoWork(object sender, DoWorkEventArgs e)
        {
            var listPathDbs = Directory.EnumerateFiles(pathSource, "*.mdf", SearchOption.AllDirectories).ToList();
            var totalFiles = listPathDbs.Count;
            var dbState = string.Empty;
            foreach (var file in listPathDbs)
            {
                var db = new MdfFile(file);
                dbState = string.Format("empresa{0} -> {1} ", db.Id.PadLeft(3, '0'), db.DbName.PadRight(35, '*'));
                backgroundWorkerValidate.ReportProgress(0, dbState + "adjuntando");
                db.attachDb();              

                if (db.isAttached)
                {
                    backgroundWorkerValidate.ReportProgress(0, dbState + "contando objetos");
                    db.validateDb();
                    backgroundWorkerValidate.ReportProgress(0, dbState + "validando");
                   
                    DataAccess.executeCommand(DataAccess.commandToSP(db.code));
                    db.detachDb();
                }

                var totalErrors = db.validation.listErrors;
                if (totalErrors.Count != 0)
                    DataAccess.executeCommand(DataAccess.commandToText(generateInserts(db)));               
                
                backgroundWorkerValidate.ReportProgress(0, dbState + "terminada");
               
            }

        }

        private string generateInserts(MdfFile dbs)
        {
            var insertA = "insert into DETALLE_ERRORES (BASE, RUTA, EMPRESA_ID, PARTE, TIPO_ERROR) values";
            var insertB = "\n";

            insertB +=
                string.Concat(dbs.validation.listErrors.Select(x => string.Format("('{0}', '{1}', '{2}', '{3}', '{4}'),", dbs.code, dbs.PathDb, dbs.Id, dbs.Part, x)));

            return insertA + insertB.Remove(insertB.Length - 1);
        }

        private void ValidateFilesRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            textBoxValidation.Text += Environment.NewLine + "Validacion completada...";
            sqlServer.Dispose();
            ThreadControl.ThreadCount--;
        }

        private void ValidateFilesProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBoxValidation.Text += Environment.NewLine + e.UserState;
            textBoxValidation.SelectionStart = textBoxValidation.Text.Length;
            textBoxValidation.ScrollToCaret();
        }
    }
}
