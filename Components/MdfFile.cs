using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;

namespace Components
{
    public class MdfFile
    {
        private Regex rgx = new Regex(@"EMPRESA-(\d){1,2}");
        public string PathDb { get; private set; }
        public bool isAttached { get; private set; }
        public OrderedDictionary dbConfig { get; private set; }
        public ValidateMdf validation;

        public MdfFile(string path)
        {            
            this.PathDb = path;
            this.dbConfig = new OrderedDictionary();
        }

        public string DbCleanDirectory
        {
            get
            {
                return DbDirectory.Replace("\\\\", "");
            }
        }

        public string DbDirectory
        {
            get
            {
                return Path.GetDirectoryName(PathDb).ToUpper();
            }
        }

        public string DbName
        {
            get
            {
                return Path.GetFileNameWithoutExtension(PathDb).ToUpper();
            }
        }

        public int Part
        {
            get
            {
                return DbName.Contains("NODO") ? 1 :
                       DbName.Contains("CONEXION") ? 2 :
                       DbName.Contains("FULL") ? 3 : 1;
            }
        }

        public string Id
        {
            get
            {
                return rgx.Match(PathDb.ToUpper()).ToString().Substring(8);
            }
        }

        public string code
        {
            get
            {
                return string.Format("EMPRESA/{0}_PARTE/{1}", this.Id.PadLeft(2, '0'), this.Part);
            }
        }

        private void setState()
        {
            isAttached = !isAttached;
        }


        public void validateDb()
        {
            validation = new ValidateMdf(this);
        }

        public bool attachDb()
        {
            try
            {
                SqlServerInstance.Server.AttachDatabase(
                 code, new StringCollection
                        {
                            PathDb
                        }, AttachOptions.RebuildLog);

                setState();
            }
            catch (Exception e)
            {
                this.validation = new ValidateMdf();
                this.validation.listErrors.Add("AE");
                this.validation.isValid = false;
            }

            return isAttached;

        }

        public void detachDb()
        {
            SqlServerInstance.Server.Databases[code].DatabaseOptions.UserAccess = DatabaseUserAccess.Single;
            SqlServerInstance.Server.Databases[code].Alter(TerminationClause.RollbackTransactionsImmediately);            
            SqlServerInstance.Server.KillAllProcesses(code);            
            SqlServerInstance.Server.DetachDatabase(code, true);

            setState();
        }
    }
}
